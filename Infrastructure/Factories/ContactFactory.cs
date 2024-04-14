using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ContactFactory
{
    public static ContactEntity Create(ContactForm form)
    {
        var datetime = DateTime.Now;
        try
        {
            return new ContactEntity
            {
                Email = form.Email,
                FullName = form.FullName,
                SelectedService = (Infrastructure.Entities.ServiceType?)form.SelectedService,
                Message = form.Message,
                Created = datetime,
                Modified = datetime,
            };
        }
        catch { }
        return null!;
    }
}