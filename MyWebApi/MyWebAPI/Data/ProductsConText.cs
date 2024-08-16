using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class ProductsConText : DbContext
    { 
        public ProductsConText(DbContextOptions<ProductsConText> db): base(db) 
        {
        }
        #region
        public DbSet<Products>? Products { get; set;}
        #endregion
    }
}
