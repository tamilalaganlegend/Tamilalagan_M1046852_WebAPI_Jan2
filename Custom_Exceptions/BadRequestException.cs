using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exceptions
{
    public class BadRequestException:Exception
    {
            public BadRequestException() { }
            public BadRequestException(string msg) : base(msg) { }
    }
}
