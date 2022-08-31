using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ProductColorSizeVMs
{
    public class ProductColorSizeUpdateVM
    {
        public int? Id { get; set; }
        public bool Color { get; set; }
        public bool Count{ get; set; }
        public bool Size { get; set; }
        public int ChangeValue { get; set; }
    }
}
