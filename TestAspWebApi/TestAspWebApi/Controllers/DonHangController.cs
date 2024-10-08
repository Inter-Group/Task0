﻿using Core.Contract.Services_Contract;
using Core.DTO.Categorydto;
using Core.DTO.DonHangdto;
using Core.Mapper;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "XuongTruong,Admin")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly IDonHangServices _donHangServices;
        private readonly IProductServices _productServices;


        public DonHangController(IDonHangServices donHangServices, IProductServices productServices)
        {
            _donHangServices = donHangServices;
            _productServices = productServices;
        }

        // GET: api/DonHang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonHangDTO>>> GetAllDonHangs([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                // Lấy danh sách tasks phân trang
                var tasks = await _donHangServices.GetPagedDonHangAsync(pageNumber, pageSize);

                // Lấy tổng số lượng tasks
                var totalTasksCount = await _donHangServices.GetTotalDonHangCountAsync();

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
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromQuery] DonHangAddRequest donhangCreateRequest)
        {
            bool isAdded = await _donHangServices.CreateTaskAsync(donhangCreateRequest.AddrequestToDonHang());
            if (!isAdded)
            {
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/DonHang/{id}
        [HttpPost("[Action]")]
        public async Task<IActionResult> UpdateDonHang([FromQuery] DonHangUpdateRequest donhangUpdateRequest, [FromQuery] int MaDonHang)
        {
            bool isUpdated = await _donHangServices.UpdateTaskAsync(MaDonHang, donhangUpdateRequest);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
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
