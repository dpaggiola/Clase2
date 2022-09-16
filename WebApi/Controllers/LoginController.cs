using IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            loginDto.Token = _userService.Login(loginDto.Email, loginDto.Password);
            return Ok(loginDto.Token);
        }
    }
}
