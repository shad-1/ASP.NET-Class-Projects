using System;
using System.ComponentModel.DataAnnotations;

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
        //I decided to learn how to use c# enums in models. 
        public Category Category { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public Rating Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
    }
}
