using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            // Perform authentication
            var token = _authService.AuthenticateUser(email, password);

            if (token == null)
            {
                return Unauthorized(); // Return 401 Unauthorized if authentication fails
            }

            // Return the token in the response
            return Ok(new { Token = token });
        }
    }
}
