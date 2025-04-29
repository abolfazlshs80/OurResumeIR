using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Application.ViewModels.MySkills;

namespace OurResumeIR.MVC.ViewComponents.Handler.Home
{
    public class MySkillHomeViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(ICollection< MySkillsForListViewModel> model)
        {

            return View("/ViewComponents/Views/Home/myskill.cshtml", model);
        }

    }
}
