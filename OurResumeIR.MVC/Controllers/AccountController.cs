using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Application.Services.Interfaces;
using OurResumeIR.Domain.Enums;
using OurResumeIR.Domain.Models;
using OurResumeIR.Domain.ViewModels;

namespace OurResumeIR.MVC.Controllers
{
    public class AccountController : Controller
    {
        private  IUserService _userService;
        private  SignInManager<User> _signInManager;
        public AccountController(IUserService userService , SignInManager<User> signInManager)
        {
            _userService = userService;
            _signInManager = signInManager;
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _userService.LoginUser(model);

            switch (result)
            {
                case LoginResult.Success:
                    return RedirectToAction("Index", "Home");

                case LoginResult.UserNotFound:
                    ModelState.AddModelError("", "کاربری با این ایمیل یافت نشد.");
                    break;

                case LoginResult.InvalidPassword:
                    ModelState.AddModelError("", "رمز عبور اشتباه است.");
                    break;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
