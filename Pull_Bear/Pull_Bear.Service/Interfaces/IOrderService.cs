using Pull_Bear.Core.Enums;
using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IQueryable<OrderListVM>> GetAllOrders(int? ordertype, int select);
        Task<List<OrderListVM>> GetOrders();
        Task<OrderListVM> GetOrderById(int? id);
        Task UpdateOrder(int? id, OrderStatus orderStatus);
        Task CreateOrder(OrderCreateVM orderCreateVM);
        Task<List<CardListVM>> CreateCard(CardCreateVM orderCreateVM);
        Task<List<AddressListVM>> CreateAddress(AddressCreateVM addressCreateVM);
        Task<List<string>> UpdateUser(AppUserUpdateVM appUserUpdateVM);
        Task<OrderIndexVM> GetOrderViewModel();
        Task<List<BasketVM>> DeleteFromBasket(DeleteFromBasketVM deleteFromBasketVM);
        Task<List<OrderListVM>> SortOrders(string sortvalue);
        Task<List<OrderListVM>> Search(string search);
        Task<double> GetBasket();
    }
}
