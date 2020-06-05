using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models
{
    public class LogUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}