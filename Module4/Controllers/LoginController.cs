using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module4.Models.User;
using Module4.Services;
using System.Net;

namespace Module4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register (RegisterVM register)
        {
            var result = await _accountService.RegisterUserAsync(register);
            if (result.Succeeded)            
                return Ok(result);            
            else
                return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var result = await _accountService.LoginUserAsync(login);
            if (string.IsNullOrEmpty(result))
                return Unauthorized();
            return Ok(result);
        }
    }
}
