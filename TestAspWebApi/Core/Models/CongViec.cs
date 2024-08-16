using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CongViec
    {
        public int MaDonHang { get; set; }
        public int MaCongViec { get; set; }
        public string TenCongViec { get; set; } = string.Empty;
        public DonHang? DonHang { get; set; }
    }
}
