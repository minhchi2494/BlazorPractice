using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Pages
{
    public class CustomValidatorAttribute : ValidationAttribute
    {
        public string Validation { get; set; }
        private const string ValidationMessage = "The filed ShortName must be a string or array type with a maximum length of 40";

        public CustomValidatorAttribute() : base(ValidationMessage)
        {
            Validation = Validation;
        }

        protected override ValidationResult IsValid(object shortname, ValidationContext validationContext)
        {
            var content = shortname.ToString().Length;
            if (content.ToString().Length > 40)
            {
                return null;
            }
            return new ValidationResult(FormatErrorMessage(ValidationMessage), new[]
            {
                validationContext.MemberName
            });
        }

    }
}
