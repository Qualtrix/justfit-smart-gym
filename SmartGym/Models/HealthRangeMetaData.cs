using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(HealthRangeMetaData))]
    public partial class HealthRange
    {
    }

    public class HealthRangeMetaData
    {
        [Display(Name ="Health Status")]
        public string name { get; set; }

        [Display(Name = "Minimum")]
        public double minimum { get; set; }

        [Display(Name = "Maximum")]
        public double maximum { get; set; }
    }
}