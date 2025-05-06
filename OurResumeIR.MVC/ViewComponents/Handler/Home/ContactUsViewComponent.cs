using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.AboutMe;
using OurResumeIR.Application.ViewModels.Account;
using OurResumeIR.Application.ViewModels.ContactUs;

namespace OurResumeIR.MVC.ViewComponents.Handler.Home
{
    public class ContactUsViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(UserResumeVM model)
        {

            var newmodel = new CreateContactUsViewModel();
            newmodel.UserId = model.UserId;
            string viewPath = this.GetDefaultViewPath();
            return View(viewPath, newmodel);
        }

    }
}
