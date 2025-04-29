using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Application.ViewModels.MySkills;

namespace OurResumeIR.MVC.ViewComponents.Handler.Home
{
    public class MyDocumentHomeViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(ICollection< DocumentVM> model)
        {

            return View("/ViewComponents/Views/Home/mydocument.cshtml", model);
        }

    }
}
