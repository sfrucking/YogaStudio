using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaStudio.Models
{
    [Table("lessons")]
    public class Lesson
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public double Price { get; set; }

        public List<Subscription> Subscriptions { get; set; }
    }
}
