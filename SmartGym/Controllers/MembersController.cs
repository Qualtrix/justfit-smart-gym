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
using System.Text;

namespace SmartGym.Controllers
{
    public class MembersController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();

        // GET: Members
        public async Task<ActionResult> Index()
        {
            return View(await db.Members.ToListAsync());
        }

        public ActionResult Home()
        {
            return View();
        }
        // GET: Members/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.trainers = new SelectList(db.Employees, "id", "email");
            return View();
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "memId,name,surname,sa_id,email,phone,address,memberShip,joinDate")] Member member, FormCollection form)
        {
            int contractDuration = Convert.ToInt32(form["contractDur"]);
            string referBy = form["trainer"];

            try
            {
                if (ModelState.IsValid)
                {
                    member.memId = MembershipCodeGen(8, false);
                    member.joinDate = DateTime.Now;
                    member.memberShip = "SGM1";
                    //member.trainer = 2;

                    // Assign gym member to personal trainer
                    //if (referBy != null) {
                    //    var trainer = db.Employees.Where(a => a.email == referBy).FirstOrDefault();
                    //    member.trainer = trainer.id;
                    //} 
                        
                    member.terminateDate = DateTime.Now.AddYears(contractDuration);
                    db.Members.Add(member);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Create", "Healths", new { member.memId });
                }

            }
            catch (Exception Ex)
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

            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "memId,name,surname,sa_id,email,phone,address,memberShip,joinDate")] Member member)
        {

            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            // amount remaining before cancellation
            // double cancelFee;
            // int numMonth;
            // Check member primary key exists
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = await db.Members.FindAsync(id);
            if (member == null)
            {
                return HttpNotFound();
            }

            // Calculate cancelation fee
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Member member = await db.Members.FindAsync(id);
            db.Members.Remove(member);
            await db.SaveChangesAsync();
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

        public string MembershipCodeGen(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
