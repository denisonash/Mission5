using System;
using System.ComponentModel.DataAnnotations;

namespace Mission4.Models
{
    public class Category
    {
        [Key]
        [Required(ErrorMessage ="Enter categoryID")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public string CategoryName { get; set; }
    }
}
