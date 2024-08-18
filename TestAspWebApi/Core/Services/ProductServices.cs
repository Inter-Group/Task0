using Core.Contract.Services_Contract;
using Core.Models;



namespace Core.Services
{
    public class ProductServices : IProductServices
    {
         private readonly List<Product> _products = new List<Product>();
         private readonly List<Category> _categories = new List<Category>();
        
         public async Task<IEnumerable<Product>> GetAllProducts()
         {
             return await Task.FromResult(_products);
         }
        
         public async Task<Product?> GetProductById(int id)
         {
             var product = _products.FirstOrDefault(p => p.ProductId == id);
             return await Task.FromResult(product);
         }
        
         public async Task<bool> CreateProduct(Product product)
         {
             _products.Add(product);
             return await Task.FromResult(true);
         }
        
         public async Task<bool> UpdateProduct(int id, Product productUpdateRequest)
         {
             var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
             if (existingProduct != null)
             {
                 _products.Remove(existingProduct);
                 _products.Add(productUpdateRequest);
                 return await Task.FromResult(true);
             }
             return await Task.FromResult(false);
         }
        
         public async Task<bool> DeleteProduct(int id)
         {
             var product = _products.FirstOrDefault(p => p.ProductId == id);
             if (product != null)
             {
                 _products.Remove(product);
                 return await Task.FromResult(true);
             }
             return await Task.FromResult(false);
         }
        
         public async Task<IEnumerable<Category>> GetCategories()
         {
             return await Task.FromResult(_categories);
         }
    }
}
