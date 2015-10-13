using System;
using System.Collections.Generic;

namespace AdareCode.BL
{
    public class DummyEmailComposer : IEmailCompose<Models.Client>
    {
        public string CreateBody(Models.Client obj)
        {
            return obj.ToString();
        }
    }
}