using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartGym.Models;

namespace SmartGym.View_Models
{
    public class HealthReportView
    {
        public string category { get; set; }

        public string unhealthy_month { get; set; }

        public int highestAttendance { get; set; }

        public IEnumerable<Member> members { get; set; }
    }
}