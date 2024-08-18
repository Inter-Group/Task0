
using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public IEnumerable<DonHang> DonHang { get; set; } = new List<DonHang>() { };
    }
}
