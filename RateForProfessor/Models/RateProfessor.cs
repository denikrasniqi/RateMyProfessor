using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class RateProfessor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public int Overall { get; set; }

        public int CommunicationSkills { get; set; }

        public int Responsiveness { get; set; }

        public int GradingFairness { get; set; }

        public string Feedback { get; set; }

        public virtual Professor Professor { get; set; }

        public virtual Student Student { get; set; }
    }
}
