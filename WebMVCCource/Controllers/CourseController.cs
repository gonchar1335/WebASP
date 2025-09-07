using Microsoft.AspNetCore.Mvc;
using WebMVCCource.Models;


namespace WebMVCCource.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View(Course.All);
        }

        [Route("search/{search:minlength(3)}")]
        public IActionResult Search(string search)
        {
            return View("Index", Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        public IActionResult ListJSON() 
        {
            return new JsonResult(Course.All);
        }
    }
}
