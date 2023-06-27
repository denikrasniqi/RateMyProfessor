using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Controllers
{
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
     
        private readonly IUserRegistrationService _registrationService;
        public UserRegistrationController(IUserRegistrationService service)
        {
            _registrationService = service;
        }

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            var result = _registrationService.GetAllStudents();
            return result;
        }

        [HttpGet("{id}")]
        public Student GetStudentById(int id)
        {
            return _registrationService.GetStudentById(id);
        }

        [HttpGet("{email}")]
        public Student GetStudentByEmail(string email)
        {
            return _registrationService.GetStudentByEmail(email);
        }

        [HttpPost]
        public Student CreateStudent(Student student)
        {
            return _registrationService.CreateStudent(student);

            //
            //StudentValidator validator = new StudentValidator();
            //var validationResult = validator.Validate(student);

            //if (!validationResult.IsValid)
            //{
            //    foreach (var error in validationResult.Errors)
            //    {
            //        ModelState.AddModelError("", error.ErrorMessage);
            //    }

            //    return BadRequest(ModelState);
            //}

            //var createdStudent = _registrationService.CreateStudent(student);
            //return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{id}")]
        public void UpdateStudent(Student student)
        {
            _registrationService.UpdateStudent(student);
        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            _registrationService.DeleteStudent(id);
        }
    }
}
