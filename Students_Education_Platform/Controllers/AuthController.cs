using Students_Education_Platform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Students_Education_Platform.Controllers
{
    public class AuthController : Controller
    {
        private readonly MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, string type)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and Password are required";
                return View();
            }

            if (type == "Student")
            {
                var student = db.Students.FirstOrDefault(s => s.Email == email && s.Password == password);
                if (student != null)
                {
                    HttpContext.Session.SetString("UserType", "Student");
                    HttpContext.Session.SetInt32("UserId", student.Id);
                    HttpContext.Session.SetString("UserName", student.Name);
                    HttpContext.Session.SetString("UserEmail", student.Email);
                    return RedirectToAction("Getall", "Student");
                }
            }
            else // Admin/User
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    // Fallback to name if they entered name
                    user = db.Users.FirstOrDefault(u => u.Name == email && u.Password == password);
                }

                if (user != null)
                {
                    HttpContext.Session.SetString("UserType", "Admin");
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.Name);
                    HttpContext.Session.SetString("UserEmail", user.Email);
                    return RedirectToAction("Getall", "Student");
                }
            }

            ViewBag.Error = "Invalid credentials. Please try again.";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterStudent(Student student)
        {
            ModelState.Remove("Department");
            if (ModelState.IsValid)
            {
                var exists = db.Students.Any(s => s.Email == student.Email);
                if (exists)
                {
                    ModelState.AddModelError("Email", "Email is already registered");
                    ViewBag.Departments = db.Departments.ToList();
                    ViewBag.ActiveTab = "student";
                    return View("Register", student);
                }

                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.Departments = db.Departments.ToList();
            ViewBag.ActiveTab = "student";
            return View("Register");
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                var exists = db.Users.Any(u => u.Email == user.Email || u.Name == user.Name);
                if (exists)
                {
                    ModelState.AddModelError("Email", "Email or Username already exists");
                    ViewBag.Departments = db.Departments.ToList();
                    ViewBag.ActiveTab = "admin";
                    return View("Register");
                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            ViewBag.Departments = db.Departments.ToList();
            ViewBag.ActiveTab = "admin";
            return View("Register");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
    }
}
