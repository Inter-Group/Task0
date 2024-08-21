using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.DTO.Productdto;
using Core.DTO.Task;
using Core.Mapper;
using Core.Models;



namespace Core.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;
        public ProductServices(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repository.GetAllAsync();
        }
        
        public async Task<Product?> GetProductById(int id)
        {
            Product? product = await _repository.GetByIdAsync(id);
            return product;
        }
        
        public async Task<bool> CreateProduct(Product product)
        {
            Product pro = await _repository.CreatAsycn(product);
            return true;
        }
        
        public async Task<bool> UpdateProduct(int id, ProductDTO productUpdateRequest)
        {
            Product? existingProduct = await _repository.GetByIdAsync(id);
            if (existingProduct != null)
            {
                await _repository.UpdateAsycn(id, productUpdateRequest);
                return true;
            }
            return false;
        }
        
        public async Task<bool> DeleteProduct(int id)
        {
            Product? product = await _repository.DeleteAsycn(id);
            if (product != null)
            {

                return true;
            }
            return false;
        }
        public async Task<int> GetTotalProductsCountAsync()
        {
            return await _repository.GetTotalProductsCountAsync();
        }
        public async Task<IEnumerable<ProductDTO>> GetPagedProductsAsync(int pageNumber, int pageSize)
        {
            var products = await _repository.GetPagedProductsAsync(pageNumber, pageSize);
            return products.Select(products => products.toProductDTO());
        }
    }
}

