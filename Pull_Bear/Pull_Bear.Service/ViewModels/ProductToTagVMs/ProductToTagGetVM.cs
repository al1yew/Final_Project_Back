using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductToTagVMs
{
    public class ProductToTagGetVM
    {
        public int Id { get; set; }

        public ProductGetVM Product { get; set; }
        public int ProductId { get; set; }

        public TagGetVM Tag { get; set; }
        public int TagId { get; set; }
    }
}
