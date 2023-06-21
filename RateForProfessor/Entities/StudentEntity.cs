using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RateForProfessor.Enums;

namespace RateForProfessor.Entities
{
    public class StudentEntity
    {
        [Key]
        public int ID { get; set; }

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

        public DepartmentEntity Department { get; set; }

        public RateUniversityEntity RateUniversity { get; set; }

        public ICollection<RateProfessorEntity> RateProfessors { get; set; }
    }
}
