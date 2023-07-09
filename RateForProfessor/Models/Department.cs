using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RateForProfessor.Models
{
    public class Department
    {
        [Key] 
        public int DepartmentId { get; set; }
        
        [ForeignKey("University")]
        public int UniversityId { get; set; }
        
        public string Name { get; set; }
        
        public int EstablishedYear { get; set; }
        
        public string Description { get; set; }
        
        public int StaffNumber { get; set; }
        
        public int StudentNumber { get; set; }
        
        public int CourseNumber { get;  set; }

        public virtual University University { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<DepartmentProfessor> DepartmentProfessors { get; set; }
    }
}


