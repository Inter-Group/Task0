using Core.Contract.Repository_Contract;
using Core.DTO.Productdto;
using Core.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Respository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreatAsycn(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> DeleteAsycn(int id)
        {
            Product product = await GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            Product? product = await _context.Products.Include(p => p.DonHang).FirstOrDefaultAsync(p => p.ProductId == id);
            
            return product;
        }

        public async Task<Product?> UpdateAsycn(int id, ProductDTO productUpdateRequest)
        {
            Product product = await GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            product.ProductName = productUpdateRequest.ProductName;
            product.CategoryId = productUpdateRequest.CategoryId;
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .FirstOrDefaultAsync(d => d.ProductId == id);
        }
        public async Task<IEnumerable<Product>> GetPagedProductsAsync(int pageNumber, int pageSize)
        {
            return await _context.Products
                .Include(c => c.DonHang)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalProductsCountAsync()
        {
            return await _context.Products.CountAsync();
        }
    }
}
