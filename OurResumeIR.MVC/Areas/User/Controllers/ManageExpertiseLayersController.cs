using Microsoft.AspNetCore.Mvc;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class ManageExpertiseLayersController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
