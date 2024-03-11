using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController : Controller
{

    #region SignUp

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    //Den här måste ha en model i sig, i detta fall SignUpViewModel
    public IActionResult SignUp(SignUpViewModel viewModel)
    {
        //gör något if valid (spara i databas, redirect user)
        if (ModelState.IsValid)
        {

        }
        //annars returnera detta
        return View(viewModel);
    }

    #endregion

    #region SignIn
    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [Route("/signin")]
    //Den här måste ha en model i sig, i detta fall SignUpViewModel
    public IActionResult SignIn(SignUpViewModel viewModel)
    {
        //gör något if valid (spara i databas, redirect user)
        if (ModelState.IsValid)
        {

        }
        //annars returnera detta
        return View(viewModel);
    }
    #endregion
}