using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMVCStudentDaoService.Dao;
using WebMVCStudentDaoService.Models;

namespace WebMVCStudentDaoService.Controllers
{
    public class StudentController : Controller
    {
        private IStudentDao studentDao;

        public StudentController(IStudentDao studentDao) 
        {
            this.studentDao = studentDao;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(studentDao.Get());
        }

        [Route("searchPerson/{search:minlength(3)}")]
        public IActionResult Search(string search)
        {
            return View("Index", studentDao.Allow.Where(c => c.Name!.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studentDao.Get(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    studentDao.Add(student);
                    return RedirectToAction(nameof(Index));
                }
                return View(student);

            }
            catch
            {
                ModelState.AddModelError("Save", "Error saving in db");
                return View(student);
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(studentDao.Get(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    student.Id = id;
                    studentDao.Update(student);
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    return View(student);
                }
            }
            catch
            {
                ModelState.AddModelError("Save", "Error saving in db");
                return View(student);
            }
        }

        // GET: StudentController/Delete/5
        [ActionName("Delete")]
        public ActionResult ShowDeleteConfirm(int id)
        {
            return View(studentDao.Get(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                studentDao.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(studentDao.Get(id));
            }
        }
    }
}
