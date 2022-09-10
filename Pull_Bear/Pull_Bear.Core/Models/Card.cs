using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Card : BaseModel
    {
        public string CardNo { get; set; }
        public int CVV { get; set; }
        public string CardHolder { get; set; }
        public string ExpireDate { get; set; }
        public bool IsMain { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
