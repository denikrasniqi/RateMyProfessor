using RateForProfessor.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateForProfessor.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int Grade { get; set; }

        public Gender Gender { get; set; }

        public Department Department { get; set; }

        public RateUniversity RateUniversity { get; set; }

        public ICollection<RateProfessor> RateProfessors { get; set; }
    }
}
