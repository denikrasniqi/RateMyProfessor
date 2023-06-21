using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class ProfessorEntity
    {
        [Key]
        public int ProfessorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Education { get; set; }

        [Required]
        public string Role { get; set; }

        public ICollection<RateProfessorEntity> RateProfessors { get; set; }

        public ICollection<ProfessorCourseEntity> ProfessorCourses { get; set; }
    }
}
