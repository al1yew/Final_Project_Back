using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.BodyFitVMs
{
    public class BodyFitListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
