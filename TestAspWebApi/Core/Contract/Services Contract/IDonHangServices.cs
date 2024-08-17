using Core.Models;
using Core.DTO.DonHang;

namespace Core.Contract.Services_Contract
{
    public interface IDonHangServices
    {
        Task<IEnumerable<DonHangDTO>> GetAllTasksAsync();
        Task<DonHangDTO?> GetTaskByIdAsync(int id);
        Task<DonHangDTO> CreateTaskAsync(DonHangDTO taskDto);
        Task<DonHangDTO?> UpdateTaskAsync(DonHangDTO taskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
