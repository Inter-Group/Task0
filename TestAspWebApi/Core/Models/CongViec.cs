using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CongViec
    {
        public int MaDonHang { get; set; }
        [Key]
        public int MaCongViec { get; set; }
        public string TenCongViec { get; set; } = string.Empty;
        public TimeOnly Start {  get; set; }
        public TimeOnly End { get; set; }
        public DonHang? DonHang { get; set; }
    }
}
