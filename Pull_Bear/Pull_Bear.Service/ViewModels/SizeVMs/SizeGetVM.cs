using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.SizeVMs
{
    public class SizeGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        //public List<ProductColorSizeGetVM> ProductColorSizes { get; set; }
    }
}
