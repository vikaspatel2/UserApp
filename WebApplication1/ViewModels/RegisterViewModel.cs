using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Name is Required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Name is Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is Password")]
        [StringLength(40, MinimumLength =6, ErrorMessage ="Password must be between 6 and 40 characters")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password and Confirm Password do not match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Name is ConfirmPassword")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
