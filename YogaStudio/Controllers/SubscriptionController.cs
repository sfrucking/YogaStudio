using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Controllers
{
    [Authorize]
    [Route("Subscription")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _context;

        public SubscriptionController(RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, DataContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        
        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe([FromForm] string stripeEmail, [FromForm] string stripeToken, [FromForm] long amount, [FromForm] string type, [FromForm] int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                bool charged = Charge(stripeEmail, stripeToken, amount);

                if (!(await _userManager.IsInRoleAsync(user, "Subscriber")) && charged)
                {
                    await _userManager.AddToRoleAsync(user, "Subscriber");
                    _context.UserSubscriptions.Add(new UserSubscription { UserId = user.Id, SubscriptionId = id, SubscriptionExpiringDate = CheckExpiringDate(type), SubInit = DateTime.Now, IsValid = true });
                    _context.SaveChanges();
                }

                return Redirect("/swagger/index.html");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        

        [HttpGet("Stripe")]
        public IActionResult Stripe()
        {
            return View(_context.Subscriptions.ToList<Models.Subscription>());
        }
 
        private bool Charge(string stripeEmail, string stripeToken, long amount)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions { Email = stripeEmail,  Source = stripeToken});

            var charge = charges.Create(new ChargeCreateOptions { Amount = amount, Description = "TestPayment", Currency = "eur", Customer = customer.Id});

            if(charge.Status == "succeeded")
            {
                string balanceTransactionId = charge.BalanceTransactionId;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private DateTime CheckExpiringDate(string type)
        {
            int? months = null;
            DateTime expiringDate = DateTime.Now;

            try
            {
                months = (int)Char.GetNumericValue(type[0]);
                expiringDate.AddMonths((int)months);
                return expiringDate;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    } 
}
