using Core.DTO.Productdto;
using Core.Models;


namespace Core.DTO.Categorydto
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<ProductDTO> Products { get; set; }
    }
    public static class CategoryExtension
    {
        public static Category AddrequestToCategory(this CategoryAddRequest request)
        {
            return new Category { CatgegoryName = request.CatgegoryName };
        }

        public static Category UpdaterequestToCategory (this CategoryUpdateRequest request)
        {
            return new Category { CatgegoryName = request.CatgegoryName };
        }
    }
}
