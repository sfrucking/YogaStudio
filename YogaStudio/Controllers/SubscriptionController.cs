using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YogaStudio.Models;

namespace YogaStudio.Controllers
{
    [Route("Subscription")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SubscriptionController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe()
        {
            var user = await _userManager.GetUserAsync(User);

            if(!(await _userManager.IsInRoleAsync(user, "Subscriber")))
            {
                await _userManager.AddToRoleAsync(user, "Subscriber");
            }

            return Redirect("/swagger/index.html");
        }
    }
}
