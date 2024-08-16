//Models dùng để hiển thị thông tin mình muốn hiển thị thay vì hiển thị hết giống bên Data
using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Models
{
    public class ProductsModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
