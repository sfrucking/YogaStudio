using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace YogaStudio.Models
{
    public class Role : IdentityRole
    {
        public List<UserRole> Users { get; set; }
    }
}
