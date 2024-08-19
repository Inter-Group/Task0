using Core.DTO.Task;
using Core.Models;


namespace Core.Contract.Services_Contract
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO?> GetTaskByIdAsync(int id);
        Task<TaskDTO> CreateTaskAsync(TaskDTO taskDto);
        Task<TaskDTO?> UpdateTaskAsync(TaskDTO taskDto);
        Task<bool> DeleteTaskAsync(int id);

        // Phân trang
        Task<IEnumerable<TaskDTO>> GetPagedTasksAsync(int pageNumber, int pageSize);

        // Tổng số Task
        Task<int> GetTotalTasksCountAsync();
    }
}
