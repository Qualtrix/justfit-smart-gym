using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{

    [MetadataType(typeof(SessionMetaData))]
    public partial class Session
    {
    }
        public class SessionMetaData
    {
        [Display(Name = "Member Code")]
        public string memId { get; set; }

        [Display(Name = "Activity Code")]
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string activityCode { get; set; }

        [Display(Name = "Session Date")]
        public System.DateTime sessionDate { get; set; }

        [Display(Name = "Satisfaction")]
        public Nullable<int> satisfaction { get; set; }

        [Display(Name = "Duration")]
        public Nullable<int> usage { get; set; }
        public int id { get; set; }
    }
}