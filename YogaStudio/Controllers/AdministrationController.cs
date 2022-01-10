using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YogaStudio.Models;
using YogaStudio.Services;

namespace YogaStudio.Controllers
{
    [Route("Administration")]
    [ApiController]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserService _service;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, UserService service)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromForm] Dictionary<string, string> diz)
        {
            IdentityRole role = new IdentityRole();
            
            foreach (string element in diz.Keys)
            {
                switch (element.ToLower())
                {
                    case "name": role.Name = diz[element]; break;
                }
            }

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                //return Redirect("http://192.168.1.62:8080/");
                return Redirect("/swagger/index.html");
            }

            return Redirect("/swagger/index.html");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddAdminUser")]
        public async Task<IActionResult> AddAdminUser()
        {
            var user = await _userManager.GetUserAsync(User);

            if (!(await _userManager.IsInRoleAsync(user, "Admin")))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return Redirect("/swagger/index.html");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await Task.Run(() => Json(_service.GetAll()));
        }
        

    }
}
