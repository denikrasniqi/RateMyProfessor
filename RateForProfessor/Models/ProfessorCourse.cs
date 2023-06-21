using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class ProfessorCourse
    {
        [Key] 
        public int ProfessorCourseId { get; set; } 

        [ForeignKey("Professor")] 
        public int ProfessorId { get; set; } 

        [ForeignKey("Course")] 
        public int CourseId { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual Course Courses { get; set; }
        
    }
}


