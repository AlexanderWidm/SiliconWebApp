using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManage) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManage;

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
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        //gör något if valid (spara i databas, redirect user)
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
            {
                var userEntity = new UserEntity
                {
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Email = viewModel.Email,
                    UserName = viewModel.Email
                };

                var result = await _userManager.CreateAsync(userEntity, viewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Auth");
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong. Please try again";
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User with the same email address already exists";
            }
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
    public IActionResult SignIn(SignInViewModel viewModel)
    {
        //gör något if valid (spara i databas, redirect user)
        if (ModelState.IsValid)
        {

        }
        //annars returnera detta
        return View(viewModel);
    }
    #endregion

    #region CotactForm
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
    public IActionResult Contact(ContactViewModel viewModel)
    {
        
        if (ModelState.IsValid)
        {
            ViewData["HeaderClass"] = "header-on-contact";
            return RedirectToAction("Success");
        }
        ViewData["HeaderClass"] = "header-on-contact";
        return View(viewModel);
    }

    public IActionResult Success()
    {
        return View();
    }
}
#endregion