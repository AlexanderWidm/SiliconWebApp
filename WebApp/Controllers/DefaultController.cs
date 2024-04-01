using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    [HttpGet]
    public IActionResult Home()
    {
        return View();
    }

    [Route("/ErrorNotFound")]
    [HttpGet]
    public IActionResult ErrorNotFound()
    {
        return View();
    }
}
