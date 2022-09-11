using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BasketVMs
{
    public class BasketVM
    {
        public int ProductId { get; set; }
        public ProductGetVM Product { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string ColorHexCode { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
        public string Seria { get; set; }
        public int ItemsCount { get; set; }
    }
}
