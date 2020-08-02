using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartGym.View_Models;
using System.Data.Entity;
using SmartGym.Models;

namespace SmartGym.Controllers
{
    public class HomeController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        public ActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
        

            HomeView homeView = new HomeView
            {
                newMembers = 0,
                totMembers = db.Members.Count(),
                attendance = (0 / db.Members.Count()),
                monthlyPayments = 40000,
                memberShips = db.MemberShips.ToList()
        };

            return View(homeView);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["exampleInputEmail"];
            string password = form["exampleInputPassword"];

            var emp = db.Employees.Where(a => a.email.Equals(email) && a.password.Equals(password)).FirstOrDefault();

            try
            {
                if (emp != null)
                {
                    Session["email"] = email;
                    Session["id"] = emp.id;

                    return RedirectToAction("Index");

                }
            } catch(Exception Ex)
            {
                ViewBag.Error = Ex.Message;
                return View("Error");
            }

            ModelState.AddModelError("LoginError", "Invalid username or password");
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
    }
}