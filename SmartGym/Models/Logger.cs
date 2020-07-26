using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartGym.Models;

namespace SmartGym.Models
{
    public class Logger
    {
        private SmartGymEntities db = new SmartGymEntities();

        Logger(string msg, string source) {
            Log log = new Log
            {
                errorDate = DateTime.Now,
                errorMsg = msg,
                path = source
            };

            db.Logs.Add(log);
            db.SaveChanges();
        }
    }

}