using Core.Contract.Services_Contract;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductServices : IProductServices
    {
        public Task<bool> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(int id, Product productUpdaterequest)
        {
            throw new NotImplementedException();
        }
    }
}
