using Core.Contract.Repository_Contract;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respository
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> CreatAsycn(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> DeleteAsycn(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsycn(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
