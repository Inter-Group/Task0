using Core.DTO.Productdto;
using Core.Mapper;
using Core.Models;
using Core.Contract.Services_Contract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        // Lấy danh sách tất cả sản phẩm
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1)
        {
            try
            {
                // Lấy danh sách category phân trang
                var products = await _productServices.GetPagedProductsAsync(pageNumber, pageSize);

                // Lấy tổng số lượng Category
                var totalProductsCount = await _productServices.GetTotalProductsCountAsync();

                // Tạo response phân trang
                var response = new
                {
                    TotalCount = totalProductsCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    Products = products
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lấy thông tin sản phẩm theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productServices.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product.toProductDTO());
        }

        // Tạo mới một sản phẩm
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
        {
            var product = productDTO.ProductFromDTO();
            bool result = await _productServices.CreateProduct(product);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(product.toProductDTO());
        }

        // Cập nhật thông tin sản phẩm
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
           
            bool result = await _productServices.UpdateProduct(id, productDTO);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        // Xóa một sản phẩm
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = await _productServices.DeleteProduct(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
