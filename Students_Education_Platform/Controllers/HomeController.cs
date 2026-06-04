using System.Diagnostics;
using Students_Education_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace Students_Education_Platform.Controllers
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
