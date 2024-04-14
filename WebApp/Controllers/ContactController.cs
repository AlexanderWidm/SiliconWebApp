using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;


    [HttpGet]
    [Route("/contact")]
    public IActionResult Contact()
    {
        ViewData["HeaderClass"] = "header-on-contact";
        var viewModel = new ContactViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/contact")]
    public async Task<IActionResult> Contact(ContactViewModel viewModel)
    {
        ViewData["HeaderClass"] = "header-on-contact";
        if (ModelState.IsValid)
        {
            var jsonContent = JsonConvert.SerializeObject(viewModel);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("https://localhost:7266/api/Contact", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Your message has been sent successfully.";
                return RedirectToAction("Contact", "Contact");
            }
            else
            {
                TempData["ErrorMessage"] = "There was an issue with your submission.";
                return View(viewModel);
            }
        }


        return View(viewModel);
    }
}