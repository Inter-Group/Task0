using Microsoft.EntityFrameworkCore;
using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Infrastructure.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
       public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<CongViec> congViecs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin"
                    ,NormalizedName = "ADMIN"

                },
                new IdentityRole
                {
                    Name = "User"
                    ,NormalizedName = "USER"

                },
                new IdentityRole
                {
                    Name = "XuongTruong"
                    ,NormalizedName = "XUONGTRUONG"

                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
