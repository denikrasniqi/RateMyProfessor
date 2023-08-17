using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class Professor
    {
        [Required]
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

        public ICollection<RateProfessor>? RateProfessors { get; set; }

        public ICollection<ProfessorCourse>? ProfessorCourses { get; set; }

        public string? ProfilePhotoPath { get; set; }
    }
}
