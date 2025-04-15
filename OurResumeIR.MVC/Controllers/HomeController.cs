using Microsoft.AspNetCore.Mvc;
using OurResumeIR.Domain.Interfaces;
using OurResumeIR.MVC.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace OurResumeIR.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [Route("/")]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
               // var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            return View();
       
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
