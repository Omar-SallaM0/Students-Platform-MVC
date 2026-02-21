using Final_Project_ITI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_ITI.Controllers
{
    public class StudentController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult Getall()
        {
            var students = db.Students.Include(e => e.Department).ToList();
            return View(students);
        }
        #region Create Student
        [HttpGet]
        public IActionResult CreateStudent()
        {
            ViewData["DeptList"] = db.Departments.ToList();
            return View("CreateStudent");
        }

        [HttpPost]
        public IActionResult addstd(Student st)
        {
            ModelState.Remove("Department"); // Ignor validate referance .
            if (st.Name != null && ModelState.IsValid)
            {
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Getall");
            }
            ModelState.AddModelError("", "All Filds Required");
            ViewData["DeptList"] = db.Departments.ToList();
            return View("CreateStudent", st);
        }
        #endregion

        #region Edit
        public IActionResult Edit(int id)
        {
            ViewData["DeptList"] = db.Departments.ToList();
            var std = db.Students.Include(e => e.Department).FirstOrDefault(c => c.Id == id);
            return View(std);
        }
        [HttpPost]
        public IActionResult Editv2(Student std)
        {
            if (std.Name != null)
            {
                db.Students.Update(std);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            ViewData["DeptList"] = db.Departments.ToList();
            return View("Edit");
        }
        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            var std = db.Students.Include(e => e.Department).FirstOrDefault(c => c.Id == id);

            return View(std);
        }
        #endregion
        #region Delete Student
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var std = db.Students.Include(e => e.Department).FirstOrDefault(c => c.Id == id); ;
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }
        #endregion
    }
}
