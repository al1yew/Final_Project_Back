using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.ReviewImageVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ShopVMs
{
    public class ProductDetailVM
    {
        public List<ProductColorSizeGetVM> ProductColorSizes { get; set; }
        public ProductGetVM Product { get; set; }
        public List<ProductListVM> Products { get; set; }
    }
}
