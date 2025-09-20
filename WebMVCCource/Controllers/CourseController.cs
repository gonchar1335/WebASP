using Microsoft.AspNetCore.Mvc;
using WebMVCCource.Models;
using WebMVCCource.Filters;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebMVCCource.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            this.ViewBag.CourseSearchPattern = this.HttpContext.Session.GetString("courseSearchPattern") ?? "";
            ViewData["YEAR"] = DateTime.Now.Year;
            return View(Course.All);
        }

        [Route("search/{search:minlength(3)}")]
        public IActionResult Search(string search)
        {
            this.HttpContext.Session.SetString("courseSearchPatter", search);
            this.ViewBag.CourseSearchPattern = search ?? "";
            return View("Index", Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        public IActionResult ListJSON() 
        {
            return new JsonResult(Course.All);
        }

        [HttpPost]
        public IActionResult Filter(string search)
        {
            this.HttpContext.Session.SetString("courseSearchPattern", search);
            this.ViewBag.CourseSearchPattern = search ?? "";
            return View("Index", Course.All.Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                if (course.Id <= Course.All.Select(c => c.Id).Max())
                    ModelState.AddModelError("Id", "Id less or equal then max id");
                if (this.ModelState.IsValid)
                {
                    Course.All.Add(course);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //ViewBag.ErrorMessage = "Data error";
                    //foreach (var err in ModelState)
                    //{
                    //    if (err.Value.ValidationState == ModelValidationState.Invalid)
                    //    {
                    //        ViewBag.ErrorMessage += $"Invalid property: {err.Key}";
                    //        foreach (var err2 in err.Value.Errors)
                    //        {
                    //            ViewBag.ErrorMessage += $"{err2.ErrorMessage}";
                    //        }
                    //    }
                    //}

                    return View(course);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
