using System.Security.Claims;
using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.History;
using OurResumeIR.MVC.Controllers;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageContactUsController(IContactUsService contactUsService) : BaseController
    {
     

        public async Task<IActionResult> Index()
        {
      
            var model = await contactUsService.GetAllAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(model);
        }
        public async Task<IActionResult> ReplayMessage(int id)
        {

            return RedirectToAction(nameof(Index));
        }
    }
}
