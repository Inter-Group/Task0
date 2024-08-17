namespace Core.DTO.Task
{
    public class TaskDTO
    {
        public int MaCongViec { get; set; }                   
        public string TenCongViec { get; set; } = string.Empty; 
        public DateTime Start { get; set; }                   
        public DateTime End { get; set; }                      
        public int? MaDonHang { get; set; }
    }
}
