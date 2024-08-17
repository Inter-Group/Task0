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
        [Key]
        public int MaCongViec { get; set; }
        public string TenCongViec { get; set; } = string.Empty;
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
       
        public DonHang? DonHang { get; set; }
    }
}
