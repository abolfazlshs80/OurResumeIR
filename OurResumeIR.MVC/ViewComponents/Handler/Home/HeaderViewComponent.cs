
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Infra.Data.Context;
using System.Security.Claims;

namespace SlideCloud.ViewComponents
{
    public class HeaderViewComponent
        (IUserService _userService)
        : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string userId)
        {

            var model =await _userService.LoadProfile(userId);
            return View("/ViewComponents/Views/Home/Header.cshtml", model);
        }

    }
}
