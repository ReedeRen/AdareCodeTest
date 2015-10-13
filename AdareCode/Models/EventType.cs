using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdareCode.Models
{
    [Table("EventType")]
    public class EventType
    {
        [Key]
        public int Id { set; get; }

        [Required]
        [StringLength(255, MinimumLength=3)]
        public string Description { set; get; }
    }
}