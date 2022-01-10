using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaStudio.Models
{
    [Table("subscriptions")]
    public class Subscription
    {
        [Column("id")]
        public int Id { get; set; }
        //all iscrizione aggiungo 30 a expiring
        public DateTime SubscriptionExpiringDate { get; set; }
        //nel momento in cui si iscrive .now
        public DateTime SubInit { get; set; }
        private bool isValid;
        public bool IsValid { get => isValid; set { if (SubscriptionExpiringDate > SubInit) value = false; } }
        public List<Lesson> Lessons { get; set; }
        public List<User> Users { get; set; }
        
    }
}
