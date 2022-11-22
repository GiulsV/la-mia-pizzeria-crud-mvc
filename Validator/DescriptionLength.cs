using System.ComponentModel.DataAnnotations;


namespace la_mia_pizzeria_model.Validator
{
    public class DescriptionLength : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string fieldValue = (string)value;

            if (fieldValue == null)
            {
                return new ValidationResult("Inserire almeno cinque parole");
            }
            string[] fieldValueArr = fieldValue.Split(' ');
            if (fieldValueArr.Length < 5)
            {
                return new ValidationResult("Inserire almeno cinque parole");
            }

            return ValidationResult.Success;
        }
    }
}