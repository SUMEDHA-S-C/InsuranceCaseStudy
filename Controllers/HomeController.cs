using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
            //return RedirectToAction("AddDetails","Policies");
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            if(userName.Equals("Admin") && password.Equals("Admin@123"))
            {
                Session["UserName"] = userName;
                return RedirectToAction("AddDetails", "Policies");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("UserName");
            return RedirectToAction("Index","Home");
        }
    }
}