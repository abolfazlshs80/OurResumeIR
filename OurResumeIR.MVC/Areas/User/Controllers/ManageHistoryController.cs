using CleanArch.Store.Application.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Application.ViewModels.History;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageHistoryController : Controller
    {
        private IHistoryService _historyService;
        public ManageHistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        public async Task<IActionResult> HistoryList()
        {
            var model = await _historyService.GetAlHistoryForListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddHistory()
        {
            return View();
        }

        [HttpPost]
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
                TempData["ErrorMessage"] = "ثبت تجربه با شکست رو برو شد.";
                return RedirectToAction("BlogList");
            }
            TempData["SuccessMessage"] = " تجربه با موفقیت اضافه شد";
            return RedirectToAction("HistoryList");


        }

        [HttpGet]
        public async Task<IActionResult> EditHistory(int id)
        {
            var model = await _historyService.GetHistoryShowForEditAsync(id);
            return View(model);
        }

        [HttpPost]
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
                TempData["ErrorMessage"] = "ویرایش تجربه با شکست رو برو شد.";
                return RedirectToAction("BlogList");
            }
            TempData["SuccessMessage"] = " تجربه با موفقیت ویرایش شد";

            return RedirectToAction("HistoryList");


        }

        public Task<IActionResult> DeleteHistory(int id) 
        {

            return RedirectToAction("HistoryList");
        }
    }
}
