using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View("CreateOrder");
            }

            return View(await _orderService.GetOrderViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardCreateVM cardCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View("CreateOrder");
            }

            await _orderService.CreateCard(cardCreateVM);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressCreateVM addressCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View("CreateOrder");
            }

            await _orderService.CreateAddress(addressCreateVM);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] AppUserUpdateVM appUserUpdateVM)
        {
            if (!ModelState.IsValid) return StatusCode(406);

            foreach (var item in await _orderService.UpdateUser(appUserUpdateVM))
            {
                ModelState.AddModelError("", item);

                return View("Index");
            }

            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateVM orderCreateVM)
        {
            return View();
        }
    }
}
