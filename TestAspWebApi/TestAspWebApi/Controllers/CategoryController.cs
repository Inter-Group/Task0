using Core.Contract.Repository_Contract;
using Core.Models;
using Infrastructure.Respository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Mapper;
using Core.Contract.Services_Contract;
using Core.DTO.Categorydto;
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
        public async Task<IActionResult> GetAllCategory()
        {
            IEnumerable<Category> cates = await _categoryServices.GetAllCategories();
            if(cates == null)
            {
                return NotFound();
            }

            return Ok(cates.Select(c => c.toCategoryDTO()));
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

        [HttpPost("[Action]")]
        public async Task<IActionResult> Updated([FromQuery] CategoryUpdateRequest categoryUpdateRequest, [FromQuery] int id)
        {
            bool isUpdated = await _categoryServices.UpdateCategory(id,categoryUpdateRequest);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return Ok();
        }
        [HttpPost("[Action]")]
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
