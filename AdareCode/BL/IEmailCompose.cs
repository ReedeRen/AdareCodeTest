using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdareCode.BL
{
    public interface IEmailCompose<T>
    {
        string CreateBody(T obj);
    }
}
