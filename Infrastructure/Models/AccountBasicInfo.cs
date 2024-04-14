using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AccountBasicInfo
{
    [Display(Name = "First name", Prompt = "Enter your first name")]
    [Required(ErrorMessage = "Please enter a first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;

    [Display(Name = "First name", Prompt = "Enter your last name")]
    [Required(ErrorMessage = "Please enter a last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "Please enter an email address")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "A valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your phone number")]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "A valid phone number is required")]
    [MinLength(5, ErrorMessage = "A valid phone number is required")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Bio (Optional)", Prompt = "Add a short bio...")]
    public string? Biography { get; set; }
}
    