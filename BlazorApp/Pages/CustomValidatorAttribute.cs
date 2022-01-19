using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Pages
{
    public class CustomValidatorAttribute : ValidationAttribute
    {
        public string ValidDescription { get; set; }
        public string ValidShortName { get; set; }

    }
}
