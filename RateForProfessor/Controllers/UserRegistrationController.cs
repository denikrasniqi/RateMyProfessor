using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            var result = _registrationService.GetAllStudents();
            return result;
        }

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
            //try
            //{
                var oldStudent = _registrationService.GetStudentById(id);
                if (oldStudent == null)
                {
                    return NotFound();
                }
                _registrationService.UpdateStudent(student);
                return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, "An error occurred while updating the student.");
            //}
        }


        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            //try
            //{
                var deletedStudent = _registrationService.GetStudentById(id);
                if (deletedStudent == null)
                {
                    return NotFound();
                }
                _registrationService.DeleteStudent(id);
                return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, "An error occurred while deleting the student.");
            //}
        }



        /*[HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student)
        {
            var createdStudent = _registrationService.CreateStudent(student);
            return Ok(createdStudent);
        }*/



        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(Student student, IFormFile file)
        {
            try
            {
                /*StudentValidator validator = new StudentValidator();
                var validationResult = validator.Validate(student);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        ModelState.AddModelError("", error.ErrorMessage);
                    }
                    return BadRequest(ModelState);
                }*/

                //if (file != null)
                //{
                    string photoPath = SaveProfilePhoto(file);
                    var createdStudent = _registrationService.CreateStudent(student, photoPath);
                    return Ok(createdStudent);
                //}
                //else
                //{
                //    var createdStudent = _registrationService.CreateStudent(student);
                //    return Ok(createdStudent);
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the student.");
            }
        }





        [HttpPost("UploadProfilePhoto/{studentId}")]
        public IActionResult UploadProfilePhoto(int studentId, IFormFile file)
        {
            try
            {
                var student = _registrationService.GetStudentById(studentId);
                if (student == null)
                {
                    return NotFound();
                }

                if (file != null)
                {
                    string photoPath = SaveProfilePhoto(file);
                    _registrationService.UploadProfilePhoto(studentId, photoPath);
                    return Ok();
                }
                else
                {
                    return BadRequest("No file was uploaded.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while uploading the profile photo.");
            }
        }

        private string SaveProfilePhoto(IFormFile file)
        {
            try
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return "/uploads/" + uniqueFileName;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while saving the profile photo.", ex);
            }
        }
    }
}
