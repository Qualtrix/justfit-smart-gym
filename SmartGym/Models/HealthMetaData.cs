using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(HealthMetaData))]
    public partial class Health
    {
    }
        public class HealthMetaData
    {
        [Display(Name = "MemId")]
        public string memId { get; set; }

        [Display(Name = "Height")]
        [Required]
        public double height { get; set; }

        [Display(Name = "Weight")]
        [Required]
        public double weight { get; set; }

        [Display(Name = "BMI")]
        public double BMI { get; set; }

        [Display(Name = "Image URL")]
        public string imageUrl { get; set; }

        [Display(Name = "Update Date")]
        public Nullable<System.DateTime> updated { get; set; }
    }
}