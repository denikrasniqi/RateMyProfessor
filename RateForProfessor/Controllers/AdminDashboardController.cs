using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly IAdminDashboardService _adminDashboardService;
        public AdminDashboardController(IAdminDashboardService adminDashboardService)
        {
            _adminDashboardService = adminDashboardService;
        }

        //Proffessor
        [HttpGet("GetAllProfessors")]
        public List<Professor> GetAllProfessors()
        {
            return _adminDashboardService.GetAllProfessors();
        }
        [HttpGet("GetProfessorById/{id}")]
        public Professor GetProfessorById(int id)
        {
            return _adminDashboardService.GetProfessorById(id);
        }
        [HttpGet("GetProfessorByName/{name}")]
        public Professor GetProfessorByName(string name)
        {
            return _adminDashboardService.GetProfessorByName(name);
        }
        [HttpPost("CreateProfessor")]
        public IActionResult CreateProfessor(Professor professor)
        {
            ProfessorValidator validator = new ProfessorValidator();
            var validationResult = validator.Validate(professor);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdProfessor = _adminDashboardService.CreateProfessor(professor);
            return Ok(createdProfessor);
        }


        [HttpPut("UpdateProfessor/{id}")]
        public IActionResult UpdateProfessor(int id, Professor professor)
        {
            ProfessorValidator validator = new ProfessorValidator();
            var validationResult = validator.Validate(professor);

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
                var oldProfessor = _adminDashboardService.GetProfessorById(id);
                if (oldProfessor == null)
                {
                    return NotFound();
                }
                _adminDashboardService.UpdateProfessor(professor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }
        [HttpDelete("DeleteProfessor/{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            try
            {
                var professor = _adminDashboardService.GetProfessorById(id);
                if (professor == null)
                {
                    return NotFound();
                }
                _adminDashboardService.DeleteProfessor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }
        //Department

        [HttpGet("GetAllDepartments")]
        public List<Department> GetAllDepartments()
        {
            var result = _adminDashboardService.GetAllDepartments();
            return result;
        }

        [HttpGet("GetDepartmentById/{id}")]
        public Department GetDepartmentById(int id)
        {
            return _adminDashboardService.GetDepartmentById(id);
        }

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
            var createdDepartment = _adminDashboardService.CreateDepartment(department);
            return Ok(createdDepartment);
        }


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
                var oldDepartment = _adminDashboardService.GetDepartmentById(id);
                if (oldDepartment == null)
                {
                    return NotFound();
                }
                _adminDashboardService.UpdateDepartment(department);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }
        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var department = _adminDashboardService.GetDepartmentById(id);
                if (department == null)
                {
                    return NotFound();
                }
                _adminDashboardService.DeleteDepartment(id);
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
            return _adminDashboardService.GetDepartmentByName(name);
        }
        //Student
        [HttpGet("GetAllStudents")]
        public List<Student> GetAllStudents()
        {
            var result = _adminDashboardService.GetAllStudents();
            return result;
        }

        [HttpGet("GetStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _adminDashboardService.GetStudentById(id);
        }

        [HttpGet("GetStudentByEmail/{email}")]
        public Student GetStudentByEmail(string email)
        {
            return _adminDashboardService.GetStudentByEmail(email);
        }
        [HttpDelete("DeleteStudent/{id}")]
        public void DeleteStudent(int id)
        {
            _adminDashboardService.DeleteStudent(id);
        }
        [HttpGet("GetStudentByName/{name}")]
        public Student GetStudentByName(string name)
        {
            var student = _adminDashboardService.GetStudentByName(name);
            return student;
        }


        //University
        //[HttpGet("GetAllUniversities")]
        //public List<University> GetAllUniversities()
        //{
        //    var universities = _adminDashboardService.GetAllUniversites();
        //    return universities;
        //}

        //[HttpGet("GetUniversityById/{id}")]
        //public University GetUniversityById(int id)
        //{
        //    var university = _adminDashboardService.GetUniversityById(id);
        //    return university;
        //}

        //[HttpGet("GetUniversityByName/{name}")]
        //public University GetUniversityByName(string name)
        //{
        //    var university = _adminDashboardService.GetUniversityByName(name);
        //    return university;
        //}

        //[HttpPost("CreateUniversity")]
        //public IActionResult CreateUniversity(University university)
        //{
        //    UniversityValidator validator = new UniversityValidator();
        //    var validationResult = validator.Validate(university);

        //    if (!validationResult.IsValid)
        //    {
        //        foreach (var error in validationResult.Errors)
        //        {
        //            ModelState.AddModelError("", error.ErrorMessage);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    var createdUniversity = _adminDashboardService.CreateUniversitiy(university);
        //    return Ok(createdUniversity);
        //}

        //[HttpPut("UpdateUniversity/{id}")]
        //public IActionResult UpdateUniversity(int id, University university)
        //{
        //    UniversityValidator validator = new UniversityValidator();
        //    var validationResult = validator.Validate(university);

        //    if (!validationResult.IsValid)
        //    {
        //        foreach (var error in validationResult.Errors)
        //        {
        //            ModelState.AddModelError("", error.ErrorMessage);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    var oldUniversity = _adminDashboardService.GetUniversityById(id);
        //    try
        //    {

        //        if (oldUniversity == null)
        //        {
        //            return NotFound();
        //        }
        //        _adminDashboardService.UpdateUniversity(university);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "An error occurred while updating the University: " + oldUniversity.Name);
        //    }
        //}

        //[HttpDelete("DeleteUniversity/{id}")]
        //public IActionResult DeleteUniversity(int id)
        //{
        //    var deletedUniversity = _adminDashboardService.GetUniversityById(id);
        //    try
        //    {

        //        if (deletedUniversity == null)
        //        {
        //            return NotFound();
        //        }
        //        _adminDashboardService.DeleteUniversity(id);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "An error occurred while deleting the University: " + deletedUniversity.Name);
        //    }
        //}
        //Statistikat
        [HttpGet("GetUniversityCount")]
        public int GetUniversityCount()
        {
            return _adminDashboardService.GetUniversityCount();
        }
        [HttpGet("GetStudentCount")]
        public int GetStudentCount()
        {
            return _adminDashboardService.GetStudentCount();
        }
        [HttpGet("GetDepartmentCount")]
        public int GetDepartmentCount()
        {
            return _adminDashboardService.GetDepartmentCount();
        }
        [HttpGet("GetProfessorCount")]
        public int GetProfessorCount()
        {
            return _adminDashboardService.GetProfessorCount();
        }
        [HttpGet("SortFromHighestRatedProfessor")]
        public List<RateProfessor> SortFromHighestRatedProfessor()
        {
            return _adminDashboardService.SortFromHighestRatedProfessor();
        }
        [HttpGet("GetHighestRatedUniversity")]
        public RateUniversity GetHighestRatedUniversity()
        {
            return _adminDashboardService.GetHighestRatedUniversity();
        }
        [HttpGet("GetOldestUniversity")]
        public University GetOldestUniversity()
        {
            return _adminDashboardService.GetOldestUniversity();
        }
    }
}
