using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace RateForProfessor.Entities
{
    public class Department
    {
        [Key] // Annotation for primary key
        public int DepartmentId { get; set; } // Primary Key -> DepartmentId

        [ForeignKey("University")] // Annotation for foreign key
        public int UniversityId { get; set; } //Foreing Key -> UniversityId

        public string Name { get; set; }
        public int EstablishedYear { get; set; }
        public string Description { get; set; }
        public int NrStaff { get; set; }
        public int NrStudent { get; set; }
        public int NrCourse { get; set; }



        // public virtual University University { get; set; } // Navigation property for University


    }
}
