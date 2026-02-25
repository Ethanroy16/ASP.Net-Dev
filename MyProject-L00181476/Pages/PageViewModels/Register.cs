using System.ComponentModel.DataAnnotations;

namespace MyProject_L00181476.Pages.PageViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]

        public string ConfirmPassword { get; set; }
    }
}
