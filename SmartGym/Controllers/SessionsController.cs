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
    public class SessionsController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        // GET: Sessions
        public async Task<ActionResult> Index()
        {
            var sessions = db.Sessions.Include(s => s.Activity).Include(s => s.Member);
            return View(await sessions.ToListAsync());
        }

        // GET: Sessions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            try
            {
                Session session = await db.Sessions.FindAsync(id);
                if (session == null)
                {
                    return HttpNotFound();
                }

                return View(session);

            } catch(Exception Ex)
            {
                Log log = new Log
                {
                    errorMsg = Ex.Message,
                    errorDate = DateTime.Now,
                    path = Ex.Source
                };

                db.Logs.Add(log);
                db.SaveChanges();
                return View("Error");
            }
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            ViewBag.activityCode = new SelectList(db.Activities, "code", "description");
            ViewBag.memId = new SelectList(db.Members, "memId", "memId");
            return View();
        }

        // POST: Sessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "memId,activityCode,sessionDate,satisfaction,usage")] Session session)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    session.sessionDate = DateTime.Now;
                    db.Sessions.Add(session);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

            } catch(Exception Ex)
            {
                ViewBag.Error = Ex.Message;
                return View("Error");
            }
            ViewBag.activityCode = new SelectList(db.Activities, "code", "description", session.activityCode);
            ViewBag.memId = new SelectList(db.Members, "memId", "name", session.memId);
            return View(session);
        }

        // GET: Sessions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
           try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Session session = await db.Sessions.FindAsync(id);
                if (session == null)
                {
                    return HttpNotFound();
                }
                ViewBag.activityCode = new SelectList(db.Activities, "code", "description", session.activityCode);
                ViewBag.memId = new SelectList(db.Members, "memId", "name", session.memId);
                return View(session);
            } catch (Exception Ex)
            {
                Log logger = new Log
                {
                    errorDate = DateTime.Now,
                    errorMsg = Ex.Message,
                    path = Ex.Source
                };

                db.Logs.Add(logger);
                db.SaveChanges();
                return View("Error");
            }
        }

        // POST: Sessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "memId,activityCode,sessionDate,satisfaction,usage, id")] Session session)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(session).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            } catch(Exception Ex)
            {
                Log logger = new Log
                {
                    errorDate = DateTime.Now,
                    errorMsg = Ex.Message,
                    path = Ex.Source
                };

                db.Logs.Add(logger);
                db.SaveChanges();
                return View("Error");
            }
            ViewBag.activityCode = new SelectList(db.Activities, "code", "description", session.activityCode);
            ViewBag.memId = new SelectList(db.Members, "memId", "name", session.memId);
            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
           try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Session session = await db.Sessions.FindAsync(id);
                if (session == null)
                {
                    return HttpNotFound();
                }

                return View(session);
            } catch (Exception Ex)
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
           
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           try
            {
                Session session = await db.Sessions.FindAsync(id);
                db.Sessions.Remove(session);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
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
