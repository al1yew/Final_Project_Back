using System;
using System.Collections.Generic;
using System.Text;
using Pull_Bear.Core.Enums;

namespace Pull_Bear.Core.Models
{
    public class Order : BaseModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public double Price { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public Nullable<DateTime> DeliveredAt { get; set; }

        //relations 
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
