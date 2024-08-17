using Core.Contract.Repository_Contract;
using Core.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Respository
{
    public class CategoryRepository : ICategogyRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreatAsycn(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsycn(int id)
        {
            Category category = await GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            Category? category = await _context.Categories.Include(c => c.Product).FirstOrDefaultAsync(c => c.CategoryId == id);
            return category;
        }

        public Task<Category> UpdateAsycn(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
