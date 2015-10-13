using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdareCode.BL
{
    public class AdareDateString : IDateString
    {
        public string GetDateString(DateTime dt)
        {
            return string.Format("{0:dd}{1} {0:MMM}", dt, GetAnnex(dt));
        }

        protected string GetAnnex(DateTime dt)
        {
            int day = dt.Day;
            int resli = day % 10;

            if ((resli == 1) && (day != 11))
            {
                return "st";
            }

            if ((resli == 2) && (day != 12))
            {
                return "nd";
            }

            if ((resli == 3) && (day != 13))
            {
                return "rd";
            }

            return "th";
        }
    }
}