using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Account;

namespace OurResumeIR.MVC.ViewComponents.Handler.Home
{
    public class AboutHomeViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(AboutMeVM model)
        {

            return View("/ViewComponents/Views/Home/about.cshtml", model);
        }

    }
}
