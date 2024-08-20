using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Mapper;
using Core.Contract.Services_Contract;
using Core.DTO.Categorydto;
using Core.Services;
namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IProductServices _productServices;
       
        public CategoryController(ICategoryServices cate, IProductServices pro)
        {
            _categoryServices = cate;
            _productServices = pro;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1)
        {
         
            try
            {
                // Lấy danh sách category phân trang
                var cates = await _categoryServices.GetPagedCategoryAsync(pageNumber, pageSize);

                // Lấy tổng số lượng Category
                var totalCatesCount = await _categoryServices.GetTotalCategoriesCountAsync();

                // Tạo response phân trang
                var response = new
                {
                    TotalCount = totalCatesCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Cates = cates
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            Category? category = await _categoryServices.GetCategoryById(Id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.toCategoryDTO());
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromQuery] CategoryAddRequest categoryCreateRequest)
        {
            bool isAdded = await _categoryServices.CreateCategory(categoryCreateRequest.AddrequestToCategory());
            if (!isAdded)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> Updated([FromQuery] CategoryUpdateRequest categoryUpdateRequest, [FromQuery] int id)
        {
            bool isUpdated = await _categoryServices.UpdateCategory(id,categoryUpdateRequest);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }
        [HttpDelete("[Action]")]
        public async Task<IActionResult> Deleted([FromQuery] int id)
        {
            bool isDeleted = await _categoryServices.DeleteCategory(id);
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
