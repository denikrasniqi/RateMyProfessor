using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class DepartmentProfessorEntity
    {
        [Key, Column(Order = 1)] 
        [ForeignKey("Department")]
        public int DepartmentId { get; set; } // Foreing Key -> DepartmentId
        [Key, Column(Order = 2)]
        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }
        //public virtual Department Department {get; set;} // Represents the associated Department
        //public virtual Professor Professor {get; set;} // Represents the associated Professor
    }
}
