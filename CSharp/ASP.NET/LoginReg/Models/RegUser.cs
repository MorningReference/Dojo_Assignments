using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class RegUser
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage = "The passwords must be matching!")]
        public string ConfirmPW { get; set; }
    }
}