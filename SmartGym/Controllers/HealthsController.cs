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
using System.IO;
using SmartGym.Models.DTOs;

namespace SmartGym.Controllers
{
    public class HealthsController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        // GET: Healths
        public async Task<ActionResult> Index()
        {
            var healths = db.Healths.Include(h => h.Member);
           
            return View(await healths.ToListAsync());
        }

        // GET: Healths/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health health = await db.Healths.FindAsync(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // GET: Healths/Create
        public ActionResult Create(string memId)
        {
            Health health = new Health
            {
                memId = memId,
                height = 80,
                weight = 20
            };
            return View(health);
        }

        // POST: Healths/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Health health)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    health.updated = DateTime.Now;

                    // Upload user image
                    string fileName = Path.GetFileNameWithoutExtension(health.ImageFile.FileName);
                    string extension = Path.GetExtension(health.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    health.imageUrl = "~/images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
                    health.ImageFile.SaveAs(fileName);
                    /*
                     * Calculate gym member BMI 
                     * Formula is weight in KG / height in meters if height is in cm / by 100 metered squared
                     */
                    health.BMI = health.weight / (Math.Pow((health.height / 100), 2));
                    health.imageUrl = "oo";

                    // assign gym member a health status
                    var status = db.HealthRanges.Where(a => a.minimum < health.BMI && health.BMI <= a.maximum).FirstOrDefault();
                    health.healthStatus = status.id;
                    health.imageUrl = fileName;
                    db.Healths.Add(health);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception Ex)
            {
                ViewBag.Error = Ex.Message;
                return View("Error");
            }
            ModelState.Clear();
            ViewBag.memId = new SelectList(db.Members, "memId", "name", health.memId);
            return View(health);
        }

        // GET: Healths/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health health = await db.Healths.FindAsync(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            ViewBag.memId = new SelectList(db.Members, "memId", "name", health.memId);
            return View(health);
        }

        // POST: Healths/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "memId,height,weight,BMI,imageUrl,updated,id")] Health health)
        {
            if (ModelState.IsValid)
            {
                db.Entry(health).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.memId = new SelectList(db.Members, "memId", "name", health.memId);
            return View(health);
        }

        // GET: Healths/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Health health = await db.Healths.FindAsync(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // POST: Healths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Health health = await db.Healths.FindAsync(id);
            db.Healths.Remove(health);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Http get
        public ActionResult HealthReport(string code)
        {
            if (code != null)
            {
                return View(db.Healths.Where(a => a.memId == code).ToList());
            }

            return View(db.Healths.ToList());
        }

        [HttpPost]
        public ActionResult ScannerResults(Health health)
        {
            health.updated = DateTime.Now;
            health.healthStatus = 4;
            return RedirectToAction("Index");
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
