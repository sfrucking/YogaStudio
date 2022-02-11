using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Data;
using YogaStudio.Models;

namespace YogaStudio.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(DataContext context, RoleManager<Role> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public List<User> GetAll()
        {
            //return _userManager.Users.Include(u => u.Roles).ToList();
            return _context.Users.Include(u => u.Roles).ToList();
            
        }

        public async Task<User> UpdateRole(string id, string role)
        {
            var user =  await _userManager.FindByIdAsync(id);

            if (!(await _userManager.IsInRoleAsync(user, "Admin")))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
            }
                
            return user;
        }

    }
}
