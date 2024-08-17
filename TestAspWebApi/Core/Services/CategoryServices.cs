using Core.Contract.Services_Contract;
using Core.DTO.Category;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        public Task<bool> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategory(int id, CategoryDTO categoryUpdaterequest)
        {
            throw new NotImplementedException();
        }
    }
}
