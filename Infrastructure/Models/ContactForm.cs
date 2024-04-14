using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class ContactForm
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string FullName { get; set; } = null!;
    public ServiceType? SelectedService { get; set; }
    [Required]
    public string Message { get; set; } = null!;
}

public enum ServiceType
{
    Service1,
    Service2,
    Service3
}
