using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException() { }
        public NotFoundException(string msg) : base(msg) { }
    }
}
