using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartGym.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult MemberIndex()
        {
            return View();
        }
    }
}