using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductColorSizeVMs
{
    public class ProductColorSizeGetVM
    {
        public int Id { get; set; }

        public ProductListVM Product { get; set; }
        public int ProductId { get; set; }

        public ColorListVM Color { get; set; }
        public int ColorId { get; set; }

        public SizeListVM Size { get; set; }
        public int SizeId { get; set; }

        public int Count { get; set; }
    }
}
