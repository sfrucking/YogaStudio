using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YogaStudio.Models
{
    
    public class User : IdentityUser
    {
        public List<UserRole> Roles { get; set; }  
        public Subscription Subscription { get; set; }
    }
}
