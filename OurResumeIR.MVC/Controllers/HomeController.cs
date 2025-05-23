﻿using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.MVC.Models;
using System.Diagnostics;
using System.Security.Claims;
using CleanArch.Store.Application.Extention;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.ContactUs;
using Microsoft.Extensions.Options;
using OurResumeIR.Infrastructure.Models.AppSettings;

namespace OurResumeIR.MVC.Controllers
{
    public class HomeController (IUserService userService,IBlogService blogService,IContactUsService contactUsService, IOptions<PainginagtionViewModel> Options) : BaseController
    {
     
        [Route("/{slug}")]
        [Route("/")]
        public async Task< IActionResult> Index(string? slug)
        {
        
            //if (string.IsNullOrEmpty(slug))
            //    return Error();
            string userId=string.Empty;
          
            if (User.Identity.IsAuthenticated && string.IsNullOrEmpty(slug))
                userId = User.GetUserId();
            var model =await userService.LoadResume(slug, userId);

            return View(model);
       
        }
        [Route("/blog/{id}")]
        
        public async Task<IActionResult> FindBlog(int id)
        {
            var model = await blogService.GetBlogForEditView(id);
            if(model==null) return Error();
            DisplayBlog(model.Title, model.Text, model.ImageName.ConvartImagePathForBlog());
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> CreateContactUs(CreateContactUsViewModel model)
        {
            var res = await contactUsService.CreateContactUsAsync(model);
            SendSampleMessage("ثبت اطلاعات", "با موفقیت ثبت شد");
            return RedirectToAction("Index");

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
