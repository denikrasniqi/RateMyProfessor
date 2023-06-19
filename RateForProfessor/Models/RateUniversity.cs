using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RateForProfessor.Models
{
    public class RateUniversity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("University")]
        public int UniversityId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public int Overall { get; set; }

        public string Feedback { get; set; }

        //public virtual University University { get; set; }

        //public virtual Student Student { get; set; }



    }
}
