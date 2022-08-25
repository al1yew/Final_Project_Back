using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<Category> Children { get; set; }


        //relations one bodyfit - many ...
        public List<Product> Products { get; set; }


        //relations one ... - many bodyfits
        public Gender Gender { get; set; }
        public Nullable<int> GenderId { get; set; }

    }
}
