using Microsoft.AspNetCore.Mvc;
using Labs4.Models;

namespace Labs4.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(Student.All);
        }

        public IActionResult Details(int id) 
        {
            var student = Student.All.Where(s => s.Id == id).SingleOrDefault();
            if (student == null) return NotFound();
            return View(student);
        }
    }
}
