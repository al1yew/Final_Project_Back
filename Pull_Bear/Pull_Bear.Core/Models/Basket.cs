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
        public int ColorId { get; set; }
        public int SizeId { get; set; }

        //relations
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
