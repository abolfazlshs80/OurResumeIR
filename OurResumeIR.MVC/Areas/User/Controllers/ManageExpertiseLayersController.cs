using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Experience;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class ManageExpertiseLayersController(IExpertiseLayersService expertiseLayersService, IMapper mapper) : Controller
    {
        public async Task<IActionResult> List()
        {
            var list = await expertiseLayersService.GetAll();

            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateExpertiseLayerVM model)
        {
            if (!ModelState.IsValid)
                return View(model);


            bool status = await expertiseLayersService.Create(model);
            if (status)
                return RedirectToAction("List");

            return View(model);
        }


    }
}
