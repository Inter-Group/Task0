using Core.Models;
using Core.DTO.DonHangdto;

namespace Core.Contract.Services_Contract
{
    public interface IDonHangServices
    {
        public Task<IEnumerable<DonHangDTO>> GetAllTasksAsync();
        public Task<DonHangDTO?> GetTaskByIdAsync(int id);
        public Task<bool> CreateTaskAsync(DonHang donHang);

        public Task<bool> UpdateTaskAsync(int MaDonHang, DonHangUpdateRequest donhangUpdaterequest);

        public Task<bool> DeleteTaskAsync(int id);
    }
}
