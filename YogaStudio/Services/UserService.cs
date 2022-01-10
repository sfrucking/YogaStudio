using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(DataContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public List<User> GetAll()
        {
            return _userManager.Users.Include(u => u.Roles).ToList();
        }
        

        
    }
}
