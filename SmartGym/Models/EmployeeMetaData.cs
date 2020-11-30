using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }
        public class EmployeeMetaData
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

        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(4)]
        [RegularExpression(@"^[0-9''-'\s]{1,40}$", ErrorMessage = "This entry can only contain numbers")]
        public string postalCode { get; set; }

        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        public double salary { get; set; }

        [Display(Name = "Hire Date")]
        public System.DateTime hireDate { get; set; }

        [Display(Name = "Role")]
        public Nullable<int> role { get; set; }
        public string password { get; set; }

    }
}