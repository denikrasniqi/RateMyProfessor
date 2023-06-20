using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class ProfessorCourseEntities
    {

        [Key] // Annotation for primary key
        public int ProfessorCourseId { get; set; } // PK Id

        [ForeignKey("Professor")] // Annotation for foreign key
        public int ProfessorId { get; set; } // ProfessorID FK

        [ForeignKey("Course")] // Annotation for foreign key
        public int CourseId { get; set; } // CourseID FK
    }
}

