using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.WishlistVMs
{
    public class AddToWishlistVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int ProductId { get; set; }
    }
}
