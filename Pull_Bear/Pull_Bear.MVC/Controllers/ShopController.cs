﻿using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SortVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public async Task<IActionResult> Index(int? genderId)
        {
            return View(await _shopService.GetDataAsync(genderId));
        }

        public async Task<IActionResult> CreateSort([FromBody] SortVM sortVM)
        {
            IQueryable<ProductListVM> products = await _shopService.CreateSort(sortVM);

            var a = PaginationList<ProductListVM>.Create(products, sortVM.Page == 0 ? 1 : sortVM.Page, sortVM.SelectValue == 0 ? 6 : sortVM.SelectValue);

            return PartialView("_ProductIndexPartial", a);
        }

        public async Task<IActionResult> ProductDetail(int? id)
        {
            if (id == null) return BadRequest();

            ViewBag.ProductId = id;

            return View(await _shopService.GetProduct(id));
        }

        public async Task<IActionResult> AddReview(WriteReviewVM writeReviewVM, int? id)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return Ok();
            }
            ViewBag.ProductId = id;
            return PartialView("_ProductDetailReviewPartial", await _shopService.AddReview(writeReviewVM, id));
        }

        public async Task<IActionResult> Search(string search)
        {
            var a = await _shopService.Search(search);

            return PartialView("_SearchPartial", a);
        }

        public async Task<IActionResult> GetReviewCount(int? id)
        {
            return Json(await _shopService.GetReviewCount(id));
        }

        public async Task<IActionResult> Like(int? id)
        {
            return Json(await _shopService.Like(id));
        }
    }
}
