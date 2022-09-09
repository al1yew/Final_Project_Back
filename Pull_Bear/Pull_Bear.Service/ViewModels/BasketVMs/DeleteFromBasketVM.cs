using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BasketVMs
{
    public class DeleteFromBasketVM
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int CountInBasket { get; set; }
    }
}
