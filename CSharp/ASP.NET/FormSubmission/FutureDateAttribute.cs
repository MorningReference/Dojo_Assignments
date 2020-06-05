using System;
using System.ComponentModel.DataAnnotations;

namespace FormSubmission
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime inputTime = Convert.ToDateTime(value);
            if (inputTime < DateTime.Now)
                return new ValidationResult("Must input a future date!");
            return ValidationResult.Success;
        }
    }
}