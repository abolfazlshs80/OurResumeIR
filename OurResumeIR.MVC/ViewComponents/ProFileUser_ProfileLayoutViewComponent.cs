
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Infra.Data.Context;

namespace SlideCloud.ViewComponents
{
    public class ProFileUser_ProfileLayoutViewComponent
        (IUserService _userService)
        : ViewComponent
    {
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
   
            return View("~/Views/Shared/Components/User/Layout/ProFileUser_ProfileLayoutView.cshtml");
        }
        
    }
}
