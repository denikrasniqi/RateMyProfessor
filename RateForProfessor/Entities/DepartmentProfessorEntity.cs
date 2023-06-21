using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class DepartmentProfessorEntity
    {
        [Key, Column(Order = 1)] 
        [ForeignKey("Department")]
        public int DepartmentId { get; set; } 

        [Key, Column(Order = 2)]
        [ForeignKey("Professor")]
        public int ProfessorId { get; set; }

        public virtual DepartmentEntity Department {get; set;}

        public virtual DepartmentEntity Professor {get; set;}

        public ICollection<DepartmentEntity> Departments { get; set; }

        public ICollection<ProfessorEntity> Professors { get; set; }
    }
}
