﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class University
    {
        [ Key ]
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstablishedYear { get; set; }
        public string Description { get; set; }
        public int NumriStafit { get; set; }
        public int NumriStudenteve { get; set; }
        public int NumriCourses { get; set; }

    }
}
