using RateForProfessor.Entities;
using RateForProfessor.Enums;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}
