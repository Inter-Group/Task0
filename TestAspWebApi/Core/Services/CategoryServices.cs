using Core.Contract.Services_Contract;
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
        public Task<IEnumerable<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
