using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class ReviewImage : BaseModel
    {
        public string Image { get; set; }

        //relations
        public ProductReview ProductReview { get; set; }
        public int ProductReviewId { get; set; }

    }
}
