using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.AboutMe;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageAboutMeController(IAboutMeService aboutMeService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await aboutMeService.GetAll(userId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await aboutMeService.UploadFile(file, userId);
                return Json(new { success = true, message = "فایل با موفقیت آپلود شد." });
            }

            return Json(new { success = false, message = "هیچ فایلی ارسال نشد." });
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await aboutMeService.GetAll(userId);
            UpdateAboutMeVM viewmodel = new UpdateAboutMeVM();
            viewmodel.UserId = model.UserId;
            viewmodel.Description = model.Description;
            viewmodel.Id = model.Id;
            return View(viewmodel);

        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutMeVM viewmodel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
                return View(viewmodel);

            var status = await aboutMeService.Update(viewmodel);
            if (status)
                return RedirectToAction("Index");
            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await aboutMeService.Delete(userId);
            return RedirectToAction("Index");
        }
    }
}
