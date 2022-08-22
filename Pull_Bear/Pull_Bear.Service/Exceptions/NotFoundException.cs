using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {

        }
    }
}
