﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Entities
{
    public class UniversityEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int EstablishedYear { get; set; }

        public string Description { get; set; }

        public int StaffNumber { get; set; }

        public int StudentsNumber { get; set; }

        public int CoursesNumber { get; set; }

        public ICollection<AddressEntity> Addresses { get; set; }

        public ICollection<ContactNumberEntity> ContactNumbers { get; set; }

        public ICollection<DepartmentEntity> Departments { get; set; }

        public ICollection<RateUniversityEntity> RateUniversities { get; set; }
    }
}
