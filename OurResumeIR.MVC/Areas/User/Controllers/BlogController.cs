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
            var model = await _blogService.GetAllBlogForView();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddBlog()
        {
            return View(new CreateBlogPostViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(CreateBlogPostViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            string userId = User.GetUserId();
        var result =  await _blogService.CreateBlogAsync(viewModel, userId);
            if (!result)
            {
                TempData["ErrorMessage"] = " ثبت مقاله با شکست رو برو شد .";
                return RedirectToAction("BlogList");
            }
            TempData["SuccessMessage"] = "مقاله با موفقیت اضافه شد.";
            return RedirectToAction("BlogList");

     
        }


        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            var model = await _blogService.GetBlogForEditView(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlog(EditBlogPostListViewModel model)
        {
            var userId = User.GetUserId();

          var result =  await _blogService.UpdateBlogAsync(model, userId);
            if (!result)
            {
                TempData["ErrorMessage"] = "ویرایش مقاله ناموفق بود!";
                return RedirectToAction("BlogList");
            }
            TempData["SuccessMessage"] = "مقاله با موفقیت ویرایش شد!";
            return RedirectToAction("BlogList");
        
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var userId = User.GetUserId();

            var result = await _blogService.DeleteBlogAsync(id, userId);
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
