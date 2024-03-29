﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using YogaStudio.DTOs;
using YogaStudio.Models;
using YogaStudio.Services;

namespace YogaStudio.Controllers
{
    [Route("Administration")]
    [ApiController]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserService _service;

        public AdministrationController(RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, UserService service)
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
            Role role = new Role();
            
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
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return await Task.Run(() => Json(_service.GetAll()));
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("SwitchRoles")]
        public async Task<IActionResult> SwitchRoles([FromBody] UserRoleDTO usr)
        {
            return await Task.Run(() => Json(_service.UpdateRole(usr.Id, usr.Role)));
        }

    }
}
