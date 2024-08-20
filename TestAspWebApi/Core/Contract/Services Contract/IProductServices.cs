using Core.DTO.Productdto;
using Core.Models;
namespace Core.Contract.Services_Contract
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product?> GetProductById(int id);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProduct(int id, ProductDTO productUpdaterequest);
        public Task<bool> CreateProduct(Product product);
        Task<int> GetTotalProductsCountAsync();
        Task<IEnumerable<ProductDTO>> GetPagedProductsAsync(int pageNumber, int pageSize);
    }
}
