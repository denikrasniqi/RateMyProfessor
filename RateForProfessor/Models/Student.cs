using RateForProfessor.Entities;
using RateForProfessor.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateForProfessor.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public int Grade { get; set; }

        //public Department Department { get; set; }

        //public RateUniversity RateUniversity { get; set; }

        public User User { get; set; }

        //public ICollection<RateProfessor> RateProfessors { get; set; }
    }
}
