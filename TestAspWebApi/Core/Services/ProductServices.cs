using Core.Contract.Services_Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
       public class ProductServices : IProductServices
    {
        private readonly List<Product> _products = new List<Product>();
        private readonly List<Category> _categories = new List<Category>();

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            return await Task.FromResult(product);
        }

        public async Task AddProductAsync(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
                _products.Add(product);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            await Task.CompletedTask;
        }

        // Triển khai các phương thức thiếu
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            return await Task.FromResult(product);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Task.FromResult(_categories);
        }
    }
}
