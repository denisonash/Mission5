using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class NewMovie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        // Build the foreign key
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter a director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please select a rating")]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }
    }
}
