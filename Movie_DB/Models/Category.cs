using System;
using System.ComponentModel.DataAnnotations;

namespace Movie_DB.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
