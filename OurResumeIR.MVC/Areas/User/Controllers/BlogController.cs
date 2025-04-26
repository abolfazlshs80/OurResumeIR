using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Blog;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> BlogList()
        {
            // گرفتن فیلد نام  و عکس از سرویس برای نمایش داخل لیست
            var model = await _blogService.GetAllBlogForView();
            return View(model);
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

            string userId = User.GetUserId();
            await _blogService.CreateBlogAsync(viewModel, userId);

            return RedirectToAction("BlogList");
        }


        [HttpGet]
        public async Task<IActionResult> EditBlog()
        {
            // گرفتن مقادیر بلاگ از سرویس برای پر کردن فیلدها  و آماده ویرایش بودن

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBlog(int id) 
        {
             var userId = User.GetUserId();

            var result = await _blogService.DeleteBlogAsync(id , userId);
            if (!result)
            {
                TempData["ErrorMessage"] = "حذف مقاله ناموفق بود!";
                return RedirectToAction("BlogList");
            }
            TempData["SuccessMessage"] = "مقاله با موفقیت حذف شد!";
            return RedirectToAction("BlogList");
        }
    }
}
