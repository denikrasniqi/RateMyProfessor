using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        public int CreditHours { get; set; }

        public string Description { get; set; }

        //public Department Department { get; set; }

        //public ICollection<ProfessorCourse> ProfessorCourses { get; set; }
    }
}
