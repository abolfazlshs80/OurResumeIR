using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.MVC.Models;
using System.Diagnostics;
using System.Security.Claims;
using OurResumeIR.Application.Services.Interfaces;

namespace OurResumeIR.MVC.Controllers
{
    public class HomeController (IUserService userService): Controller
    {

     
        [Route("/{slug}")]
        [Route("/")]
        public async Task< IActionResult> Index(string slug= "abolfazl")
        {
            //if (string.IsNullOrEmpty(slug))
            //    return Error();
            var model =await userService.LoadResume(slug);

            return View(model);
       
        }


        [Route("{*url}", Order = 999)]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            Response.StatusCode = 404;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
