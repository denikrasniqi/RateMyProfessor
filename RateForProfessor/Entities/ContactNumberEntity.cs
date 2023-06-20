using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class ContactNumberEntity
    {
        [Key, ForeignKey("University")]
        public int UniversityId { get; set; }

        [Key, ForeignKey("ContactNumber")]
        public int ContactNumberId { get; set; }

        public string ContactNumber { get; set; }

        // public virtual University University { get; set; } // Navigation property for University
    }
}