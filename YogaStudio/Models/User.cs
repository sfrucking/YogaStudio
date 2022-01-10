using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaStudio.Models
{
    
    public class User : IdentityUser
    {
        public List<IdentityUserRole<string>> Roles { get; set; }   
        public Subscription Subscription { get; set; }
    }
}
