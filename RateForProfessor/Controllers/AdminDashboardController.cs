using FluentValidation;
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
        public AdminDashboardController(IAdminDashboardService adminDashboardService/*, IUniversityService universityService, IRateUniversityService rateuniversityService*/)
        {
            _adminDashboardService = adminDashboardService;           
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
    }
}
