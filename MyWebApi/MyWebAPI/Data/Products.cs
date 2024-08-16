using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Data
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
    }
}
