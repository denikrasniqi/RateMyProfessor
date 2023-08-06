using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Extensions;
using RateForProfessor.Models;
using RateForProfessor.Services;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly IUniversityService _universityService;
        public UniversityController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [HttpGet("GetAllUniversities")]
        public List<University> GetAllUniversities()
        {
            var universities = _universityService.GetAllUniversites();
            return universities;
        }

        [HttpGet("GetUniversityById/{id}")]
        public University GetUniversityById(int id)
        {
            var university = _universityService.GetUniversityById(id);
            return university;
        }

        [HttpGet("GetUniversityByName/{name}")]
        public University GetUniversityByName(string name)
        {
            var university = _universityService.GetUniversityByName(name);
            return university;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateUniversity")]
        public IActionResult CreateUniversity(University university)
        {
            UniversityValidator validator = new UniversityValidator();
            var validationResult = validator.Validate(university);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdUniversity = _universityService.CreateUniversitiy(university);
            return Ok(createdUniversity);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateUniversity/{id}")]
        public IActionResult UpdateUniversity(int id, University university)
        {
            UniversityValidator validator = new UniversityValidator();
            var validationResult = validator.Validate(university);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var oldUniversity = _universityService.GetUniversityById(id);
            try
            {
                
                if (oldUniversity == null)
                {
                    return NotFound();
                }
                _universityService.UpdateUniversity(university);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the University: "+ oldUniversity.Name);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUniversity/{id}")]
        public IActionResult DeleteUniversity(int id)
        {
            var deletedUniversity = _universityService.GetUniversityById(id);
            try
            {
                
                if (deletedUniversity == null)
                {
                    return NotFound();
                }
                _universityService.DeleteUniversity(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the University: "+deletedUniversity.Name);
            }
        }
        [HttpGet("SearchUniversity")]
        public List<University> SearchUniversities([FromQuery] Search search)
        {
            var result = _universityService.SearchUniversities(search);
            return result;

        }

    }
}
