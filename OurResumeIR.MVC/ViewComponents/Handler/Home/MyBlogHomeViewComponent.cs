using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Application.ViewModels.Blog;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Application.ViewModels.MySkills;
using OurResumeIR.Domain.Models;

namespace OurResumeIR.MVC.ViewComponents.Handler.Home
{
    public class MyBlogHomeViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(ICollection<BlogVM> model)
        {

            return View("/ViewComponents/Views/Home/myBlog.cshtml", model);
        }

    }
}
