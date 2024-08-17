using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract.Repository_Contract
{
    public interface ICategogyRepository
    {

        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreatAsycn(Category category);
        Task<Category> UpdateAsycn(Category category);
        Task<Category> DeleteAsycn(int id);
    }
}
