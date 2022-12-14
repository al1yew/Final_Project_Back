using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int TrackingNumber { get; set; }

        //relations
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
