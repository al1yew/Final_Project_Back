using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.ReviewImageVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductReviewVMs
{
    public class ProductReviewListVM
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public double Rating { get; set; }
        public int LikesCount { get; set; }


        //relations one review - many ...
        public List<ReviewImageListVM> ReviewImages { get; set; }


        //relations many reviews - one ...
        public ProductGetVM Product { get; set; }
        public int ProductId { get; set; }
        public AppUserGetVM AppUser { get; set; }
        public string AppUserId { get; set; }

    }
}
