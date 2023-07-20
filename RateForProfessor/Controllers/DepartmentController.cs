using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public List<Department> GetAllDepartments()
        {
            var result = _departmentService.GetAllDepartments();
            return result;
        }

        [HttpGet("GetDepartmentById/{id}")]
        public Department GetDepartmentById(int id)
        {
            return _departmentService.GetDepartmentById(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(Department department)
        {
            DepartmentValidator validator = new DepartmentValidator();
            var validationResult = validator.Validate(department);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdDepartment = _departmentService.CreateDepartment(department);
            return Ok(createdDepartment);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateDepartment/{id}")]
        public IActionResult UpdateDepartment(int id, Department department)
        {
            DepartmentValidator validator = new DepartmentValidator();
            var validationResult = validator.Validate(department);

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
                var oldDepartment = _departmentService.GetDepartmentById(id);
                if (oldDepartment == null)
                {
                    return NotFound();
                }
                _departmentService.UpdateDepartment(department);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var department = _departmentService.GetDepartmentById(id);
                if (department == null)
                {
                    return NotFound();
                }
                _departmentService.DeleteDepartment(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }

        [HttpGet("GetDepartmentByName/{name}")]
        public Department GetDepartmentByName(string name)
        {
            return _departmentService.GetDepartmentByName(name);
        }
    }
}
