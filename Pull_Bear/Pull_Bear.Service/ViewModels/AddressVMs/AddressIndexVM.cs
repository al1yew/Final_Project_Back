using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.AddressVMs
{
    public class AddressIndexVM
    {
        public List<AddressListVM> Addresses { get; set; }
        public AddressCreateVM AddressCreateVM { get; set; }
    }
}
