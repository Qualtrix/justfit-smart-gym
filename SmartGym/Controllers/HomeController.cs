using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartGym.View_Models;
using System.Data.Entity;
using SmartGym.Models;
using SmartGym.BusinessLogic;

namespace SmartGym.Controllers
{
    public class HomeController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        public ActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
            HealthService healthService = new HealthService();
            InvoiceService invoiceService = new InvoiceService();

            HomeView homeView = new HomeView
            {
                newMembers = 0,
                avgBMI = healthService.getAvgBMI(),
                totMembers = db.Members.Count(),
                attendance = (0 / db.Members.Count()),
                monthlyPayments = invoiceService.getTotalPayments(),
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
            var member = db.Members.Where(a => a.email.Equals(email) && a.sa_id.Equals(password)).FirstOrDefault();

            try
            {
                if (emp != null)
                {
                    Session["email"] = email;
                    Session["id"] = emp.id;
                    Session["role"] = "emp";

                    return RedirectToAction("Index");

                } else if(emp == null && member != null)
                {
                    Session["email"] = email.ToString();
                    Session["id"] = member.memId.ToString();
                    Session["role"] = "member";

                    return Redirect("/Members/Details/" + member.memId.ToString());
                }
            } catch(Exception Ex)
            {
                ViewBag.Error = Ex.Message;
                return View("Error");
            }

            ModelState.AddModelError("LoginError", "Incorrect email or password. Details not found on our records");
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

        public ActionResult Scanner()
        {
            return View();
        }
    }
}