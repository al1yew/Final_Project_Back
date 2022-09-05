using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BasketVMs
{
    public class BasketVM
    {
        public int ProductColorSizeId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }
}
