using SmartGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGym.BusinessLogic
{
    public class InvoiceService
    {
        private SmartGymEntities db = new SmartGymEntities();

        public double getTotalPayments()
        {
            double totalPayments = 0;

            try
            {
                foreach (var invoice in db.Invoices.ToList())
                {
                    // add all paid payments
                    if (invoice.status == true)
                    {
                        totalPayments = totalPayments + invoice.total;
                    }
                }
            } catch(Exception ex)
            {
                return 0;
            }

            return totalPayments;
        }

        public double getTotalMonthPayments(String month)
        {
            double totalPayments = 0;

            try
            {
                foreach (var invoice in db.Invoices.ToList())
                {
                    // add all paid payments
                    if (invoice.status == true)
                    {
                        totalPayments = totalPayments + invoice.total;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return totalPayments;
        }
    }
}