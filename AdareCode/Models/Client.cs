#define Enable_Foreign_Key

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdareCode.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int Id
        {
            set;
            get;
        }

        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Please enter the full name")]
        [Display(Name = "Full Name")]
        public string FullName
        {
            set;
            get;
        }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = ("Please entre an email address"))]
        [Display(Name = "Email Address")]
        public string EmailAddress
        {
            set;
            get;
        }

        [Required]
        [DataType(DataType.PostalCode, ErrorMessage = ("Please entre your post code"))]
        [Display(Name = "Post Code")]
        public string PostCode
        {
            set;
            get;
        }

        [Display(Name = "FaxShowId")]
        public int? FaxShowId { set; get; }

        [Display(Name = "EmailShowId")]
        public int? EmailShowId { set; get; }

        [Display(Name = "PrintShowId")]
        public int? PrintShowId { set; get; }

#if Enable_Foreign_Key
        [ForeignKey("FaxShowId")]
        public virtual AdareShow FaxShow { set; get; }

        [ForeignKey("EmailShowId")]
        public virtual AdareShow EmailShow { set; get; }

        [ForeignKey("PrintShowId")]
        public virtual AdareShow PrintShow { set; get; }
#endif
    }
}