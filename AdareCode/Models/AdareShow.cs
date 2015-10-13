#define Enable_Foreign_Key

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdareCode.Models
{
    [Table("AdareShow")]
    public class AdareShow
    {
        [Key]
        public int Id { set; get; }

        [DataType(DataType.Date, ErrorMessage="Incorrect date format")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "EventDate")]
        [Required]
        public DateTime EventDate
        {
            set;
            get;
        }

        [Required]
        public int EventTypeId { set; get; }

#if Enable_Foreign_Key
        [ForeignKey("EventTypeId")]
        public virtual EventType ShowType { set; get; }
#endif
    }
}