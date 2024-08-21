using Core.Contract.Services_Contract;
using Core.DTO.Task;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "XuongTruong,Admin")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/task
        [HttpGet]
        public async Task<IActionResult> GetAllTasks([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                // Lấy danh sách tasks phân trang
                var tasks = await _taskService.GetPagedTasksAsync(pageNumber, pageSize);

                // Lấy tổng số lượng tasks
                var totalTasksCount = await _taskService.GetTotalTasksCountAsync();

                // Tạo response phân trang
                var response = new
                {
                    TotalCount = totalTasksCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Tasks = tasks
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/task/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var task = await _taskService.GetTaskByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/task
        [HttpPost("Create")]
        public async Task<IActionResult> CreateTask([FromBody] TaskDTO taskDto)
        {
            if (taskDto == null)
            {
                return BadRequest("Task không có dữ liệu");
            }
            if (taskDto.Start.TimeOfDay < new TimeSpan(7, 0, 0) || taskDto.End.TimeOfDay > new TimeSpan(17, 0, 0) || taskDto.End.TimeOfDay <= taskDto.Start.TimeOfDay)
            {
                throw new ArgumentException("Thời gian làm việc phải từ 7h sáng đến 5h chiều");
            }

            try
            {
                var createdTask = await _taskService.CreateTaskAsync(taskDto);
                return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.MaCongViec }, createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/task/{id}
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDTO taskDto)
        {
            if (taskDto == null || id != taskDto.MaCongViec)
            {
                return BadRequest("Không tìm thấy công việc");
            }
            if (taskDto.Start.TimeOfDay < new TimeSpan(7, 0, 0) || taskDto.End.TimeOfDay > new TimeSpan(17, 0, 0) || taskDto.End.TimeOfDay <= taskDto.Start.TimeOfDay)
            {
                throw new ArgumentException("Thời gian làm việc phải từ 7h sáng đến 5h chiều");
            }

            try
            {
                var updatedTask = await _taskService.UpdateTaskAsync(taskDto);
                if (updatedTask == null)
                {
                    return NotFound();
                }

                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/task/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var success = await _taskService.DeleteTaskAsync(id);
                if (!success)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
