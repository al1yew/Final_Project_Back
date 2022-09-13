using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Core.Enums;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index(int? ordertype, int select, int page = 1)
        {
            IQueryable<OrderListVM> orderListVM = await _orderService.GetAllOrders(ordertype, select);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Page = page;

            return View(PaginationList<OrderListVM>.Create(orderListVM, page, select));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            return View(await _orderService.GetOrderById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, OrderStatus orderStatus)
        {
            await _orderService.UpdateOrder(id, orderStatus);

            return RedirectToAction("Index");
        }
    }
}
