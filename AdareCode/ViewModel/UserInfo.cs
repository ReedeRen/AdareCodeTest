using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdareCode.ViewModel
{
    public class UserInfo
    {
        [StringLength(255, MinimumLength=3, ErrorMessage="Please check user name")]
        [Display(Name="User")]
        public string User { set; get; }

        [StringLength(255, MinimumLength=3)]
        [Display(Name="Password")]
        public string Password { set; get; }
    }
}