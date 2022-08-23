using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg) : base(msg)
        {

        }
    }
}
