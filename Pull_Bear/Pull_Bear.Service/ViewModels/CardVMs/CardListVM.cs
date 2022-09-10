using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CardVMs
{
    public class CardListVM
    {
        public int Id { get; set; }
        public string CardNo { get; set; }
        public string CVV { get; set; }
        public string CardHolder { get; set; }
        public string ExpireDate { get; set; }
        public bool IsMain { get; set; }
        public string AppUserId { get; set; }
    }
}
