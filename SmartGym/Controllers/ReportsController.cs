using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using SmartGym.BusinessLogic;
using SmartGym.Models;
using SmartGym.View_Models;

namespace SmartGym.Controllers
{
    public class ReportsController : Controller
    {
        private SmartGymEntities db = new SmartGymEntities();
        private ReportService reportService = new ReportService();
        
        // GET: Reports
        public ActionResult MemberIndex()
        {
            return View(db.Sessions.ToList());
        }


        public ActionResult SessionReport()
        {
            HealthReportView reportView = new HealthReportView();
            reportView.members = db.Members.ToList();

            return View(reportView);
        }
    }
}