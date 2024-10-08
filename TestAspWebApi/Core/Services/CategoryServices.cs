﻿using Core.Contract.Services_Contract;
﻿using Core.Contract.Repository_Contract;
using Core.DTO.Categorydto;
using Core.Models;
using Core.DTO.Task;
using Core.Mapper;


namespace Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategogyRepository _categogyRepository;
        public CategoryServices(ICategogyRepository categogyRepository)
        {
            _categogyRepository = categogyRepository;
        }
        public async Task<bool> CreateCategory(Category category)
        {
           Category categoryTemp = await _categogyRepository.CreatAsycn(category);
            if (categoryTemp == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
           Category? category = await _categogyRepository.DeleteAsycn(id);
            if (category == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            IEnumerable<Category> categories = await _categogyRepository.GetAllAsync();
            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            Category? category = await _categogyRepository.GetByIdAsync(id);
           return category;
        }

        public async Task<bool> UpdateCategory(int id, CategoryUpdateRequest categoryUpdaterequest)
        {
           Category? category = await  _categogyRepository.UpdateAsycn(id, categoryUpdaterequest);
            if (category == null)
            {
                return false;
            }
            return true;
        }
        public async Task<int> GetTotalCategoriesCountAsync()
        {
            return await _categogyRepository.GetTotalCategoriesCountAsync();
        }
        public async Task<IEnumerable<CategoryDTO>> GetPagedCategoryAsync(int pageNumber, int pageSize)
        {
            var categories = await _categogyRepository.GetPagedCategoryAsync(pageNumber, pageSize);
            return categories.Select(c=> c.toCategoryDTO());
        }

       

     
    }
}
