using Core.DTO.Product;


namespace Core.DTO.Category
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<ProductDTO>? Products { get; set; }
    }
}
