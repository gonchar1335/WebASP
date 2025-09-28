using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCCource.Filters;
using WebMVCCource.Models;

namespace WebMVCCource.Controllers
{
    [TypeFilter(typeof(ExFilter))]
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
            throw new Exception("My Error");
            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ErrorEx(int statusCode)
        {
            ViewBag.StatusCode = statusCode;
            return View();
        }
    }
}
