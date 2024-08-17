using Core.Contract.Repository_Contract;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respository
{
    public class CategoryRepository : ICategogyRepository
    {
        public Task<Category> CreatAsycn(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> DeleteAsycn(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsycn(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
