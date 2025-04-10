using Microsoft.AspNetCore.Mvc;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult DeleteProfile()
        {
            return RedirectToAction("Dashboard");
        }
    }
}
