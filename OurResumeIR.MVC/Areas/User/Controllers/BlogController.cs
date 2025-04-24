using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBlog()
        {
            return View();
        }
    }
}
