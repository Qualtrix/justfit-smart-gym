using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(MembershipType_MetaData))]
    public partial class MemberShip
    {
    }

    public class MembershipType_MetaData
    {
        [Required]
        [Display(Name = "Code")]
        [StringLength(4)]
        public string code { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double fee { get; set; }

        [Required]
        public int level { get; set; }
    }
}