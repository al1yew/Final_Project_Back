using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ShopVMs
{
    public class ShopVM
    {
        public IDictionary<string, string> Settings { get; set; }
        public PaginationList<ProductListVM> Products { get; set; }
        public List<BodyFitListVM> BodyFits { get; set; }
        public List<CategoryListVM> Categories { get; set; }
        public List<ColorListVM> Colors { get; set; }
        public List<SizeListVM> Sizes { get; set; }
    }
}
