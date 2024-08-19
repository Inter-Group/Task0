    using Core.Contract.Repository_Contract;
    using Core.Contract.Services_Contract;
    using Core.DTO.Task;
    using Core.Mapper;
    using Core.Models;

    namespace Core.Services
    {
        public class TaskServices : ITaskService
        {
            private readonly ITaskRepository _taskRepository;

            public TaskServices(ITaskRepository taskRepository) 
            {
                _taskRepository = taskRepository;
            }
        public async Task<TaskDTO> CreateTaskAsync(TaskDTO taskDto)
        {
            var task = taskDto.FromTaskDTO();

            // Kiểm tra điều kiện thời gian
            if (task.Start.TimeOfDay < new TimeSpan(7, 0, 0) || task.End.TimeOfDay > new TimeSpan(17, 0, 0) || task.End.TimeOfDay <= task.Start.TimeOfDay)
            {
                throw new ArgumentException("Thời gian làm việc phải từ 7h sáng đến 5h chiều");
            }

            // Kiểm tra xem DonHang có tồn tại không
            if (taskDto.MaDonHang.HasValue)
            {
                var existingDonHang = await _taskRepository.GetDonHangByIdAsync(taskDto.MaDonHang.Value);
                if (existingDonHang == null)
                {
                    throw new ArgumentException("Mã đơn hàng không hợp lệ");
                }

                // Tạo đối tượng DonHang và gán nó vào task
                task.DonHang = existingDonHang;
            }

            // Thêm nhiệm vụ mới vào cơ sở dữ liệu
            var createdTask = await _taskRepository.AddAsync(task);
            return createdTask.ToTaskDTO();
        }


        public async Task<bool> DeleteTaskAsync(int id)
            {
                return await _taskRepository.DeleteAsync(id);
            }

            public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
            {
                var tasks = await _taskRepository.GetAllAsync();
                return tasks.Select(task => task.ToTaskDTO());
            }

            public async Task<TaskDTO?> GetTaskByIdAsync(int id)
            {
                var task = await _taskRepository.GetByIdAsync(id);
                return task?.ToTaskDTO();
            }

            public async Task<int> GetTotalTasksCountAsync()
            {
                return await _taskRepository.GetTotalTasksCountAsync();
            }

        public async Task<TaskDTO?> UpdateTaskAsync(TaskDTO taskDto)
        {
            // Chuyển đổi DTO thành mô hình
            var task = taskDto.FromTaskDTO();

            // Kiểm tra điều kiện thời gian
            if (task.Start.TimeOfDay < new TimeSpan(7, 0, 0) || task.End.TimeOfDay > new TimeSpan(17, 0, 0) || task.End.TimeOfDay <= task.Start.TimeOfDay)
            {
                throw new ArgumentException("Thời gian làm việc phải từ 7h sáng đến 5h chiều");
            }

            // Kiểm tra xem DonHang có tồn tại không
            if (taskDto.MaDonHang.HasValue)
            {
                var existingDonHang = await _taskRepository.GetDonHangByIdAsync(taskDto.MaDonHang.Value);
                if (existingDonHang == null)
                {
                    throw new ArgumentException("Mã đơn hàng không hợp lệ");
                }
                else
                {
                    // Cập nhật DonHang trong CongViec
                    task.DonHang = existingDonHang;
                }
            }
            else
            {
                // Nếu không có MaDonHang, đảm bảo DonHang là null
                task.DonHang = null;
            }

            // Cập nhật nhiệm vụ trong cơ sở dữ liệu
            var updatedTask = await _taskRepository.UpdateAsync(task);
            return updatedTask?.ToTaskDTO();
        }

        public async Task<IEnumerable<TaskDTO>> GetPagedTasksAsync(int pageNumber, int pageSize)
            {
                var tasks = await _taskRepository.GetPagedTasksAsync(pageNumber, pageSize);
                return tasks.Select(task => task.ToTaskDTO());
            }
        }
    }
