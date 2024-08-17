using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.DTO.DonHang;
using Core.Mapper;

namespace Core.Services
{
    internal class DonHangServices : IDonHangServices
    {
        private readonly IDonHangRepository _donhangRepository;

        public DonHangServices(IDonHangRepository donhangRepository)
        {
            _donhangRepository = donhangRepository;

        }
        public async Task<DonHangDTO> CreateTaskAsync(DonHangDTO taskDto)
        {
            // Kiểm tra nếu bất kỳ công việc nào của đơn hàng chưa kết thúc
            bool hasUnfinishedTasks = taskDto.CongViec.Any(task => task.End > DateTime.Now);

            if (hasUnfinishedTasks)
            {
                throw new InvalidOperationException("Không thể tạo đơn hàng mới khi có công việc liên quan chưa hoàn thành.");
            }

            // Nếu tất cả các công việc liên quan đã hoàn thành, tiếp tục tạo đơn hàng

            var task = taskDto.DonHangFromDTO();

            var createdTask = await _donhangRepository.AddAsync(task);
            return createdTask.toDonHangDTO();
        }
        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _donhangRepository.DeleteAsycn(id);
        }

        public async Task<IEnumerable<DonHangDTO>> GetAllTasksAsync()
        {
            var tasks = await _donhangRepository.GetAllAsync();
            return tasks.Select(task => task.toDonHangDTO());
        }

        public async Task<DonHangDTO?> GetTaskByIdAsync(int id)
        {
            var task = await _donhangRepository.GetByIdAsync(id);
            return task?.toDonHangDTO();
        }

        public async Task<DonHangDTO?> UpdateTaskAsync(DonHangDTO taskDto)
        {
            var task = taskDto.DonHangFromDTO();

            var updatedTask = await _donhangRepository.UpdateAsycn(task);
            return updatedTask?.toDonHangDTO();
        }
    }
}
