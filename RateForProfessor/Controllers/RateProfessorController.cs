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
    public class RateProfessorController : ControllerBase
    {
        private readonly IRateProfessorService _rateProfessorService;
        public RateProfessorController(IRateProfessorService rateProfessorService)
        {
            _rateProfessorService = rateProfessorService;
        }

        [HttpGet]
        public List<RateProfessor> GetAllRateProfessors()
        {
            var result = _rateProfessorService.GetAllRateProfessors();
            return result;
        }
        [HttpGet("GetOverallRatingForProfessors")]
        public IActionResult OverallRatingProfessors()
        {
            var professorRatings = _rateProfessorService.GetOverallRatingProfessors();
            return Ok(professorRatings);
        }

        [HttpGet("GetRateProfessorById/{id}")]
        public RateProfessor GetRateProfessorById(int id)
        {
            return _rateProfessorService.GetRateProfessorById(id);
        }

        [HttpGet("RateProfessors/Professor/{professorId}")]
        public ActionResult<List<RateProfessor>> GetRateProfessorsByProfessorId(int professorId)
        {
            var rateProfessors = _rateProfessorService.GetRateProfessorsByProfessorId(professorId);
            return Ok(rateProfessors);
        }

        [HttpGet("RateProfessors/Student/{studentId}")]
        public ActionResult<List<RateProfessor>> GetRateProfessorsByStudentId(int studentId)
        {
            var rateProfessors = _rateProfessorService.GetRateProfessorsByStudentId(studentId);
            return Ok(rateProfessors);
        }

        //[Authorize(Roles = "Student")]

        //[HttpPost("CreateRateProfessor")]
        //public IActionResult CreateRateProfessor(int professorid, int studentid, int communicationskills, int responsiveness,
        //    int gradingfairness, string feedback)
        //{
        //    var overallresult = _rateProfessorService.CalculateOverall(communicationskills, responsiveness, gradingfairness);
        //    var rateprofessor = new RateProfessor()
        //    {
        //        ProfessorId = professorid,
        //        StudentId = studentid,
        //        Feedback = feedback,
        //        CommunicationSkills = communicationskills,
        //        Responsiveness = responsiveness,
        //        GradingFairness = gradingfairness,
        //        Overall = overallresult,
        //    };
        //    //RateProfessorValidator validator = new RateProfessorValidator();
        //    //var validationResult = validator.Validate(rateprofessor);

        //    //if (!validationResult.IsValid)
        //    //{
        //    //    foreach (var error in validationResult.Errors)
        //    //    {
        //    //        ModelState.AddModelError("", error.ErrorMessage);
        //    //    }
        //    //    return BadRequest(ModelState);
        //    //}
        //    var createdRateProfessor = _rateProfessorService.CreateRateProfessor(rateprofessor);
        //    return Ok(createdRateProfessor);
        //}
        [HttpPost("CreateRateProfessor")]
        public IActionResult CreateRateProfessor(RateProfessor rateProfessor)
        {

            var createdRateProfessor = _rateProfessorService.CreateRateProfessor(rateProfessor);
            return Ok(createdRateProfessor);
        }



        //[Authorize(Roles = "Student")]
        [HttpPut("UpdateRateProfessor/{id}")]
        public IActionResult UpdateRateProfessor(int id, RateProfessor rateProfessor)
        {
            RateProfessorValidator validator = new RateProfessorValidator();
            var validationResult = validator.Validate(rateProfessor);

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
                var oldRateProfessor = _rateProfessorService.GetRateProfessorById(id);
                if (oldRateProfessor == null)
                {
                    return NotFound();
                }
                _rateProfessorService.UpdateRateProfessor(rateProfessor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        //[Authorize(Roles = "Student")]
        [HttpDelete("DeleteRateProfessor/{id}")]
        public IActionResult DeleteRateProfessor(int id)
        {
            try
            {
                var deltedRateProfessor = _rateProfessorService.GetRateProfessorById(id);
                if (deltedRateProfessor == null)
                {
                    return NotFound();
                }
                _rateProfessorService.DeleteRateProfessor(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }

    }
}
