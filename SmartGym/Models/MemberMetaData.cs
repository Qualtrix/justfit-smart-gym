using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(MemberMetaData))]
    public partial class Member
    {
    }
        public class MemberMetaData
    {
        [Display(Name = "Name")]
        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string name { get; set; }

        [Display(Name = "Surname")]
        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string surname { get; set; }

        [Display(Name = "ID Number")]
        [Required]
        [StringLength(13)]
        [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "This entry can only contain numbers")]
        public string sa_id { get; set; }

        [Display(Name = "E-Mail")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "This entry can only contain numbers")]
        public string phone { get; set; }

        [Display(Name = "Physical Address")]
        [Required]
        [StringLength(100)]
        public string address { get; set; }

        [Display(Name = "Membership Type")]
        public string memberShip { get; set; }

        [Display(Name = "Join Date")] 
        public System.DateTime joinDate { get; set; }
    }
}