using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //Courses
        [HttpGet("GetAllCourses")]
        public List<Course> GetAllCourses()
        {
            var result = _courseService.GetAllCourses();
            return result;
        }

        [HttpGet("GetCourseById/{id}")]
        public Course GetCourseById(int id)
        {
            return _courseService.GetCourseById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateCourse")]
        public IActionResult CreateDepartment(Course course)
        {
            CourseValidator validator = new CourseValidator();
            var validationResult = validator.Validate(course);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdDepartment = _courseService.CreateCourse(course);
            return Ok(createdDepartment);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateCourse/{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            CourseValidator validator = new CourseValidator();
            var validationResult = validator.Validate(course);

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
                var oldCourse = _courseService.GetCourseById(id);
                if (oldCourse == null)
                {
                    return NotFound();
                }
                _courseService.UpdateCourse(course);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("DeleteCourse/{id}")]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                var course = _courseService.GetCourseById(id);
                if (course == null)
                {
                    return NotFound();
                }
                _courseService.DeleteCourse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the course.");
            }
        }
    }
}
