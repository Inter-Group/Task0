using Core.Contract.Services_Contract;
using Core.DTO.DonHang;
using Microsoft.AspNetCore.Mvc;

namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangServices _donHangServices;

        public DonHangController(IDonHangServices donHangServices)
        {
            _donHangServices = donHangServices;
        }

        // GET: api/DonHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonHangDTO>>> GetAllDonHangs()
        {
            var donHangs = await _donHangServices.GetAllTasksAsync();
            return Ok(donHangs);
        }

        // GET: api/DonHang/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<DonHangDTO?>> GetDonHangById(int id)
        {
            var donHang = await _donHangServices.GetTaskByIdAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            return Ok(donHang);
        }

        // POST: api/DonHang
        [HttpPost]
        public async Task<ActionResult<DonHangDTO>> CreateDonHang([FromBody] DonHangDTO donHangDto)
        {
            try
            {
                var createdDonHang = await _donHangServices.CreateTaskAsync(donHangDto);
                return CreatedAtAction(nameof(GetDonHangById), new { id = createdDonHang.MaDonHang }, createdDonHang);
            }
            catch (InvalidOperationException ex)
            {
                // If an unfinished task exists, return a bad request with a meaningful message.
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/DonHang/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<DonHangDTO?>> UpdateDonHang(int id, [FromBody] DonHangDTO donHangDto)
        {
            if (id != donHangDto.MaDonHang)
            {
                return BadRequest("ID mismatch.");
            }

            var updatedDonHang = await _donHangServices.UpdateTaskAsync(donHangDto);
            if (updatedDonHang == null)
            {
                return NotFound();
            }
            return Ok(updatedDonHang);
        }

        // DELETE: api/DonHang/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDonHang(int id)
        {
            var isDeleted = await _donHangServices.DeleteTaskAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
