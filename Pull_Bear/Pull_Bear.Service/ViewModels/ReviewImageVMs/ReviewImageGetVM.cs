using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ReviewImageVMs
{
    public class ReviewImageGetVM
    {
        public string Image { get; set; }

        //relations
        public ProductReviewGetVM ProductReview { get; set; }
        public int ProductReviewId { get; set; }
    }
}
