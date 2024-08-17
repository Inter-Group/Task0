using Core.Contract.Repository_Contract;
using Core.DTO.Product;
using Core.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
