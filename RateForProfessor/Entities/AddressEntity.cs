using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RateForProfessor.Entities
{
    public class AddressEntity
    {
        [Key, ForeignKey("University")]
        public int UniversityId { get; set; }

        [Key, ForeignKey("Address")]
        public int AddressId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int ZIPCode { get; set; }

        public virtual UniversityEntity University { get; set; }
    }
}