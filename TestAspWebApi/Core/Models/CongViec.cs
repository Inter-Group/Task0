using System.ComponentModel.DataAnnotations;


namespace Core.Models
{
    public class CongViec
    {
        [Key]
        public int MaCongViec { get; set; }
        public string TenCongViec { get; set; } = string.Empty;
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }
       
        public DonHang? DonHang { get; set; }
    }
}
