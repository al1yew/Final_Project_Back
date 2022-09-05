using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        //relations
        public ProductColorSize ProductColorSize { get; set; }
        public int ProductColorSizeId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
