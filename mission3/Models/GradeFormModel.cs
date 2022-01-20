using System;
using System.ComponentModel.DataAnnotations;

namespace mission3.Models
{
    public class GradeFormModel
    {
        public GradeFormModel()
        {
            
        }

        [Required]
        [Range(0,100)]
        public double Assignments { get; set; }

        [Required]
        [Range(0, 100)]
        public double GroupProject { get; set; }

        [Required]
        [Range(0, 100)]
        public double Quiz { get; set; }

        [Required]
        [Range(0, 100)]
        public double Exams { get; set; }

        [Required]
        [Range(0, 100)]
        public double Intex { get; set; }
    }
}
