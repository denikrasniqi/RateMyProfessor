using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Models;
using RateForProfessor.Services;
using RateForProfessor.Services.Interfaces;
using RateForProfessor.Validators;
using RateForProfessor.Extensions;


namespace RateForProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetAllNews")]
        public List<News> GetAllNews()
        {
            var result = _newsService.GetAllNews();
            return result;
        }

        [HttpGet("GetAllNewsDescByDate")]
        public List<News> GetAllNewsDescByDate()
        {
            var result = _newsService.GetAllNewsDescByDate();
            return result;
        }

        [HttpGet("GetNewsById/{id}")]
        public News GetNewsById(int id)
        {
            return _newsService.GetNewsById(id);
        }

        [HttpGet("latestCreated")]
        public ActionResult<News> GetLatestCreatedNews()
        {
            var latestNews = _newsService.GetLatestCreatedNews();
            if (latestNews == null)
            {
                return NotFound();
            }
            return Ok(latestNews);
        }

        [HttpGet("threeLatestCreated")]
        public ActionResult<List<News>> GetThreeLatestCreatedNews()
        {
            var threeLatestNews = _newsService.GetThreeLatestCreatedNews();
            if (threeLatestNews == null || threeLatestNews.Count == 0)
            {
                return NotFound();
            }
            return Ok(threeLatestNews);
        }



        //[Authorize(Roles = "Admin")]
        [HttpPost("CreateNews")]
        public IActionResult CreateNews([FromForm] News news, IFormFile file)
        {
            string photoPath = FileUploadHelper.SaveProfilePhoto(file);
            //string photoPath = SaveProfilePhoto(file);
            var createdNews = _newsService.CreateNews(news, photoPath);
            return Ok(createdNews);
        }


        //private string SaveProfilePhoto(IFormFile file)
        //{
        //    try
        //    {
        //        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        //        if (!Directory.Exists(uploadsFolder))
        //        {
        //            Directory.CreateDirectory(uploadsFolder);
        //        }

        //        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(fileStream);
        //        }

        //        return "/uploads/" + uniqueFileName;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while saving the profile photo.", ex);
        //    }
        //}


        [HttpPut("UpdateNews/{id}")]
        public IActionResult UpdateNews(int id, News news)
        {
                var oldNews = _newsService.GetNewsById(id);
                //string photoPath = FileUploadHelper.SaveProfilePhoto(file);
                //string photoPath = SaveProfilePhoto(file);

                if (oldNews == null)
                {
                    return NotFound();
                }
                _newsService.UpdateNews(news);
                return NoContent();
        }

        [HttpDelete("DeleteNews/{id}")]
        public IActionResult DeleteNews(int id)
        {
            try
            {
                var deletedNews = _newsService.GetNewsById(id);
                if (deletedNews == null)
                {
                    return NotFound();
                }
                _newsService.DeleteNews(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }

        [HttpPost("UploadProfilePhoto/{id}")]
        public IActionResult UploadProfilePhoto(int id, IFormFile file)
        {
            try
            {
                var news = _newsService.GetNewsById(id);
                if (news == null)
                {
                    return NotFound();
                }

                if (file != null)
                {
                    string photoPath = FileUploadHelper.SaveProfilePhoto(file);
                    _newsService.UploadProfilePhoto(id, photoPath);
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
