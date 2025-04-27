using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Document;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageDocumentController(IDocumentService DocumentService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await DocumentService.GetAll(userId);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new CreateDocumentVM();
            model.UserId= User.FindFirstValue(ClaimTypes.NameIdentifier);;
            return View(model);

        }
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDocumentVM viewmodel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
                return View(viewmodel);

            var status = await DocumentService.Create(viewmodel);
            if (status)
                return RedirectToAction("Index");
            return View(viewmodel);
        }

        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file != null && file.Length > 0)
        //    {
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        await DocumentService.UploadFile(file, userId);
        //        return Json(new { success = true, message = "فایل با موفقیت آپلود شد." });
        //    }

        //    return Json(new { success = false, message = "هیچ فایلی ارسال نشد." });
        //}

        //[HttpGet]
        //public async Task<IActionResult> Update()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var model = await DocumentService.GetAll(userId);
        //    UpdateDocumentVM viewmodel = new UpdateDocumentVM();
        //    viewmodel.UserId = model.UserId;
        //    viewmodel.Description = model.Description;
        //    viewmodel.Id = model.Id;
        //    return View(viewmodel);

        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(UpdateDocumentVM viewmodel)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    if (!ModelState.IsValid)
        //        return View(viewmodel);

        //    var status = await DocumentService.Update(viewmodel);
        //    if (status)
        //        return RedirectToAction("Index");
        //    return View(viewmodel);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    await DocumentService.Delete(userId);
        //    return RedirectToAction("Index");
        //}
    }
}
