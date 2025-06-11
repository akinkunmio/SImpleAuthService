using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthSystem.Application.Contracts.Application;
using SimpleAuthSystem.Application.DTOs;

namespace SimpleAuhSystem.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IAuthService _auth) : BaseController
    {
        [ProducesResponseType(typeof(ServiceResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ServiceResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<string>), StatusCodes.Status409Conflict)]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            var response = await _auth.RegisterAsync(req);
            return ServiceResponse(response);
        }

        [ProducesResponseType(typeof(ServiceResponse<TokenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ServiceResponse<TokenDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ServiceResponse<TokenDto>), StatusCodes.Status404NotFound)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            var response = await _auth.LoginAsync(req);
            return ServiceResponse(response);
        }

        [Authorize]
        [HttpGet("secure")]
        public IActionResult SecureEndpoint()
        {
            return Ok("You have accessed a protected route.");
        }
    }
}
