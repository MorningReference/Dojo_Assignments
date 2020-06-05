using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Age:")]
        public int Age { get; set; }

        [Required]
        [FutureDate]
        [Display(Name = "Birthday:")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address:")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}