using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdareCode.BL
{
    public class DummyPasswordChecker : IPasswordChecker
    {
        public bool Check(string user, string password)
        {
            return true;
        }
    }
}