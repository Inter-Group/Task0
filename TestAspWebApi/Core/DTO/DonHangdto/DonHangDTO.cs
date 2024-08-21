using Core.DTO.Categorydto;
using Core.DTO.Task;
using Core.Models;

namespace Core.DTO.DonHangdto
{
    public class DonHangDTO
    {
        public int MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public int ProductId { get; set; } // Đảm bảo thuộc tính này có mặt

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
                ProductId = request.ProductId // Thiết lập trực tiếp ProductId
            };
        }

        public static DonHang UpdaterequestToDonHang(this DonHangUpdateRequest request)
        {
            return new DonHang
            {
                SoLuong = request.SoLuong,
                ProductId = request.ProductId // Thiết lập trực tiếp ProductId
            };
        }
    }
}
