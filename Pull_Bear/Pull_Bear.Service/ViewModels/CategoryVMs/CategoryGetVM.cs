using Pull_Bear.Core.Models;
using Pull_Bear.Service.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CategoryVMs
{
    public class CategoryGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public CategoryGetVM Parent { get; set; }
        public Nullable<int> ParentId { get; set; }
        public List<CategoryGetVM> Children { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public string Image { get; set; }
    }
}
