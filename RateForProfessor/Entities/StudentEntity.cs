using RateForProfessor.Enums;
using RateForProfessor.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RateForProfessor.Entities
{
    public class StudentEntity
    {
        [Key]
        public int StudentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("University")]
        public int UniversityId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public int Grade { get; set; }

        public virtual UniversityEntity University { get; set; }

        public DepartmentEntity Department { get; set; }

        public RateUniversityEntity RateUniversity { get; set; }

        public  UserEntity User { get; set; }

        public ICollection<RateProfessorEntity> RateProfessors { get; set; }

        public string ProfilePhotoPath { get; set; }
    }
}
