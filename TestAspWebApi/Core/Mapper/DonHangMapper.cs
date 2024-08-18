using Core.DTO.DonHang;
using Core.DTO.Task;
using Core.Models;


namespace Core.Mapper
{
    public static class DonHangMapper
    {
        //Chuyen tu DonHang Sang DonHangDTO
        public static DonHangDTO toDonHangDTO(this DonHang donhang)
        {
            return new DonHangDTO
            {
                MaDonHang = donhang.MaDonHang,
                SoLuong = donhang.SoLuong,
                ProductName = donhang.Product?.ProductName ?? string.Empty,
                CongViec = donhang.CongViec.Select(cv => new TaskDTO
                {
                    MaCongViec = cv.MaCongViec,
                    TenCongViec = cv.TenCongViec,
                    Start = cv.Start,
                    End = cv.End
                }).ToList()
            };
        }
        // Chuyển đổi từ DonHangDTO sang DonHang

        public static DonHang DonHangFromDTO(this DonHangDTO donhangDTO)
        {
            return new DonHang
            {
                MaDonHang = donhangDTO.MaDonHang,
                SoLuong = donhangDTO.SoLuong,
                Product = string.IsNullOrWhiteSpace(donhangDTO.ProductName) ? null : new Product { ProductName = donhangDTO.ProductName },
                CongViec = donhangDTO.CongViec.Select(cv => new CongViec
                {
                    MaCongViec = cv.MaCongViec,
                    TenCongViec = cv.TenCongViec,
                    Start = cv.Start,
                    End = cv.End
                }).ToList()
            };
        }
    }
}
