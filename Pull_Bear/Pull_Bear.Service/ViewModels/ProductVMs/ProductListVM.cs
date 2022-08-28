using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.GenderVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductVMs
{
    public class ProductListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }

        //realtions one ... - many products
        public CategoryGetVM Category { get; set; }
        public int CategoryId { get; set; }
        public BodyFitGetVM BodyFit { get; set; }
        public int BodyFitId { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }

        //relations many products - many...
        public List<ProductColorSizeGetVM> ProductColorSizes { get; set; }
    }
}
