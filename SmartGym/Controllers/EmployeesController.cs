using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartGym.Models;

namespace SmartGym.Controllers
{
    public class EmployeesController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.Designation);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            // ViewBag.id = new SelectList(db.Designations, "id", "activityCode");
            // ViewBag.role = new SelectList(db.TrainerTypes, "id", "name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,surname,email,phone,address,postalCode,role")] Employee employee, FormCollection form)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.hireDate = DateTime.UtcNow;
                    employee.salary = 10000;
                    employee.password = "trainer2020";
                    //var jobType = db.TrainerTypes.Where(a => a.id == employee.role).FirstOrDefault();

                    //switch (jobType.name)
                    //{
                    //    case Job.BranchManager:
                    //        employee.salary = 15000.00;
                    //        employee.password = "trainer";
                    //        break;

                    //    case Job.Worker:
                    //        employee.salary = 8000.00;
                    //        employee.password = "worker" + DateTime.Now.Year.ToString();
                    //        break;

                    //    case Job.Cleaner:
                    //        employee.salary = 3000.00;
                    //        break;

                    //    case Job.Personal_Trainer:
                    //        employee.password = "trainer" + DateTime.Now.Year.ToString();
                    //        employee.salary = 6000.00;
                    //        break;

                    //    default:
                    //        employee.password = "worker";
                    //        employee.salary = 1000.00;
                    //        break;
                    //}

                    db.Employees.Add(employee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

            } catch (Exception Ex)
            {
                // db.Logs.Add(Ex.Message);
                ViewBag.Error = Ex.Message;
                return View("Error");
            }
            ViewBag.id = new SelectList(db.Designations, "id", "activityCode", employee.id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
           try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = await db.Employees.FindAsync(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }

                ViewBag.id = new SelectList(db.Designations, "id", "activityCode", employee.id);
                return View(employee);
            } catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }

            
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,surname,email,phone,address,postalCode,salary,hireDate,username,password")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Designations, "id", "activityCode", employee.id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Employee employee = await db.Employees.FindAsync(id);
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            } catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Login");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
