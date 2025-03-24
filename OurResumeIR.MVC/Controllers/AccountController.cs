using Microsoft.AspNetCore.Mvc;

namespace OurResumeIR.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPasword()
        {
            return View();
        }
    }
}
