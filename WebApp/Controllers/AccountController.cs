using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

[Authorize]
public class AccountController(AccountService accountService, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly AccountService _accountService = accountService;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


    public async Task<IActionResult> Details()
    {
        var user = await _accountService.GetUserAsync(User);

        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountBasicInfo
            {
                FirstName = user.FirstName!,
                LastName = user.LastName!,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Biography = user.Bio,
            },
            AddressInfo = new AccountAddressInfo
            {
                AddressLine_1 = user.AddressLine_1!,
                AddressLine_2 = user.AddressLine_2,
                PostalCode = user.PostalCode!,
                City = user.City!,
            }
        };


        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Security()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Security(SecurityViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("SingIn", "Auth");
        }

        if (model.NewPassword != model.ConfirmNewPassword)
        {
            TempData["ErrorMessage"] = "The new password and confirmation password do not match.";
            return View(model);
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (!changePasswordResult.Succeeded)
        {
            TempData["ErrorMessage"] = "An error occurred while changing your password.";
            return View(model);
        }


        TempData["StatusMessage"] = "Your password has been changed successfully.";
        return RedirectToAction("Security", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAccount()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            TempData["ErrorMessage"] = "User not found.";
            return RedirectToAction("SignIn", "Auth");
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            TempData["ErrorMessage"] = "Error deleting account.";
            return RedirectToAction("Security", "Account");
        }

       
        await _signInManager.SignOutAsync(); 
        TempData["StatusMessage"] = "Account deleted successfully.";
        return RedirectToAction("Home", "Default"); 
    }



    [HttpPost]
    public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
    {
            if (model.BasicInfo != null)
            {
                if (!string.IsNullOrEmpty(model.BasicInfo.FirstName) && !string.IsNullOrEmpty(model.BasicInfo.LastName))
                {
                    var result = await _accountService.UpdateBasicInfoAsync(User, model.BasicInfo);
                    TempData["StatusMessage"] = "Account details saved";
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong. Please try again";
                }
            }
        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAddressInfo(AccountDetailsViewModel model)
    {
        if (model.AddressInfo != null)
        {
            if (!string.IsNullOrEmpty(model.AddressInfo.AddressLine_1) && !string.IsNullOrEmpty(model.AddressInfo.PostalCode) && !string.IsNullOrEmpty(model.AddressInfo.City))
            {
                var result = await _accountService.UpdateAddressInfoAsync(User, model.AddressInfo);
            }
            else
            {
                ViewData["StatusMessage"] = "Something went wrong. Please try again";
            }
        }

        return RedirectToAction("Details", "Account");
    }



    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);
        return RedirectToAction("Details", "Account");
    }
}
