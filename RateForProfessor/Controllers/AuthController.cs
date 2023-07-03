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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(Student student)
        {
            LoginValidator validator = new LoginValidator();
            var validationResult = validator.Validate(student);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            // Perform authentication
            var token = _authService.AuthenticateUser(student.Email, student.Password);
            var message = "User " + student.Email + " Has Logged in!";
            if (token == null)
            {
                return Unauthorized(); // Return 401 Unauthorized if authentication fails
            }
            //else
            //{
            //    return Ok(message);
            //}

            // Return the token in the response
            return Ok(new { Token = token });
        }
    }
}
