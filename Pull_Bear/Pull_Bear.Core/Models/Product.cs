using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public Nullable<int> ReviewCount { get; set; }
        public Nullable<double> AverageRating { get; set; }
        public string Seria { get; set; }
        public string PhotoModelIndicators { get; set; }
        public string Composition { get; set; }
        public string Care { get; set; }
        public string Description { get; set; }
        public Nullable<int> Count { get; set; }


        //boolean
        public bool IsHotSale { get; set; }
        public bool IsNew { get; set; }
        public bool IsPreOrder { get; set; }


        //images
        public string ProductImage { get; set; }
        public string ShopImage { get; set; }
        public string MainImage1 { get; set; }
        public string MainImage2 { get; set; }



        //relations one product - many ...
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductReview> ProductReviews { get; set; }


        //realtions one ... - many products
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public BodyFit BodyFit { get; set; }
        public int BodyFitId { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }


        //relations many products - many...
        public List<ProductToTag> ProductToTags { get; set; }
        public List<ProductColorSize> ProductColorSizes { get; set; }
    }
}
