using Students_Education_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Students_Education_Platform.Controllers
{
    public class ExamController : Controller
    {
        private readonly MyContext db = new MyContext();

        // GET: Exam
        public IActionResult Index()
        {
            var exams = db.Exams.Include(e => e.Course).ToList();
            return View(exams);
        }

        // GET: Exam/Details/5
        public IActionResult Details(int id)
        {
            var exam = db.Exams
                .Include(e => e.Course)
                .FirstOrDefault(e => e.Id == id);

            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exam/Create
        public IActionResult Create()
        {
            ViewBag.CourseList = db.Courses.ToList();
            return View();
        }

        // POST: Exam/Create
        [HttpPost]
        public IActionResult Create(Exam exam)
        {
            ModelState.Remove("Course");
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CourseList = db.Courses.ToList();
            return View(exam);
        }

        // GET: Exam/Edit/5
        public IActionResult Edit(int id)
        {
            var exam = db.Exams.Find(id);
            if (exam == null)
            {
                return NotFound();
            }

            ViewBag.CourseList = db.Courses.ToList();
            return View(exam);
        }

        // POST: Exam/Edit/5
        [HttpPost]
        public IActionResult Edit(Exam exam)
        {
            ModelState.Remove("Course");
            if (ModelState.IsValid)
            {
                db.Exams.Update(exam);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CourseList = db.Courses.ToList();
            return View(exam);
        }

        // GET: Exam/Delete/5
        public IActionResult Delete(int id)
        {
            var exam = db.Exams.Include(e => e.Course).FirstOrDefault(e => e.Id == id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // POST: Exam/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var exam = db.Exams.Find(id);
            if (exam != null)
            {
                db.Exams.Remove(exam);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
