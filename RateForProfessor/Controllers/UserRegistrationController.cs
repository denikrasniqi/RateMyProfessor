using Microsoft.AspNetCore.Mvc;
using RateForProfessor.Entities;
using RateForProfessor.Models;
using RateForProfessor.Services.Interfaces;

namespace RateForProfessor.Controllers
{
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRegistrationService _registrationService;
        public UserRegistrationController(IUserRegistrationService service)
        {
            _registrationService = service;
        }

        [HttpGet]
        public List<StudentEntity> GetAllStudents()
        {
            var result = _registrationService.GetAllStudents();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult GetStudent()
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            var result = _registrationService.CreateStudent(student);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent()
        {
            return null;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent()
        {
            return null;
        }
    }
}
