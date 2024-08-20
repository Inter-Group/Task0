using Core.DTO.Productdto;
using Core.Mapper;
using Core.Models;
using Core.Contract.Services_Contract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productServices.GetAllProducts();
            return Ok(products.Select(p => p.toProductDTO()));
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
        [HttpPost("{Create}")]
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
        [HttpPut("[Action]")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
        {
            var product = productDTO.ProductFromDTO();
            bool result = await _productServices.UpdateProduct(id, product);

            if (!result)
            {
                return BadRequest();
            }

            return Ok(product.toProductDTO());
        }

        // Xóa một sản phẩm
        [HttpDelete("[Action]")]
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
