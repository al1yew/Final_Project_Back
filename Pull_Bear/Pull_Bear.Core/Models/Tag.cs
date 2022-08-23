using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }

        //relations
        public IEnumerable<ProductToTag> ProductToTags { get; set; }
    }
}
