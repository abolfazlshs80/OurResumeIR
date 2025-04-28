using Microsoft.AspNetCore.Mvc;

namespace OurResumeIR.MVC.Areas.User.Controllers
{
    public class ManageHistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddHistory()
        {
            return View();
        }
    }
}
