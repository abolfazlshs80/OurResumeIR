using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Domain.Models;

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

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var model =await DocumentService.GetUpdate(Id);
           model.UserId  = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateDocumentVM viewmodel)
        {
           

            if (!ModelState.IsValid)
                return View(viewmodel);

            var status = await DocumentService.Update(viewmodel);
            if (status)
                return RedirectToAction("Index");
            return View(viewmodel);
        }
        public async Task<IActionResult> Delete(int id)
        {
          await DocumentService.Delete(id);
            return RedirectToAction("Index");
        }

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

    }
}
