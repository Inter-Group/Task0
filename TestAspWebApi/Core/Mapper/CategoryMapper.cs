using Core.DTO.Category;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public static class CategoryMapper
    {
        static CategoryDTO toCategoryDTO(this Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CatgegoryName = category.CatgegoryName,
                Products = category.Product.Select(p => p.toProductDTO()).ToList()
            };
        }
        static Category CategoryFromDTO(this CategoryDTO categoryDTO)
        {
            return new Category { CatgegoryName = categoryDTO.CatgegoryName };
        }
    }
}
