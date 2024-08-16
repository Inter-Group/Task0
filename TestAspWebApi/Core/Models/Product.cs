using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product
    {
        public int CategoryId {  get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public IEnumerable<DonHang> DonHang { get; set; } = new List<DonHang>() { };
    }
}
