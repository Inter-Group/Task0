using Core.Contract.Repository_Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICategogyRepository _categogyRepository;
        private readonly IProductRepository _productRepository;
        public ProductController(ICategogyRepository cate, IProductRepository pro)
        {
            _categogyRepository = cate;
            _productRepository = pro;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            
        }
    }
}
