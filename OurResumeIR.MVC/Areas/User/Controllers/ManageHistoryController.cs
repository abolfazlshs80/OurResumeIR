using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.Static;
using OurResumeIR.Application.ViewModels.History;
using OurResumeIR.MVC.Controllers;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageHistoryController(IHistoryService _historyService) : BaseController
    {

        public async Task<IActionResult> HistoryList()=> View(await _historyService.GetAlHistoryForListAsync());


        [HttpGet]
        public async Task<IActionResult> AddHistory()=>View();
        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHistory(AddHistoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userId = User.GetUserId();
            var result = await _historyService.CreateHistoryAsync(model, userId);
            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.History,
                    UserPanelMessage.MessageType.AddError));
                return View(model);
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.History,
                UserPanelMessage.MessageType.AddSuccess), Url.ActionLink(nameof(HistoryList)));
            return RedirectToAction(nameof(HistoryList));

        }

        [HttpGet]
        public async Task<IActionResult> EditHistory(int id)
        {
            var model = await _historyService.GetHistoryShowForEditAsync(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHistory(EditHistoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.GetUserId();
            var result = await _historyService.UpdateHistoryAsync(model, userId);
            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.History,
                    UserPanelMessage.MessageType.EditError));
                return View(model);
            }
            SendSuccessMessage(UserPanelMessage.GetMessage(
                UserPanelMessage.History,
                UserPanelMessage.MessageType.EditSuccess), Url.ActionLink(nameof(HistoryList)));
            return RedirectToAction(nameof(HistoryList));


        }

        public async Task<IActionResult> DeleteHistory(int id) 
        {
            var userId = User.GetUserId();

           var result = await _historyService.DeleteHistoryAsync(id , userId);
        

            if (!result)
            {
                SendErrorMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.History,
                    UserPanelMessage.MessageType.DeleteError));
            
            }

            SendSuccessMessage(UserPanelMessage.GetMessage(
                    UserPanelMessage.History,
                    UserPanelMessage.MessageType.DeleteSuccess)
                , Url.ActionLink(nameof(HistoryList)));
            return RedirectToAction(nameof(HistoryList));
        }
    }
}
