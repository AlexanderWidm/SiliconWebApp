using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class ContactEntity
{
    [Key]
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public ServiceType? SelectedService { get; set; } 
    public string Message { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}

public enum ServiceType
{
    Service1,
    Service2,
    Service3
}
