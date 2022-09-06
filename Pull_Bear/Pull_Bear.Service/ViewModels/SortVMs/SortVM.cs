using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.SortVMs
{
    public class SortVM
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public int BodyFitId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int GenderId { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public int OrderBy { get; set; }
        public int SelectValue { get; set; }
    }
}
