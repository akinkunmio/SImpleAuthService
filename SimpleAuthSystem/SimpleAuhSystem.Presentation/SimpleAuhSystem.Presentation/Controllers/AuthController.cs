using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleAuthSystem.Application.Contracts.Application;
using SimpleAuthSystem.Application.DTOs;

namespace SimpleAuhSystem.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth) => _auth = auth;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            var response = await _auth.RegisterAsync(req);
            return ServiceResponse(response);
        }

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
