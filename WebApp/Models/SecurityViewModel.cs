using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class SecurityViewModel
{
    [Display(Name = "Current Password", Prompt = "Enter your current password")]
    [Required(ErrorMessage = "Please your current password")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;


    [Display(Name = "New Password", Prompt = "Enter your new password")]
    [Required(ErrorMessage = "Please enter a new password")]
    [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$", ErrorMessage = "A valid password is required")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    [Display(Name = "Confirm new password", Prompt = "Confirm your new password")]
    [Required(ErrorMessage = "New password must be confirmed")]
    [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
    [DataType(DataType.Password)]
    public string ConfirmNewPassword { get; set; } = null!;
}

