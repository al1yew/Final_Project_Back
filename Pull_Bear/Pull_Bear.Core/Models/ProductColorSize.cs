using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class ProductColorSize
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }

        public Size Size { get; set; }
        public int SizeId { get; set; }

        public int Count { get; set; }
    }
}
