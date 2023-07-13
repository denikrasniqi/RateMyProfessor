using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
     
        private readonly IUserRegistrationService _registrationService;
        public UserRegistrationController(IUserRegistrationService service)
        {
            _registrationService = service;
        }

        [Authorize]
        [HttpGet]
        public List<Student> GetAllStudents()
        {
            var result = _registrationService.GetAllStudents();
            return result;
        }

        [Authorize]
        [HttpGet("GetStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _registrationService.GetStudentById(id);
        }

        [HttpGet("GetStudentByEmail/{email}")]
        public Student GetStudentByEmail(string email)
        {
            return _registrationService.GetStudentByEmail(email);
        }
        [HttpGet("GetStudentByName/{name}")]
        public Student GetStudentByName(string name)
        {
            return _registrationService.GetStudentByName(name);
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student)
        {
            StudentValidator validator = new StudentValidator();
            var validationResult = validator.Validate(student);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdStudent = _registrationService.CreateStudent(student);
            return Ok(createdStudent);
            //var createdStudent = _registrationService.CreateStudent(student);
            //return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentId }, createdStudent);
        }

        //[HttpPut("{id}")]
        //public void UpdateStudent(Student student)
        //{
        //    _registrationService.UpdateStudent(student);
        //}
        [Authorize]
        [HttpPut("UpdateStudent/{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            StudentValidator validator = new StudentValidator();
            var validationResult = validator.Validate(student);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            try
            {
                var oldStudent = _registrationService.GetStudentById(id);
                if (oldStudent == null)
                {
                    return NotFound();
                }
                _registrationService.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        [Authorize]
        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var deletedStudent = _registrationService.GetStudentById(id);
                if (deletedStudent == null)
                {
                    return NotFound();
                }
                _registrationService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }

        //[HttpDelete("{id}")]
        //public void DeleteStudent(int id)
        //{
        //    _registrationService.DeleteStudent(id);
        //}
    }
}
