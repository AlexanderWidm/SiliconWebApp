namespace WebApp.Models;
using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;

public class ContactViewModel
{
    [Required(ErrorMessage = "Please enter your full name")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Please enter your email address")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = null!;

    public ServiceType SelectedService { get; set; }

    [Required(ErrorMessage = "Please enter your message")]
    public string Message { get; set; } = null!;
}

public enum ServiceType
{
    Service1,
    Service2,
    Service3
}