using System.Security.Claims;
using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.Static;
using OurResumeIR.Application.ViewModels.Document;
using OurResumeIR.Domain.Models;
using OurResumeIR.MVC.Controllers;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageDocumentController(IDocumentService DocumentService) : BaseController
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
            model.UserId = User.GetUserId();
            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDocumentVM viewmodel)
        {
           

            if (!ModelState.IsValid)
                return View(viewmodel);

            var status = await DocumentService.Create(viewmodel);

            if (!status)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Document,
                    UserPanelMessage.MessageType.AddError));

                return View(viewmodel);
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Document,
                UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(Index)));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var model = await DocumentService.GetUpdate(Id);
            model.UserId = User.GetUserId();
            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateDocumentVM viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            var status = await DocumentService.Update(viewmodel);
  
            if (!status)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.Document,
                    UserPanelMessage.MessageType.EditError));

                return View(viewmodel);
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.Document,
                UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(Index)));
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Delete(int id)
        {
          var status=  await DocumentService.Delete(id);
          if (!status)
          {
              SendErrorMessage(UserPanelMessage.GetMessage(
                  UserPanelMessage.Document,
                  UserPanelMessage.MessageType.DeleteError));
              return RedirectToAction(nameof(Index));
            }

          SendSuccessMessage(UserPanelMessage.GetMessage(
                  UserPanelMessage.Document,
                  UserPanelMessage.MessageType.DeleteSuccess)
              , Url.ActionLink(nameof(Index)));
          return RedirectToAction(nameof(Index));
           
        }
          

    }
}
