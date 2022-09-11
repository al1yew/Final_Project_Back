using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderGetVm> GetOrder(int? id);
        Task<List<OrderListVM>> GetOrders();
        Task CreateOrder(OrderCreateVM orderCreateVM);
    }
}
