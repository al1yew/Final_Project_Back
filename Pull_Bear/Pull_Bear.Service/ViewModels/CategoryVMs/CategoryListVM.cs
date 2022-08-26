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
        public CategoryListVM Parent { get; set; }
        public List<CategoryListVM> Children { get; set; }
        public string GenderName { get; set; }
        public bool IsDeleted { get; set; }
        public int GenderId { get; set; }
        public string Image { get; set; }

    }
}
