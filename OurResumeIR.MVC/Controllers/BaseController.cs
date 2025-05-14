using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.MVC.Models;
using System.Diagnostics;
using System.Security.Claims;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.ContactUs;

namespace OurResumeIR.MVC.Controllers
{
    public class BaseController : Controller
    {

        public void SendSampleMessage(string title, string message)
        {
            TempData["SampleMessage"] = true;
            TempData["SampleMessageTitle"] =title ;
            TempData["SampleMessageText"] = message;
          
        }
        public void SendSuccessMessage(string title, string link)
        {
           
            TempData["SuccessMessage"] = title;
            TempData["SuccessMessageLink"] = link;

        }

        public void DisplayBlog(string title, string text,string imagePath)
        {

            TempData["BlogTitle"] = title;
            TempData["BlogText"] = text;
            TempData["BlogImage"] = imagePath;

        }
        public void SendErrorMessage(string title)
        {

            TempData["ErrorMessage"] = title;


        }
    }
}
