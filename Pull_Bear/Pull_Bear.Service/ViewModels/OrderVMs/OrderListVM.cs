using Pull_Bear.Core.Enums;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.OrderItemVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.OrderVMs
{
    public class OrderListVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public double Price { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CityCountry { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> DeliveredAt { get; set; }
        public bool IsDeleted { get; set; }

        //relations 
        public AppUserGetVM AppUser { get; set; }
        public string AppUserId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderItemListVM> OrderItems { get; set; }
    }
}
