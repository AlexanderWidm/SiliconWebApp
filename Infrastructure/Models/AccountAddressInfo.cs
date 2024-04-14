using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class AccountAddressInfo
{
    [Display(Name = "Address line 1", Prompt = "Enter your address")]
    [Required(ErrorMessage = "Please enter an address")]
    [MinLength(2, ErrorMessage = "A valid address is required")]
    [DataType(DataType.Text)]
    public string AddressLine_1 { get; set; } = null!;

    [Display(Name = "Address line 2 (optional)", Prompt = "Enter your second address line")]
    public string? AddressLine_2 { get; set; }

    [Required(ErrorMessage = "You must enter a city")]
    [Display(Name = "City", Prompt = "Enter your city")]
    [MinLength(2, ErrorMessage = "A valid city is required")]
    [DataType(DataType.Text)]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a postal code")]
    [Display(Name = "Postal code", Prompt = "Enter your postal code")]
    [MinLength(5, ErrorMessage = "A valid postal code is required")]
    [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "A valid postal code is required")]
    [DataType(DataType.Text)]
    public string PostalCode { get; set; } = null!;
}