using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.ViewModels.Blog;

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

        [HttpGet]
        public async Task<IActionResult> AddBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(CreateBlogPostViewModel viewModel)
        {
            // ثبت مقادیر داخل ویو از طریق صدا زدن متد داخل سرویس
            if (!ModelState.IsValid) 
            {
                return View(viewModel);
            }


            RedirectToAction("Index");
        }
    }
}
