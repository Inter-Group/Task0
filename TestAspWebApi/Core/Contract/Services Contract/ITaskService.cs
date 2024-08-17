using Core.DTO.Task;


namespace Core.Contract.Services_Contract
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO?> GetTaskByIdAsync(int id);
        Task<TaskDTO> CreateTaskAsync(TaskDTO taskDto);
        Task<TaskDTO?> UpdateTaskAsync(TaskDTO taskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
