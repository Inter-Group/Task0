using Core.DTO.DonHangdto;
using Core.DTO.Task;
using Core.Models;


namespace Core.Mapper
{
    public static class DonHangMapper
    {
        //Chuyen tu DonHang Sang DonHangDTO
        public static DonHangDTO ToDonHangDTO(this DonHang donHang)
        {
            return new DonHangDTO
            {
                MaDonHang = donHang.MaDonHang,
                SoLuong = donHang.SoLuong,
                ProductId = donHang.ProductId, // Thiết lập trực tiếp ProductId

            };
        }
        // Chuyển đổi từ DonHangDTO sang DonHang

        public static DonHang DonHangFromDTO(this DonHangDTO donHangDTO)
        {
            return new DonHang
            {
                MaDonHang = donHangDTO.MaDonHang,
                SoLuong = donHangDTO.SoLuong,
                ProductId = donHangDTO.ProductId // Thiết lập trực tiếp ProductId
            };
        }
    }
}
