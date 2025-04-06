using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.ViewModels;

namespace OurResumeIR.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var result = await _userService.RegisterUser(register);

            switch (result)
            {
                case RegisterResult.Success:
                    ViewBag.Message = "ثبت نام شما با موفقیت انجام شد";
                    return View(register);
                case RegisterResult.DupplicateEmail:
                    ViewBag.Message = "ایمیل وارد شده قبلا ثبت نام کرده است";
                    return View(register);
                case RegisterResult.UnequalPassAndRePass:
                    ViewBag.Message = "رمز و تکرار رمز برابر نیستند";
                    return View(register);
                default:
                    break;
            }

            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
