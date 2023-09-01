using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Context;
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
        private readonly AppDbContext _dbContext;

        public AdminDashboardController(IAdminDashboardService adminDashboardService, AppDbContext dbContext)
        {
            _adminDashboardService = adminDashboardService;
            _dbContext = dbContext;
        }
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
        public RateProfessor SortFromHighestRatedProfessor()
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
        [HttpGet("GetStudentWithMostRatings")]
        public Student GetStudentWithMostRatings()
        {
            return _adminDashboardService.GetStudentWithMostRatings();
        }

        [HttpGet("RecentNewsCount")]
        public ActionResult<IEnumerable<DayNewsCount>> GetRecentNewsCount()
        {
            //var lastWeekStart = DateTime.Today.AddDays(-7);
            //var newsCounts = _dbContext.News
            //    .Where(news => news.PublicationDate >= lastWeekStart)
            //    .GroupBy(news => news.PublicationDate.Date)
            //    .Select(group => new DayNewsCount
            //    {
            //        Date = group.Key,
            //        Count = group.Count()
            //    })
            //    .ToList();

            //return Ok(newsCounts);
            var lastWeekStart = DateTime.Today.AddDays(-7);
            var newsCounts = _dbContext.News
                .Where(news => news.PublicationDate >= lastWeekStart)
                .GroupBy(news => news.PublicationDate.Date)
                .Select(group => new DayNewsCount
                {
                    Date = group.Key,
                    Count = group.Count()
                })
                .ToList();

            // Për çdo ditë të 7 ditëve të fundit, shtoni një rekord me numër zero nëse nuk ka lajme për atë ditë
            for (int i = 0; i < 7; i++)
            {
                var currentDate = DateTime.Today.AddDays(-i);
                if (!newsCounts.Any(nc => nc.Date.Date == currentDate.Date))
                {
                    newsCounts.Add(new DayNewsCount
                    {
                        Date = currentDate,
                        Count = 0
                    });
                }
            }

            // Renditni listën e rezultateve në rendin e rritjes së datave
            newsCounts = newsCounts.OrderBy(nc => nc.Date).ToList();

            return Ok(newsCounts);

        }
    }

    public class DayNewsCount
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}