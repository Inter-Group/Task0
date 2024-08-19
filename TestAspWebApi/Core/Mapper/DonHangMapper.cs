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
                ProductID = donHang.Product?.ProductId ?? 0, // Giả sử ProductID là thuộc tính của Product
                //CongViec = donHang.CongViec?.Select(c => new TaskDTO
                //{
                //    MaCongViec = c.MaCongViec // Chỉ lấy mã công việc
                //}) ?? new List<TaskDTO>()
            };
        }
        // Chuyển đổi từ DonHangDTO sang DonHang

        public static DonHang DonHangFromDTO(this DonHangDTO donHangDTO)
        {
            return new DonHang
            {
                MaDonHang = donHangDTO.MaDonHang,
                SoLuong = donHangDTO.SoLuong,
                ProductId = donHangDTO.ProductID ,
                // Khởi tạo Product nếu cần, giả sử có ProductID trong DonHangDTO
                //Product = new Product { ProductId = donHangDTO.ProductID ?? 0 } // Hoặc sử dụng ProductID nếu không cần đối tượng Product
                //CongViec = donHangDTO.CongViec?.Select(t => new CongViec
                //{
                //    MaCongViec = t.MaCongViec // Khởi tạo công việc với mã công việc
                //}) ?? new List<CongViec>()
            };
        }
    }
}
