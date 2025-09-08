using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCCource.Models;

namespace WebMVCCource.Controllers
{
    [Route("person")]
    public class StudentController : Controller
    {
        // GET: StudentController
        [Route("index")]
        public ActionResult Index()
        {
            return View(Student.All);
        }

        [Route("searchPerson/{search:minlength(3)}")]
        public IActionResult Search(string search)
        {
            return View("Index", Student.All.Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        [Route("age/{minAge:int}/{maxAge:int}")]
        public IActionResult ByAge(int minAge, int maxAge)
        {
            return View("Index", Student.All.Where(s => s.Age >= minAge && s.Age <= maxAge));
        }

        // GET: StudentController/Details/5
        [Route("details/{id:int}")]

        public ActionResult Details(int id)
        {
            var student = Student.All.Where(s => s.Id == id).SingleOrDefault();
            if (student == null) return NotFound();
            return View(student);
        }

        // GET: StudentController/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                Student.All.Add(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [Route("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [Route("delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
