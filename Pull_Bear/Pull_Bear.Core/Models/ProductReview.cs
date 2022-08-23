using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public double Rating { get; set; }
        public int LikesCount { get; set; }


        //relations one review - many ...
        public List<ReviewImage> ReviewImages { get; set; }


        //relations many reviews - one ...
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
