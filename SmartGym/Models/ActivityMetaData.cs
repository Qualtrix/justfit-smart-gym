using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(ActivityMetaData))]
    public partial class Activity
    {
    }
        public class ActivityMetaData
    {
        [Display(Name = "Code")]
        public string code { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(500)]
        public string description { get; set; }

        [Display(Name = "Name")]
        [StringLength(50)]
        public string name { get; set; }

        [Display(Name = "Included Activities")]
        [StringLength(800)]
        public string include { get; set; }
    }
}