using Core.Contract.Services_Contract;
using Core.Models;

namespace Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
