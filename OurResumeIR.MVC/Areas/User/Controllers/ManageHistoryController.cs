using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.ViewModels.History;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ManageHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
            return View();
        }
    }
}
