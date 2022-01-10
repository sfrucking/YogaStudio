using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogaStudio.Models;

namespace YogaStudio.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(u => u.Subscription)
                .WithMany(s => s.Users);

            builder.Entity<Subscription>()
                .HasMany(s => s.Lessons)
                .WithMany(s => s.Subscriptions);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseNpgsql("server=localhost;userid=postgres;database=YogaStudio;password=Cavoletto13579;");
        }

    }
}
