using Final_Project_ITI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_ITI.Controllers
{
    public class UserController : Controller
    {
        MyContext db =new MyContext();
        #region Create User
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View("CreateUser");
        }

        [HttpPost]
        public IActionResult AddUser(User us)
        {
            if (us.Name != null && ModelState.IsValid)
            {
                db.Users.Add(us);
                db.SaveChanges();
                return RedirectToAction("LoginUser");
            }
            return View("CreateUser", us);
        }
        #endregion

        #region Login user
        public IActionResult LoginUser()
        {
            return View();
        }
        public IActionResult LoginUserV1(User user)
        {
            foreach (var item in db.Users)
            {
                if(item.Name == user.Name && item.Password == user.Password)
                {
                    return RedirectToAction("Getall","Student");
                }
            }
            return Content("Failed");
        }

        #endregion
    }
}
