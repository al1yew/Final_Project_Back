using System;
using System.Collections.Generic;
using System.Text;
using Pull_Bear.Core.Enums;

namespace Pull_Bear.Core.Models
{
    public class Order : BaseModel
    {
        public string FullName { get; set; }
        public double Price { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CityCountry { get; set; }
        public string ZipCode { get; set; }
        public Nullable<DateTime> DeliveredAt { get; set; }

        //relations 
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
