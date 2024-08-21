using Core.Contract.Services_Contract;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Đăng ký người dùng
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.SignUpAsync(signUp);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Đăng ký thành công." });
            }

            return BadRequest(new { Errors = result.Errors });
        }

        // Đăng nhập người dùng
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.SignInAsync(signIn);

            if (result.Succeeded)
            {
                return Ok(new { Token = result.Token });
            }

            return Unauthorized(new { Errors = result.Errors });
        }
    }
}
