using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YogaStudio.Models;

namespace YogaStudio.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        
        public DbSet<Role> AppRoles { get; set; }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(u => u.UserSubscriptions)
                .WithOne(s => s.User);

            builder.Entity<Subscription>()
                .HasMany(u => u.UserSubscriptions)
                .WithOne(s => s.Subscription);

            builder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithOne(e => e.User)
                .HasForeignKey(u => u.UserId);

            builder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Role)
                .HasForeignKey(r => r.RoleId);

            builder.Entity<Subscription>()
                .HasMany(s => s.Lessons)
                .WithMany(s => s.Subscriptions);

            builder.Entity<UserSubscription>()
                .HasKey(x => new { x.UserId, x.SubscriptionId });

            builder.Entity<UserSubscription>().HasIndex(x => x.UserId).IsUnique();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseNpgsql("server=localhost;userid=postgres;database=YogaStudio;password=Cavoletto135;");
        }

    }
}
