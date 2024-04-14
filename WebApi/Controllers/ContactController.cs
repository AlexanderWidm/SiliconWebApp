using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(ApiContext context) : ControllerBase
{
    private readonly ApiContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        return Ok(await _context.Contacts.ToListAsync());
    }
    
   
    [HttpPost]
    public async Task<IActionResult> CreateContact(ContactForm contactForm)
    {
        if (ModelState.IsValid)
        {
            if (!await _context.Contacts.AnyAsync(c => c.Email == contactForm.Email))
            {
                try
                {
                    var contactEntity = ContactFactory.Create(contactForm);
                    _context.Contacts.Add(contactEntity);
                    await _context.SaveChangesAsync();
                    return Created("", null);  
                }
                catch
                {
                    return Problem();  
                }
            }

            return Conflict();  
        }

        return BadRequest();  
    }
}