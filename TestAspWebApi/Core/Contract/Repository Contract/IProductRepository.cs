using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Contract.Repository_Contract
{
    public interface IProductRepository
    {
        Task<Product> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreatAsycn(Product product);
        Task<Product> UpdateAsycn(Product product);
        Task<Product> DeleteAsycn(int id);
    }
}
