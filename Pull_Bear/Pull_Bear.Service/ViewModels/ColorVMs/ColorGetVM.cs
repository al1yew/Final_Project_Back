using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.ColorVMs
{
    public class ColorGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
