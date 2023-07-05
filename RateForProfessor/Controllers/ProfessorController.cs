using Microsoft.AspNetCore.Mvc;
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
            var createdProfessor = _professorService.CreateProfessor(professor);
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
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }
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
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }
    }
}
