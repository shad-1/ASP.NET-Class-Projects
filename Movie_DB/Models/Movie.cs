using System;
using System.ComponentModel.DataAnnotations;
using Movie_DB.Enums;

namespace Movie_DB.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public short Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public Ratings Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //Foreign Key for Category
        [Required]
        public int CategoryID { get; set; }
    
        public Category Category { get; set; }
    }
}
