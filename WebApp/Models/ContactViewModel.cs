namespace WebApp.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ServiceProcess;
using System.Web.Mvc;

public class ContactViewModel
{
    public ContactViewModel()
    {
    }

    public ContactViewModel(IEnumerable<SelectListItem>? serviceOptions)
    {
        ServiceOptions = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Service 1", Value = ServiceType.Service1.ToString()},
            new SelectListItem { Text = "Service 2", Value = ServiceType.Service2.ToString()},
            new SelectListItem { Text = "Service 3", Value = ServiceType.Service3.ToString()}

        };
    }

    [Required(ErrorMessage = "A valid name is required")]
    [Display(Name = "Full Name", Prompt = "Enter your full name")]
    [MinLength(2, ErrorMessage = "A valid name is required")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "A valid email address is required")]
    [EmailAddress]
    [Display(Name = "Email address", Prompt = "Enter your email address")]
    public string Email { get; set; } = null!;

    [Display(Name = "Service", Prompt = "Choose the service you are interested in")]
    public ServiceType SelectedService { get; set; }

    public IEnumerable<SelectListItem>? ServiceOptions { get; set; }
    
    [Display(Name = "Message", Prompt = "Enter your message here")]
    [MinLength(1, ErrorMessage = "A valid message is required")]
    public string? Message { get; set; }


}

public enum ServiceType
{
    Service1,
    Service2,
    Service3
}
