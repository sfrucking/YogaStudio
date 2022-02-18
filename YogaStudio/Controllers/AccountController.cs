using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Controllers
{
    [Route("Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly DataContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, DataContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm]Dictionary<string, string> diz)
        {

            var user = new User();
            string pass = string.Empty;

            foreach(string element in diz.Keys)
            {
                switch (element.ToLower())
                {
                    case "username": user.UserName = diz[element]; break;
                    case "email": user.Email = diz[element]; break;
                    case "password": pass = diz[element]; break;
                }
            }

            var result = await userManager.CreateAsync(user, pass);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                //return Redirect("http://192.168.1.62:8080/");
                return Redirect("/swagger/index.html");           
            }

            return null;

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromForm] Dictionary<string, string> diz)
        {
            try
            {
                string pass = string.Empty;

                var result = await signInManager.PasswordSignInAsync(diz["UserName"], diz["Password"], false, false);

                if (result.Succeeded)
                {
                    UserSubscription us = _context.UserSubscriptions.Find(userManager.GetUserId(User));
                    User user = await userManager.FindByIdAsync(userManager.GetUserId(User));

                    if (us != null && us.SubscriptionExpiringDate < DateTime.Now)
                    {
                        _context.UserSubscriptions.Remove(us);
                        await userManager.RemoveFromRoleAsync(user, "Subscriber");
                    }

                    return Redirect("/swagger/index.html");
                }

                return StatusCode(500, "Invalid Login Attempt");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
            
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/swagger/index.html");
        }
    }
}
