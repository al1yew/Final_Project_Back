using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Accepted,
        Rejected,
        Shipped,
        Courier,
        Delivered
    }
}
