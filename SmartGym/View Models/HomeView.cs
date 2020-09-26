using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartGym.Models;

namespace SmartGym.View_Models
{
    public class HomeView
    {
        public int newMembers { set; get; }
        public double avgBMI { set; get; }
        public string healthStatus { set; get; }
        public int totMembers { set; get; }
        public double monthlyPayments { get; set; }
        public double attendance { get; set; }
        public IEnumerable<MemberShip> memberShips { get; set; }
    }
}