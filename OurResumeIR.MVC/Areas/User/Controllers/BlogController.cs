using CleanArch.Store.Application.Extention;
using CleanArch.Store.Application.Static;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.Static;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.MVC.Controllers;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class BlogController(IBlogService _blogService) : BaseController
    {


        public async Task<IActionResult> BlogList() => View(await _blogService.GetAllBlogForView());


        [HttpGet]
        public async Task<IActionResult> AddBlog() => View(new CreateBlogPostViewModel());
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBlog(CreateBlogPostViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            string userId = User.GetUserId();
            var result = await _blogService.CreateBlogAsync(viewModel, userId);
            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Blog,
                    UserPanelMessage.MessageType.AddError));
                return RedirectToAction("BlogList");
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Blog,
                UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(BlogList)));
            return RedirectToAction("BlogList");


        }


        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            var model = await _blogService.GetBlogForEditView(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBlog(EditBlogPostListViewModel model)
        {
            var userId = User.GetUserId();

            var result = await _blogService.UpdateBlogAsync(model, userId);
            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Blog,
                    UserPanelMessage.MessageType.EditError));

                return RedirectToAction(nameof(BlogList));
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Blog,
                UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(BlogList)));
            return RedirectToAction(nameof(BlogList));

        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var userId = User.GetUserId();

            var result = await _blogService.DeleteBlogAsync(id, userId);
            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Blog,
                    UserPanelMessage.MessageType.DeleteError));
                return RedirectToAction(nameof(BlogList));
            }

            SendSuccessMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Blog,
                UserPanelMessage.MessageType.DeleteSuccess)
                , Url.ActionLink(nameof(BlogList)));
            return RedirectToAction(nameof(BlogList));
        }
    }
}
