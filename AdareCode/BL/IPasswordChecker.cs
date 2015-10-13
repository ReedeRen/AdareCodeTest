using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdareCode.BL
{
    public interface IPasswordChecker
    {
        bool Check(string user, string password);
    }
}
