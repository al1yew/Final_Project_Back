using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BasketVMs
{
    public class UpdateBasketVM
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Count { get; set; }
        public bool IsPlus { get; set; }
    }
}
