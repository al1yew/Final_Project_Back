﻿using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
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

            return View(await _shopService.GetProduct(id));
        }

        //public async Task<IActionResult> Search(string search)
        //{
        //    List<Product> products = await _context.Products
        //        .Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
        //        p.Brand.Name.ToLower().Contains(search.ToLower()) ||
        //        p.Category.Name.ToLower().Contains(search.ToLower()) ||
        //        p.Description.ToLower().Contains(search.ToLower()) ||
        //        p.FirstText.ToLower().Contains(search.ToLower()) ||
        //        p.SecondText.ToLower().Contains(search.ToLower()))
        //        .ToListAsync();

        //    return PartialView("_SearchPartial", products);
        //}

        //[HttpPost]
        ////[Authorize(Roles = "Member")]
        //public async Task<IActionResult> AddProductReview(ProductReviewVM productReviewVM, int id)
        //{
        //    if (!ModelState.IsValid) return Redirect($"http://localhost:15866/Product/Detail/{id}");

        //    if (id == null && id <= 0) return NotFound();

        //    if (await _context.ProductReviews.Where(x => x.ProductId == productReviewVM.ProductId).AnyAsync(pr => pr.Email.Trim().ToLower() == productReviewVM.Email.Trim().ToLower()))
        //    {
        //        ModelState.AddModelError("", "You have already placed your review!");
        //        return Redirect($"http://localhost:15866/Product/Detail/{id}");
        //    }

        //    ProductReview productReview = new ProductReview
        //    {
        //        CreatedAt = DateTime.UtcNow.AddHours(4),
        //        Email = productReviewVM.Email,
        //        Name = productReviewVM.Name,
        //        Rating = productReviewVM.Rating,
        //        ReviewText = productReviewVM.ReviewText,
        //        ProductId = id,
        //        AppUserId = productReviewVM.AppUserId,
        //    };

        //    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        //    product.ReviewCount++;

        //    //await _context.Products.AddAsync(product);
        //    await _context.ProductReviews.AddAsync(productReview);
        //    await _context.SaveChangesAsync();

        //    TempData["success"] = "Thanks for review!";

        //    return Redirect($"http://localhost:15866/Product/Detail/{id}");
        //}
    }
}
