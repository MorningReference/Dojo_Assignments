using System.ComponentModel.DataAnnotations;

namespace DojoSurvey
{
    public class OptionalAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = (string)value;
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (val.Length > 0 || val.Length < 20)
            {
                return new ValidationResult("Must have more than 20 characters if comment is wanted to be posted!");
            }

            return ValidationResult.Success;
        }
    }
}