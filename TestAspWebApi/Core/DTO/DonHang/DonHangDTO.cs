using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO.Product;
using Core.Models;

namespace Core.DTO.DonHang
{
    public class DonHangDTO
    {
        public int MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public int? ProductId { get; set; }

    }
}
