using Ecommerce.Core.Entities.ApplicationUser;
using Ecommerce.Core.Entities.Enum;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.EF_Core.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var adminUser = new ApplicationUser()
        {
            UserId = Guid.Parse("F8F7F461-C4B1-47B2-AA32-3BA2FD60A78C"),
            Email = "admin@admin.com",
            PersonName = "ADMIN",
            Gender = Gender.Male,
            Password = "AQAAAAIAAYagAAAAEFZQnhI8ku0uS/GpshO+/kDPvpQkb2MzY9WEq9imw8HWQeOSYFxSywgU6PFE23i2dg=="
        };

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
        base.OnModelCreating(modelBuilder);
    }
}