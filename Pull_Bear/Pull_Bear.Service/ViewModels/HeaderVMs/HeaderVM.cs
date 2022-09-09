using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.HeaderVMs
{
    public class HeaderVM
    {
        public List<CategoryListVM> Categories { get; set; }
        public List<BasketVM> BasketVMs { get; set; }
    }
}
