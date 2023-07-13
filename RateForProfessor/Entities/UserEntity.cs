using RateForProfessor.Enums;
using RateForProfessor.Models;

namespace RateForProfessor.Entities
{
    public class UserEntity
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public StudentEntity Student { get; set; }
    }
}
