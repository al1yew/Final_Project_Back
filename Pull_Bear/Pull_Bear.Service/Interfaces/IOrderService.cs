using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderListVM>> GetOrders();
        Task CreateOrder(OrderCreateVM orderCreateVM);
        Task CreateCard(CardCreateVM orderCreateVM);
        Task CreateAddress(AddressCreateVM addressCreateVM);
        Task<List<string>> UpdateUser(AppUserUpdateVM appUserUpdateVM);
        Task<OrderIndexVM> GetOrderViewModel();
    }
}
