using Microsoft.AspNetCore.Mvc;

namespace RateForProfessor.Controllers
{
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetStudents()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult GetStudent()
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreateStudent()
        {
            return null;
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
