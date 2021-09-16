using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Models
{
    public class HomeController : Controller
    {
        Database1 db = new Database1();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User us)
        {
            db.User.Add(us);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User us)
        {
            var obj = db.User.Where(X => X.User_Name.Equals(us.User_Name) && X.Password.Equals(us.Password)).FirstOrDefault();
           if(obj != null)
            {
                return RedirectToAction("Employ");

            }
           else if (us.User_Name == "admin" && us.Password == "admin")
                return RedirectToAction("admin");

            return View();
        }
        public ActionResult Employ()
        {
            return View();

        }
        public ActionResult admin()
        {
            return View();

        }
    }
}