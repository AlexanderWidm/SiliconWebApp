using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;



public class AuthController(UserManager<UserEntity> userManage, SignInManager<UserEntity> signInManager) : Controller
{

    private readonly UserManager<UserEntity> _userManager = userManage;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


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
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Default");
                }
            }
        }

        ViewData["StatusMessage"] = "Incorrect email or password. Please try again.";
        return View(model);
    }

    #endregion

    #region SignOut

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("SignIn", "Auth");
    }


    #endregion

    #region ContactForm
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