using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [PastDate]
        [Display(Name = "Date of Birth")]
        public DateTime Birthdate { get; set; }

        public List<Dishes> CreatedDishes { get; set; } = null;
    }
}