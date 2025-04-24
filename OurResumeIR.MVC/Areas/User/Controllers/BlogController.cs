using Microsoft.AspNetCore.Mvc;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
