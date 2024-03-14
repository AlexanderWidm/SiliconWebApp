using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }

    [Route("/ErrorNotFound")]
    public IActionResult ErrorNotFound()
    {
        return View();
    }
}
