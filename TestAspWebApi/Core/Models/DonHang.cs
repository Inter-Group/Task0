using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class DonHang
    {
        public int ProductId { get; set; }
        public int MaDonHang {  get; set; }
        public int SoLuong { get; set; }
        public Product? Product { get; set; }
        public IEnumerable<CongViec> CongViec { get; set; } = new List<CongViec>() { };
    }
}
