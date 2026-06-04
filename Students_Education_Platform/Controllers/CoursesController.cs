using Students_Education_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Students_Education_Platform.Controllers
{
    public class CoursesController : Controller
    {
        private readonly MyContext db = new MyContext();

        // GET: Courses
        public IActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department).ToList();
            return View(courses);
        }

        // GET: Courses/Details/5
        public IActionResult Details(int id)
        {
            var course = db.Courses
                .Include(c => c.Department)
                .Include(c => c.Exams)
                .FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewBag.DeptList = db.Departments.ToList();
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public IActionResult Create(Course course)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DeptList = db.Departments.ToList();
            return View(course);
        }

        // GET: Courses/Edit/5
        public IActionResult Edit(int id)
        {
            var course = db.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            ViewBag.DeptList = db.Departments.ToList();
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                db.Courses.Update(course);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DeptList = db.Departments.ToList();
            return View(course);
        }

        // GET: Courses/Delete/5
        public IActionResult Delete(int id)
        {
            var course = db.Courses.Include(c => c.Department).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = db.Courses.Find(id);
            if (course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
