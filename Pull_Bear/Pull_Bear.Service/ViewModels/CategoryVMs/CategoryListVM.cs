using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CategoryVMs
{
    public class CategoryListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public Nullable<int> ParentId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
