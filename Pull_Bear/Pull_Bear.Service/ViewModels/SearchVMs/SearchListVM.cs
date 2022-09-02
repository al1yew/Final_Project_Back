using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pull_Bear.Service.ViewModels.SearchVMs
{
    public class SearchListVM
    {
        public List<CategoryListVM> Categories { get; set; }
        public List<BodyFitListVM> BodyFits { get; set; }
        public List<TagListVM> Tags { get; set; }
        public List<ColorListVM> Colors { get; set; }
        public List<SizeListVM> Sizes { get; set; }
        public List<ProductListVM> Products { get; set; }
        public List<AppUserListVM> Users { get; set; }
        //public List<OrderListVM> Orders { get; set; }
    }
}
