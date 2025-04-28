using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Account;

namespace OurResumeIR.MVC.ViewComponents.Handler.Home
{
    public class HeaderHomeViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(UserResumeVM model)
        {

            return View("/ViewComponents/Views/Home/Header.cshtml", model);
        }

    }
}
