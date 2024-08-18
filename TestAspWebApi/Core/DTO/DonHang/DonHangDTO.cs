using Core.DTO.Task;

namespace Core.DTO.DonHang
{
    public class DonHangDTO
    {
        public int MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public string ProductName { get; set; } = string.Empty;

        // danh sách các công việc
        public IEnumerable<TaskDTO> CongViec { get; set; } = new List<TaskDTO>() { };

    }
}
