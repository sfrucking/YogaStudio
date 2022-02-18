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
        public double Price { get; set; }
        public string Type { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<UserSubscription> UserSubscriptions { get; set; }
        
    }
}
