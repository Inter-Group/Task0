using Core.DTO.Productdto;
using Core.Models;
namespace Core.Contract.Services_Contract
{
    public interface IProductServices
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product?> GetProductById(int id);
        public Task<bool> DeleteProduct(int id);
        public Task<bool> UpdateProduct(int id, ProductUpdateRequest productUpdaterequest);
        public Task<bool> CreateProduct(ProductAddRequest productAddrequest);
        Task<int> GetTotalProductsCountAsync();
        Task<IEnumerable<ProductDTO>> GetPagedProductsAsync(int pageNumber, int pageSize);
    }
}
