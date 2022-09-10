using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.CardVMs
{
    public class CardIndexVM
    {
        public List<CardListVM> Cards { get; set; }
        public CardCreateVM CardCreateVM { get; set; }
    }
}
