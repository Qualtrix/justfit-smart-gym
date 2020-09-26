using SmartGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGym.BusinessLogic
{
    public class ReportService
    {
        private SmartGymEntities db = new SmartGymEntities();

        public List<Session> getUserSessions()
        {
            return db.Sessions.ToList();
        }
    }
}