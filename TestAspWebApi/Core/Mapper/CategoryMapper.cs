using Core.DTO.Categorydto;
using Core.Models;


namespace Core.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryDTO toCategoryDTO(this Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CatgegoryName = category.CatgegoryName,
                Products = category.Product.Select(p => p.toProductDTO()).ToList()
            };
        }
      public  static Category CategoryFromDTO(this CategoryDTO categoryDTO)
        {
            return new Category { CatgegoryName = categoryDTO.CatgegoryName };
        }
    }
}
