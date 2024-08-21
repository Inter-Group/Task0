using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.DonHangdto
{
    public class DonHangUpdateRequest
    {
        //public int MaDonHang { get; set; }

        public int SoLuong { get; set; } 
        public int ProductId { get; set; } // Đảm bảo thuộc tính này có mặt

    }
}
