using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //relations
        public List<BodyFit> BodyFits { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }

    }
}
