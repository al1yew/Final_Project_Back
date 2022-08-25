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
        public int ReviewCount { get; set; }
        public double AverageRating { get; set; }
        public string Seria { get; set; }
        public string PhotoModelIndicators { get; set; }
        public string Composition { get; set; }
        public string Care { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }


        //boolean
        public bool IsHotSale { get; set; }
        public bool IsNew { get; set; }
        public bool IsPreOrder { get; set; }


        //images
        public string ProductImage { get; set; }
        public string MainImage1 { get; set; }
        public string MainImage2 { get; set; }


        //image loading 
        [NotMapped]
        public IFormFile ProductPhoto { get; set; }
        [NotMapped]
        public IFormFile MainPhoto1 { get; set; }
        [NotMapped]
        public IFormFile MainPhoto2 { get; set; }
        [NotMapped]
        public IEnumerable<IFormFile> Files { get; set; }


        //relations one product - many ...
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductReview> ProductReviews { get; set; }



        //realtions one ... - many products
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public BodyFit BodyFit { get; set; }
        public int BodyFitId { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }


        //relations many products - many...
        public IEnumerable<ProductToTag> ProductToTags { get; set; }
        public IEnumerable<ProductColorSize> ProductColorSizes { get; set; }



        //props for help notmapped
        [NotMapped]
        public IEnumerable<int> TagIds { get; set; }
        [NotMapped]
        public IEnumerable<int> ColorIds { get; set; }
        [NotMapped]
        public IEnumerable<int> SizeIds { get; set; }
        [NotMapped]
        public IEnumerable<int> Counts { get; set; }


    }
}
