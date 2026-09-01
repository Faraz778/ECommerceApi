using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerceApi.DTOs;
using ECommerceApi.Services;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            var result = await _userService.Register(registerUserDto);
            if (result == false)
            {
                return BadRequest("email already exists");
            }
            return Ok(result);


        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginUserDto loginUserDto) { 
        
            var result = await _userService.Login(loginUserDto);
            if (result == null)
            {
              return Unauthorized("invalid email or password");
            }
            return Ok(new
            {
                message = "login successful",
                token = result
            });
        }



    }
}
