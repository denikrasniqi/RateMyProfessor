using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RateForProfessor.Entities;

namespace RateForProfessor.Models
{
    public class ContactNumberEntity
    {
        [Key, ForeignKey("University")]
        public int UniversityId { get; set; }

        [Key, ForeignKey("ContactNumber")]
        public int ContactNumberId { get; set; }

        public string ContactNumber { get; set; }

        public virtual UniversityEntity University { get; set; }
    }
}