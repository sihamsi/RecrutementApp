using System.Diagnostics;
using E_Recrutement.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Recrutement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            // Remove this line: errorViewModel.ShowRequestId = !string.IsNullOrEmpty(errorViewModel.RequestId);
            return View(errorViewModel);
        }

    }
}
