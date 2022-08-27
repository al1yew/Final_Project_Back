using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Color : BaseModel
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        //relations
        public IEnumerable<ProductColorSize> ProductColorSizes { get; set; }
    }
}
