using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services;
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
        private readonly IUserService _userService;
        private readonly IUserRegistrationService _userRegistrationService;

        public AuthController(IAuthService authService, IValidator<(string email, string password)> loginValidator, IUserService userService, IUserRegistrationService userRegistrationService)
        {
            _authService = authService;
            _loginValidator = loginValidator;
            _userService = userService;
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromQuery] string email, [FromQuery] string password)
        {
            var loginData = (email, password);
            var validationResults = _loginValidator.Validate(loginData);

            if (!validationResults.IsValid)
            {
                return BadRequest(validationResults.Errors);
            }

            // Perform authentication
            var token = _authService.AuthenticateUser(email, password).Result;

            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid email or password." }); // Return 401 Unauthorized with a meaningful message
            }

            var userData = _userService.GetUserByEmail(email);

            if (userData == null)
            {
                return NotFound(new { Message = "User data not found." });
            }

            int? studentId = null;// per id 
            //Student student = null;// per data te Studentit

            if (userData.Role == Enums.Role.Student)
            {
                 var student = _userRegistrationService.GetStudentByEmail(userData.Email);

                if (student is not null)
                    studentId = student.StudentId;
            }
            // Return the token and user data in the response
            return Ok(new { Token = token, UserData = userData, StudentId = studentId });
            // Return the token in the response
            //return Ok(new { Token = token });
        }

    }
}
