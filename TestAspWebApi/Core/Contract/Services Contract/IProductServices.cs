using Core.Models;
namespace Core.Contract.Services_Contract
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product?> GetProductById(int id);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProduct(int id, Product productUpdaterequest);
        public Task<bool> CreateProduct(Product product);
    }
}
