using Core.DTO.Task;
using Core.Models;


namespace Core.Mapper
{
    public static class TaskMapper
    {
        // Chuyển đổi từ CongViec sang TaskDTO
        public static TaskDTO ToTaskDTO(this CongViec congViec)
        {
            return new TaskDTO
            {
                MaCongViec = congViec.MaCongViec,
                TenCongViec = congViec.TenCongViec,
                Start = congViec.Start,
                End = congViec.End,
                MaDonHang = congViec.DonHang?.MaDonHang
            };
        }

        // Chuyển đổi từ TaskDTO sang CongViec
        public static CongViec FromTaskDTO(this TaskDTO taskDTO)
        {
            return new CongViec
            {
                MaCongViec = taskDTO.MaCongViec,
                TenCongViec = taskDTO.TenCongViec,
                Start = taskDTO.Start,
                End = taskDTO.End,
                DonHang = taskDTO.MaDonHang.HasValue ? new DonHang { MaDonHang = taskDTO.MaDonHang.Value } : null
            };
        }
    }
}
