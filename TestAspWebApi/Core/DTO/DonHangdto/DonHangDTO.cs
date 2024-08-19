using Core.DTO.Categorydto;
using Core.DTO.Task;
using Core.Models;

namespace Core.DTO.DonHangdto
{
    public class DonHangDTO
    {
        public int MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public int ProductID { get; set; } // Đảm bảo thuộc tính này có mặt

        // danh sách các công việc
        //public IEnumerable<TaskDTO> CongViec { get; set; } = new List<TaskDTO>() { };

    }
    public static class DonHangExtension
    {
        public static DonHang AddrequestToDonHang(this DonHangAddRequest request)
        {
            return new DonHang
            {
                SoLuong = request.SoLuong,
                Product = new Product { ProductId = request.ProductID } // Tạo đối tượng Product với ProductID
            };
        }

        public static DonHang UpdaterequestToDonHang(this DonHangUpdateRequest request)
        {
            return new DonHang
            {
                SoLuong = request.SoLuong,
                Product = new Product { ProductId = request.ProductID } // Tạo đối tượng Product với ProductID
            };
        }
    }
}
