using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class UserController(IUserService _userService) : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> UploadImageProfile(IFormFile file)
        {
            var result = await _userService.UploadProfile(file, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return RedirectToAction("Dashboard");
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
