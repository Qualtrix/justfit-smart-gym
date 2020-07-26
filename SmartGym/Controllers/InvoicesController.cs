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
    public class InvoicesController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        // GET: Invoices
        public async Task<ActionResult> Index()
        {
            var invoices = db.Invoices.Include(i => i.Member);
            return View(await invoices.ToListAsync());
        }

        // GET: Invoices/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.memID = new SelectList(db.Members, "memId", "name");
            return View();
        }

        // POST: Invoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "invoiceNo,invoiceDate,description,memID,total")] Invoice invoice)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    invoice.invoiceDate = DateTime.Now;
                    db.Invoices.Add(invoice);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            } catch(Exception Ex)
            {
                Log log = new Log
                {
                    errorDate = DateTime.Now,
                    errorMsg = Ex.Message,
                    path = Ex.Source
                };

                db.Logs.Add(log);
                db.SaveChanges();
                return View("Error");
            }

            ViewBag.memID = new SelectList(db.Members, "memId", "name", invoice.memID);
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.memID = new SelectList(db.Members, "memId", "name", invoice.memID);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "invoiceNo,invoiceDate,description,memID,total")] Invoice invoice)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(invoice).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            } catch(Exception Ex)
            {
                ViewBag.Error = Ex.Message;
                return View("Error");
            }
            ViewBag.memID = new SelectList(db.Members, "memId", "name", invoice.memID);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = await db.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           try
            {
                Invoice invoice = await db.Invoices.FindAsync(id);
                db.Invoices.Remove(invoice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            } catch(Exception Ex)
            {
                ViewBag.Error = Ex.Message;
                return View("Error");
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
