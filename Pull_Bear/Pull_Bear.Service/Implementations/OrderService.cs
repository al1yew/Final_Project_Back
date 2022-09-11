using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class OrderService : IOrderService
    {

        public Task<List<OrderListVM>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderGetVm> GetOrder(int? id)
        {
            throw new NotImplementedException();
        }
        public Task CreateOrder(OrderCreateVM orderCreateVM)
        {
            throw new NotImplementedException();
        }


    }
}
