using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.OrderVMs
{
    public class OrderIndexVM
    {
        public OrderCreateVM OrderCreateVM { get; set; }
        public AddressCreateVM AddressCreateVM { get; set; }
        public CardCreateVM CardCreateVM { get; set; }
        public AppUserUpdateVM AppUserUpdateVM { get; set; }
        public CardListVM Cards { get; set; }
        public AddressListVM Addresses { get; set; }
    }
}
