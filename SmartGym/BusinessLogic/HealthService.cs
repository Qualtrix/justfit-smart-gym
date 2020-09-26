using SmartGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGym.BusinessLogic
{
    public class HealthService
    {

        private SmartGymEntities db = new SmartGymEntities();


        public double getAvgBMI()
        {
            double totBMI = 0;
            double totRecords = db.Healths.Count();

            try
            {
                foreach (var item in db.Healths.ToList())
                {
                    totBMI = totBMI + item.BMI;
                }

            } catch (Exception ex)
            {
                return 0;
            }
            return totBMI / totRecords;
        }
    }
}