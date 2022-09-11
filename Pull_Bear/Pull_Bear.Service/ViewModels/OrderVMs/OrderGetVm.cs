using Pull_Bear.Core.Enums;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.OrderItemVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.OrderVMs
{
    public class OrderGetVm
    {
        public int Id { get; set; }

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


        //relations 
        public AppUserGetVM AppUser { get; set; }
        public string AppUserId { get; set; }
        public IEnumerable<OrderItemListVM> OrderItems { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
