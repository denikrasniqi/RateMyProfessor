using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class RateProfessorEntity
    {
        [Key] // Annotation for primary key
        public int Id { get; set; } // PK Id

        [ForeignKey("Professor")] // Annotation for foreign key
        public int ProfessorId { get; set; } // ProfessorID FK

        [ForeignKey("Student")] // Annotation for foreign key
        public int StudentId { get; set; } // StudentID FK

        public int Overall { get; set; }

        public int CommunicationSkills { get; set; }

        public int Responsiveness { get; set; }

        public int GradingFairness { get; set; }

        public string Feedback { get; set; }

        //public virtual ProfessorModel Professor { get; set; } // Navigation property for Professor

        //public virtual StudentModel Student { get; set; } // Navigation property for Student
    }
}
