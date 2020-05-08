using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exceptions
{
    public class InternalServerException:Exception
    {
        public InternalServerException() { }
        public InternalServerException(string msg) : base(msg) { }
    }
}
