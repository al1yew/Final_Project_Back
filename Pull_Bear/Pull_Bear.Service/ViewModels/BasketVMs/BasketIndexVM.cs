using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BasketVMs
{
    public class BasketIndexVM
    {
        public List<BasketVM> BasketVM { get; set; }
        public List<ProductListVM> Products { get; set; }
    }
}
