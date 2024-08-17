using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CatgegoryName { get; set; } = string.Empty;
        public IEnumerable<Product> Product { get; set; } = new List<Product>() { };
    }
}
