using MyWebAPI.Models;

namespace MyWebAPI.Repositories
{
    public interface IRepository
    {
        public Task<List<ProductsModel>> GetALLAsync();
        public Task<ProductsModel> GetALLByIDAsync(int id);
        public Task<int> AddAsync(ProductsModel model);
        public Task UpdateAsync(int id, ProductsModel model);

        public Task DeleteAsync(int id);
    }
}
