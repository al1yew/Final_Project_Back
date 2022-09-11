using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AppUserVMs
{
    public class AppUserGetVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public IEnumerable<OrderListVM> Orders { get; set; }
        public List<CardListVM> Cards { get; set; }
        public List<AddressListVM> Addresses { get; set; }

    }
}
