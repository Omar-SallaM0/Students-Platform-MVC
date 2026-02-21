using Final_Project_ITI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ITI.Controllers
{
    public class DepartmentController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult GetallDepartment()
        {
            var Departments = db.Departments.ToList();
            return View(Departments);
        }
        #region Create Department
        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View("CreateDepartment");
        }

        [HttpPost]
        public IActionResult addDept(Department Dept)
        {
            if (Dept.DeptName != null)
            {
                db.Departments.Add(Dept);
                db.SaveChanges();
                return RedirectToAction("GetallDepartment");
            }
            return View("CreateDepartment", Dept);
        }
        #endregion

        #region Edit Department
        public IActionResult EditDept(int id)
        {
            var Dept = db.Departments.FirstOrDefault(c => c.Id == id);
            return View(Dept);
        }
        [HttpPost]
        public IActionResult Editv2(Department Dept)
        {
            if (Dept.DeptName != null)
            {
                db.Departments.Update(Dept);
                db.SaveChanges();
                return RedirectToAction("GetAllDepartment");
            }
            return View("EditDept");
        }
        #endregion
        #region Details
        public IActionResult DepartmentDetails(int id)
        {
            var Dept = db.Departments.FirstOrDefault(c => c.Id == id);

            return View(Dept);
        }
        #endregion
        #region Delete Department
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Dept = db.Departments.FirstOrDefault(c => c.Id == id); ;
            db.Departments.Remove(Dept);
            db.SaveChanges();
            return RedirectToAction("GetAllDepartment");
        }
        #endregion
    }
}
