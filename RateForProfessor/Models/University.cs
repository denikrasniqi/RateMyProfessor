using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }

        public string Name { get; set; }

        public int EstablishedYear { get; set; }

        public string Description { get; set; }

        public int StaffNumber { get; set; }

        public int StudentsNumber { get; set; }

        public int CoursesNumber { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<ContactNumber> ContactNumbers { get; set; }

        public ICollection<Department> Departments { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<RateUniversity> RateUniversities { get; set; }
    }
}
