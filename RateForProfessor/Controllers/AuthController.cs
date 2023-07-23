using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<(string email, string password)> _loginValidator;

        public AuthController(IAuthService authService, IValidator<(string email, string password)> loginValidator)
        {
            _authService = authService;
            _loginValidator = loginValidator;
        }


        //public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        //{
        //    var loginData = (email, password);
        //    var validationResults = _loginValidator.Validate(loginData);

        //    if (!validationResults.IsValid)
        //    {
        //        return BadRequest(validationResults.Errors);
        //    }
        //    // Perform authentication
        //    var token = _authService.AuthenticateUser(email, password);
        //    if (token == null)
        //    {
        //        return Unauthorized(); // Return 401 Unauthorized if authentication fails
        //    }
        //    // Return the token in the response
        //    return Ok(new { Token = token });
        //}

        [HttpPost("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            var loginData = (email, password);
            var validationResults = _loginValidator.Validate(loginData);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            var token = _authService.AuthenticateUser(email, password).Result;

            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }
            return Ok(new { Token = token });
        }
    }
}
