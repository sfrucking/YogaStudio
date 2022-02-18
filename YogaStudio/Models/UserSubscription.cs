using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaStudio.Models
{
    [Table("UserSubscription")]
    public class UserSubscription
    {
        private bool isValid;
        public DateTime SubscriptionExpiringDate { get; set; }
        //nel momento in cui si iscrive .now
        public DateTime SubInit { get; set; }
        public bool IsValid { get => isValid; set { if (SubscriptionExpiringDate < SubInit) value = false; } }
        public User User { get; set; }
        public Subscription Subscription { get; set; }
        public string UserId { get; set; }
        public int SubscriptionId { get; set; }

    }
}
