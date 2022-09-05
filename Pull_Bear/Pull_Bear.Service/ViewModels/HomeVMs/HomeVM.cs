using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SettingVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.HomeVMs
{
    public class HomeVM
    {
        public List<ProductListVM> Products { get; set; }
        public IDictionary<string, string> Settings { get; set; }
    }
}
