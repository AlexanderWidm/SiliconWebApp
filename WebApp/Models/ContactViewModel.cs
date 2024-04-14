namespace WebApp.Models;
using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;

public class ContactViewModel
{
    [Display(Name = "First name", Prompt ="Enter your full name")]
    [Required(ErrorMessage = "Please enter a full name")]
    [MinLength(2, ErrorMessage = "A valid full name is required")]
    [DataType(DataType.Text)]
    public string FullName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [Required(ErrorMessage = "Please enter an email address")]
    [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$", ErrorMessage = "A valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    public ServiceType SelectedService { get; set; }

    [Display(Name = "Message", Prompt = "Enter a message")]
    [Required(ErrorMessage = "Please enter a message")]
    public string Message { get; set; } = null!;
}

public enum ServiceType
{
    Service1,
    Service2,
    Service3
}