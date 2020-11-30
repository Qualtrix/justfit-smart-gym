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

        [StringLength(13)]
        [Required]
        [Display(Name = "ID Number")]
        [RegularExpression(@"(?<Year>[0,3,4,5,6,7,8,9][0-9])(?<Month>([0][1-9])|([1][0-2]))(?<Day>([0-2][0-9])|([3][0-1]))(?<Gender>[0-9])(?<Series>[0-9]{3})(?<Citizenship>[0-9])(?<Uniform>[0-9])(?<Control>[0-9])", ErrorMessage = "Incorrect ID entered")]
        public string sa_id { get; set; }

        [Display(Name = "E-Mail")]
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid E-mail address")]
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

        [Display(Name = "Trainer Type")]
        public Nullable<int> trainer { get; set; }
    }
}