using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.Exceptions
{
    public class RecordDublicateException : Exception
    {
        public RecordDublicateException(string msg) : base(msg)
        {

        }
    }
}
