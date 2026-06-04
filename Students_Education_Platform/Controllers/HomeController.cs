using System.Diagnostics;
using Final_Project_ITI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ITI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult index()
        {
            return View();
        }
    }
}
