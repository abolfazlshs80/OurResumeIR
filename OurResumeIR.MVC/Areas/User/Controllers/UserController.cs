using System.Security.Claims;
using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.Static;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Domain.Models;
using OurResumeIR.MVC.Controllers;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class UserController(IUserService _userService) : BaseController
    {
        public async Task<IActionResult> Dashboard()
        {
            var model = await _userService.LoadProfile(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UserProfileVM model)
        {
           var userId = User.GetUserId();

            var result = await _userService.UpdateUserProfileAsync(model, userId);

            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.User,
                    UserPanelMessage.MessageType.AddError));
                return RedirectToAction(nameof(Dashboard));
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.User,
                UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(Dashboard)));

            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public async Task<IActionResult> UploadImageProfile(IFormFile file)
        {
            var result = await _userService.UploadProfile(file, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return new JsonResult(result);
        }
        public async Task<IActionResult> UpdateFullName(string FullName)
        {
            var result = await _userService.UpdateFullNameProfile(FullName, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("Dashboard");
        }
        public IActionResult DeleteProfile()
        {
            return RedirectToAction("Dashboard");
        }
    }
}
