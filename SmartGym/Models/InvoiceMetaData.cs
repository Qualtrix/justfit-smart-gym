using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SmartGym.Models
{
    [MetadataType(typeof(InvoiceMetaData))]
    public partial class Invoice
    {
    }

        public class InvoiceMetaData
    {
        [Display(Name = "Invoice No")]
        public int invoiceNo { get; set; }

        [Display(Name = "Invoice Date")]
        public System.DateTime invoiceDate { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "This entry can only contain letters")]
        public string description { get; set; }

        public string memID { get; set; }
        [Display(Name = "Total")]
        [Required]
        [DataType(DataType.Currency)]
        public double total { get; set; }

    }
}