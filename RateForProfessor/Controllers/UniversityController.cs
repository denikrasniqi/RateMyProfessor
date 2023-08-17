using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Extensions;
using RateForProfessor.Models;
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
        public IActionResult CreateUniversity([FromForm] University university, IFormFile file)
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
            string photoPath = FileUploadHelper.SaveProfilePhoto(file);
            var createdUniversity = _universityService.CreateUniversitiy(university, photoPath);
            return Ok(createdUniversity);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateUniversity/{id}")]
        public IActionResult UpdateUniversity(int id, [FromForm] University university, IFormFile file)
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
            //var oldUniversity = _universityService.GetUniversityById(id);
            //string photoPath = FileUploadHelper.SaveProfilePhoto(file);
            try
            {
                var oldUniversity = _universityService.GetUniversityById(id);
                string photoPath = FileUploadHelper.SaveProfilePhoto(file);

                if (oldUniversity == null)
                {
                    return NotFound();
                }
                _universityService.UpdateUniversity(university, photoPath);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the University: "/*+ oldUniversity.Name*/);
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


        [HttpPost("UploadProfilePhoto/{universityId}")]
        public IActionResult UploadProfilePhoto(int universityId, IFormFile file)
        {
            try
            {
                var university = _universityService.GetUniversityById(universityId);
                if (university == null)
                {
                    return NotFound();
                }

                if (file != null)
                {
                    string photoPath = FileUploadHelper.SaveProfilePhoto(file);
                    _universityService.UploadProfilePhoto(universityId, photoPath);
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
