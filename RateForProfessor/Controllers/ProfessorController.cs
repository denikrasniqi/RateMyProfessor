using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Extensions;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public List<Professor> GetAllProfessors()
        {
            var result = _professorService.GetAllProfessors();
            return result;
        }

        [HttpGet("GetProfessorById/{id}")]
        public Professor GetProfessorById(int id)
        {
            return _professorService.GetProfessorById(id);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("CreateProfessor")]
        public IActionResult CreateProfessor([FromForm] Professor professor, IFormFile file)
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
            string photoPath = FileUploadHelper.SaveProfilePhoto(file);
            var createdProfessor = _professorService.CreateProfessor(professor, photoPath);
            return Ok(createdProfessor);
        }

        //[Authorize(Roles = "Admin")]
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
                var oldProfessor = _professorService.GetProfessorById(id);
                if (oldProfessor == null)
                {
                    return NotFound();
                }
                _professorService.UpdateProfessor(professor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the professor.");
            }
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProfessor/{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            try
            {
                var professor = _professorService.GetProfessorById(id);
                if (professor == null)
                {
                    return NotFound();
                }
                _professorService.DeleteProfessor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the professor.");
            }
        }

        [HttpGet("SearchProfessor")]
        public List<Professor> SearchProfessors([FromQuery] Search search)
        {
            var result = _professorService.SearchProfessors(search);
            return result;

        }

        [HttpPost("UploadProfilePhoto/{professorId}")]
        public IActionResult UploadProfilePhoto(int professorId, IFormFile file)
        {
            try
            {
                var professor = _professorService.GetProfessorById(professorId);
                if (professor == null)
                {
                    return NotFound();
                }

                if (file != null)
                {
                    string photoPath = FileUploadHelper.SaveProfilePhoto(file);
                    _professorService.UploadProfilePhoto(professorId, photoPath);
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
    }
}
