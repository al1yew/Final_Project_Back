using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Core.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNo { get; set; }
        public string CVV { get; set; }
        public string CardHolder { get; set; }
        public string ExpireDate { get; set; }
        public bool IsMain { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
