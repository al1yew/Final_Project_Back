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
        public Nullable<double> AverageRating { get; set; }
        public Nullable<int> ReviewCount { get; set; }


        //realtions one ... - many products
        public CategoryGetVM Category { get; set; }
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public BodyFitGetVM BodyFit { get; set; }
        public int BodyFitId { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }

        public bool IsHotSale { get; set; }
        public bool IsNew { get; set; }
        public bool IsPreOrder { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }

        //relations one product - many ...
        public List<ProductImageGetVM> ProductImages { get; set; }
        public List<ProductReviewGetVM> ProductReviews { get; set; }

        //images
        public string ProductImage { get; set; }
        public string ShopImage { get; set; }
        public string MainImage1 { get; set; }
        public string MainImage2 { get; set; }

        //relations many products - many...
        public List<ProductToTagGetVM> ProductToTags { get; set; }
        public List<ProductColorSizeGetVM> ProductColorSizes { get; set; }
    }
}
