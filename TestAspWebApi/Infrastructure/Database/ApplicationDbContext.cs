using Microsoft.EntityFrameworkCore;
using Core.Models;
namespace Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
       public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<CongViec> congViecs { get; set; }
    }
}
