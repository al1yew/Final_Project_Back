﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.WishlistVMs
{
    public class WishlistVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int ProductColorSizeId { get; set; }
        public int ProductId { get; set; }

    }
}
