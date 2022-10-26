using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.WebApi.Dtos;
using StaffManagement.WebApi.Entities;
using StaffManagement.WebApi.Services;

namespace StaffManagement.WebApi.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly JwtService _jwtService;

        public UserController(UserManager<ApplicationUser> userManager, JwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Creates the user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = createUserDto.Username,
            };

            var result = await _userManager.CreateAsync(applicationUser, createUserDto.Password);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }
            return StatusCode(400, result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var user = await _userManager.FindByNameAsync(loginUserDto.Username);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.CheckPasswordAsync(user, loginUserDto.Password);

            if (!result)
            {
                return NotFound();
            }

            var token = _jwtService.GenerateToken();

            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("data")]
        public IActionResult Logout()
        {
            return NoContent();
        }
    }
}
