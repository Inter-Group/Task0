using Core.Contract.Repository_Contract;
using Core.DTO.Categorydto;
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

        public async Task<Category?> DeleteAsycn(int id)
        {
            Category category = await GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            Category? category = await _context.Categories.Include(c => c.Product).FirstOrDefaultAsync(c => c.CategoryId == id);
            return category;
        }

       

        public async Task<Category?> UpdateAsycn(int id,CategoryUpdateRequest categoryUpdateRequest)
        {
           Category category = await GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
           category.CatgegoryName = categoryUpdateRequest.CatgegoryName;
            await _context.SaveChangesAsync();
            return category;
        }

         public async Task<IEnumerable<Category>> GetPagedCategoryAsync(int pageNumber, int pageSize)
        {
            return await _context.Categories
                .Include(c => c.Product)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCategoriesCountAsync()
        {
            return await _context.Categories.CountAsync();
        }

      
    }
}
