using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductImageVMs
{
    public class ProductImageGetVM
    {
        public int Id { get; set; }
        public string Image { get; set; }

        //relations
        public ProductGetVM Product { get; set; }
        public int ProductId { get; set; }
    }
}
