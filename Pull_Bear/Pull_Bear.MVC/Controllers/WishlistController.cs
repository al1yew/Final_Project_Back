using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.WishlistVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        public async Task<IActionResult> Index()
        { 
            return View(await _wishlistService.GetWishlists());
        }

        public async Task<IActionResult> AddToWishlist(int? id)
        {
            if (!await _wishlistService.AddToWishlist(id))
            {
                return StatusCode(406);
            }

            return Ok();
        }

        public async Task<IActionResult> DeleteFromWishlist(int? id)
        {
            return PartialView("_WishlistPartial", await _wishlistService.DeleteFromWishlist(id));
        }
    }
}
