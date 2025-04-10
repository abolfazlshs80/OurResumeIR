using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class ManageExpertiseLayersController(IExpertiseLayersService expertiseLayersService) : Controller
    {
        public async Task< IActionResult> List()
        {
            var list=await expertiseLayersService.GetAll();
            
            return View(list);
        }


        
    }
}
