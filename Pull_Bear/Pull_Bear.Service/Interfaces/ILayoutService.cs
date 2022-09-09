using Pull_Bear.Service.ViewModels.BasketVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ILayoutService
    {
        Task<List<BasketVM>> GetBasket();
    }
}
