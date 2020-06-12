using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime inputTime = Convert.ToDateTime(value);
            if (inputTime > DateTime.Now)
                return new ValidationResult("Must input a Past date!");
            else if (inputTime.Year >= DateTime.Now.Year - 18)
                return new ValidationResult("Chef must be 18 years or older!");
            return ValidationResult.Success;
        }
    }
}