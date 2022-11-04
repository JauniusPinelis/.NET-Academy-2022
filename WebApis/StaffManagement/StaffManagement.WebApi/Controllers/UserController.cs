using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.Repositories.Entities;
using StaffManagement.Services.Dtos;
using StaffManagement.Services.Services;
using System.Security.Claims;

namespace StaffManagement.WebApi.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly JwtService _jwtService;
        private readonly ApiKeyService _apiKeyService;

        public UserController(UserManager<ApplicationUser> userManager, JwtService jwtService, ApiKeyService apiKeyService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _apiKeyService = apiKeyService;
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

        [HttpPost("{userId}/upload-data")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            return Ok();
        }

        [Authorize(Policy = "user")]
        [HttpGet("data")]
        public IActionResult Data()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {

                return Ok(identity.Claims.ToDictionary(x => x.Type, x => x.Value));
            }

            return BadRequest();
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("admin-data")]
        public IActionResult AdminData(CreateApiKey createApiKey)
        {
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //if (identity != null)
            //{

            //    return Ok(identity.Claims.ToDictionary(x => x.Type, x => x.Value));
            //}

            //return BadRequest();

            _apiKeyService.CreateApiKey(createApiKey.UserId);

            return StatusCode(201);
        }
    }
}
