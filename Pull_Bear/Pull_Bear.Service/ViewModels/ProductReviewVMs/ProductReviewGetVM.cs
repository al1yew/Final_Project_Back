using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.ReviewImageVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductReviewVMs
{
    public class ProductReviewGetVM
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public double Rating { get; set; }
        public int LikesCount { get; set; }


        //relations one review - many ...
        public List<ReviewImageGetVM> ReviewImages { get; set; }


        //relations many reviews - one ...
        public ProductGetVM Product { get; set; }
        public int ProductId { get; set; }
    }
}
