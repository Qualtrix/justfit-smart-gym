using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartGym.Models.DTOs
{
    public class HealthDTO
    {
        public string memId { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public double BMI { get; set; }
        public DateTime updated { get; set; }
    }
}