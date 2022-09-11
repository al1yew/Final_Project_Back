using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.GetOrders());
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateVM orderCreateVM)
        {
            return View();
        }
    }
}
