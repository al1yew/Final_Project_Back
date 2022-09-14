using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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

        public async Task<IActionResult> SortOrders(string sortvalue)
        {
            return PartialView("_OrdersPartial", await _orderService.SortOrders(sortvalue));
        }

        public async Task<IActionResult> Search(string search)
        {
            return PartialView("_OrdersPartial", await _orderService.Search(search));
        }


        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            OrderIndexVM orderIndexVM = await _orderService.GetOrderViewModel();

            if (orderIndexVM.Baskets.Count <= 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(orderIndexVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateVM orderCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                TempData["error"] = "Error!";
                return RedirectToAction("CreateOrder");
            }

            await _orderService.CreateOrder(orderCreateVM);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardCreateVM cardCreateVM)
        {
            if (!ModelState.IsValid) return StatusCode(406);

            return PartialView("_CheckoutCurrentUserCardPartial", await _orderService.CreateCard(cardCreateVM));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressCreateVM addressCreateVM)
        {
            if (!ModelState.IsValid) return StatusCode(406);

            return PartialView("_CheckoutCurrentUserAddressPartial", await _orderService.CreateAddress(addressCreateVM));
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

        public async Task<IActionResult> DeleteFromBasket(DeleteFromBasketVM deleteFromBasketVM)
        {
            if (deleteFromBasketVM == null) return BadRequest();

            List<BasketVM> baskets = await _orderService.DeleteFromBasket(deleteFromBasketVM);

            return PartialView("_CheckoutBasketsPartial", baskets);
        }

        public async Task<IActionResult> GetBasket()
        {
            return PartialView("_CheckoutSubmitFormPartial", await _orderService.GetBasket());
        }
    }
}
