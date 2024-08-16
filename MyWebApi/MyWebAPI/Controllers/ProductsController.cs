//Tạo từ API Controller để tự tạo API cho riêng mình
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using MyWebAPI.Models;
using MyWebAPI.Repositories;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProductsController(IRepository repo) 
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> LayTatCa()
        {
            try 
            {
                return Ok(await _repo.GetALLAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> LayTheoMa(int id)
        {
            var getID = await _repo.GetALLByIDAsync(id);
            return getID == null ? NotFound() : Ok(getID);
        }

        [HttpPost]
        public async Task<IActionResult> Them(ProductsModel model)
        {
            try
            {
                var newID = await _repo.AddAsync(model);
                var getID = await _repo.GetALLByIDAsync(newID);
                return getID == null ? NotFound() : Ok(getID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Sua(int id, ProductsModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            await _repo.UpdateAsync(id, model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Xoa(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}
