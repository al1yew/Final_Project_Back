using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class ProductImage : BaseModel
    {
        public string Image { get; set; }

        //relations
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
