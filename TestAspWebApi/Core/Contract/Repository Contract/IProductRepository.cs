using Core.DTO.Productdto;
using Core.Models;


namespace Core.Contract.Repository_Contract
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreatAsycn(Product product);
        Task<Product?> UpdateAsycn(int id,ProductDTO productUpdateRequest);
        Task<Product?> DeleteAsycn(int id);
        Task<Product?> GetProductByIdAsync(int id);

        Task<IEnumerable<Product>> GetPagedProductsAsync(int pageNumber, int pageSize);
        Task<int> GetTotalProductsCountAsync();
    }
}
