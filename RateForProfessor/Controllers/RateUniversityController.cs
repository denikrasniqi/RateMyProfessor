using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RateForProfessor.Models;
using RateForProfessor.Services;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;

namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateUniversityController : ControllerBase
    {
        private readonly IRateUniversityService _rateUniversityService;
        
        public RateUniversityController(IRateUniversityService rateUniversityService)
        {
            _rateUniversityService = rateUniversityService;
        }

        [HttpGet]
        public List<RateUniversity> GetAllRateUniversity()
        {
            var result = _rateUniversityService.GetAllRateUniversity();
            return result;
        }

        [HttpGet("GetOverallRatingForUniversities")]
        public IActionResult OverallRatingUniversities()
        {
            var universityRatings = _rateUniversityService.GetOverallRatingUniversities();
            return Ok(universityRatings);
        }
        [HttpGet("GetRateUniversityById/{id}")]
        public RateUniversity GetRateUniversityById(int id)
        {
            return _rateUniversityService.GetRateUniversityById(id);
        }

        [HttpGet("RateUniversity/University/UniversityId")]
        public ActionResult<List<RateUniversity>> GetRateUniversityByUniversityId(int id)
        {
            var rateUniversity = _rateUniversityService.GetRateUniversityByUniversiyId(id); 
            return Ok(rateUniversity);
        }

        [HttpGet("RateUniversity/Student/StudentId")]
        public ActionResult<List<RateUniversity>> GetRateUniversityByStudentId(int studentid)
        {
            var rateUniversity = _rateUniversityService.GetRateUniversityByStudentId(studentid);
            return Ok(rateUniversity);
        }

        [Authorize(Roles = "Student")]
        [HttpPost("CreateRateUniversity")]
        public IActionResult CreateRateUniversity(RateUniversity rateUniversity)
        {
            RateUniversityValidator validator =  new RateUniversityValidator();
            var validationResult = validator.Validate(rateUniversity);

            if(!validationResult.IsValid)
            {
                foreach( var error  in validationResult.Errors )
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            var createdRateUniversity = _rateUniversityService.CreateRateUniversity(rateUniversity);
            return Ok(createdRateUniversity);
        }

        [Authorize(Roles = "Student")]
        [HttpPut("UpdateRateUniversity/{id}")]
        public IActionResult UpdateRateUniversity(int id, RateUniversity rateUniversity)
        {
            RateUniversityValidator validator = new RateUniversityValidator();
            var validationResult = validator.Validate(rateUniversity);

            if(!validationResult.IsValid)
            {
                foreach(var error in validationResult.Errors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return BadRequest();
            }
            try
            {
                var oldRateUniversity = _rateUniversityService.GetRateUniversityById(id);
                if (oldRateUniversity == null)
                {
                    return NotFound();
                }
                _rateUniversityService.UpdateRateUniversity(rateUniversity);
                return NoContent();
            }
            catch(Exception ex) 
            {
                return StatusCode(500, " An error occurred while updating the University");
            }
        }

        [Authorize(Roles = "Student")]
        [HttpDelete("DeleteRateUniversity/{id}")]
        public IActionResult DeleteRateUniversity(int id)
        {
            try
            {
                var deletedRateUniversity = _rateUniversityService.GetRateUniversityById(id);
                if(deletedRateUniversity == null)
                {
                    return NotFound();
                }
                _rateUniversityService.DeleteRateUniversity(id);
                return NoContent();
            }catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the RateUniversity");
            }
        }
    }
}
