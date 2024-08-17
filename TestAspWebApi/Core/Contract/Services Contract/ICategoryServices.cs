using Core.Models;


namespace Core.Contract.Services_Contract
{
    public interface ICategoryServices
    {
        public Task<IEnumerable<Category>> GetCategories();

    }
}
