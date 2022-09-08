using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.AccountVMs;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.WishlistVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => (u.NormalizedEmail == loginVM.Email.Trim().ToUpperInvariant() || u.NormalizedUserName == loginVM.Email.Trim().ToUpperInvariant()) && !u.IsAdmin && !u.IsDeleted);

            if (appUser == null || appUser.IsAdmin || !await _userManager.CheckPasswordAsync(appUser, loginVM.Password))
            {
                ModelState.AddModelError("", "Email or Password is wrong!");

                return View();
            }

            await _signInManager.SignInAsync(appUser, loginVM.RememberMe);

            #region basket

            //string basketCookie = HttpContext.Request.Cookies["basket"];

            //if (!string.IsNullOrWhiteSpace(basketCookie))
            //{
            //    List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);
            //    //koki prines
            //    List<Basket> baskets = new List<Basket>();
            //    //sozdal noviy list uje DBskiy
            //    foreach (BasketVM basketVM in basketVMs)
            //    {
            //        if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
            //        {//esli on koqda to shto to dobavlal v basket, u neqo v DB est basketskie veshi s druqoqo kompa naprimer
            //            Basket existedBasket = appUser.Baskets.FirstOrDefault(b => b.ProductColorSizeId != basketVM.ProductColorSizeId);
            //            //ego basket v kotorom netu tex productov kotorie est v basketvm iz kuki
            //            if (existedBasket == null)
            //            {//esli on nikoqda nicheqo ne dobavlal v DB basket to sozdayu noviy dobavlayu iz basketVM vse tuda
            //                Basket basket = new Basket
            //                {
            //                    AppUserId = appUser.Id,
            //                    Name = basketVM.Name,
            //                    ProductColorSizeId = basketVM.ProductColorSizeId,
            //                    Count = basketVM.Count
            //                };

            //                baskets.Add(basket);
            //            }
            //            else
            //            {//esli je basket ne null dla kajdogo basket obyekta proverayu esli est to count uvelicivayu
            //                existedBasket.Count += basketVM.Count;
            //                basketVM.Count = existedBasket.Count;
            //            }
            //        }
            //        else
            //        {
            //            Basket basket = new Basket
            //            {
            //                AppUserId = appUser.Id,
            //                ProductId = basketVM.ProductId,
            //                ProductColorSizeId = basketVM.ProductColorSizeId,
            //                Count = basketVM.Count
            //            };

            //            baskets.Add(basket);
            //        }
            //    }

            //    basketCookie = JsonConvert.SerializeObject(basketVMs);

            //    HttpContext.Response.Cookies.Append("basket", basketCookie);

            //    await _unitOfWork.BasketRepository.AddRangeAsync(baskets);
            //    await _unitOfWork.CommitAsync();
            //}
            //else
            //{
            //    if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
            //    {
            //        List<BasketVM> BasketVMs = new List<BasketVM>();

            //        foreach (Basket basket in appUser.Baskets)
            //        {
            //            BasketVM basketVM = new BasketVM
            //            {
            //                ProductId = basket.ProductId,
            //                ProductColorSizeId = basket.ProductColorSizeId,
            //                Count = basket.Count,
            //                Price = basket.Price,
            //                Name = basket.Name
            //            };

            //            BasketVMs.Add(basketVM);
            //        }

            //        basketCookie = JsonConvert.SerializeObject(BasketVMs);

            //        HttpContext.Response.Cookies.Append("basket", basketCookie);
            //    }
            //}
            #endregion

            #region wishlist

            //string wishlistcookie = HttpContext.Request.Cookies["wishlist"];

            //if (!string.IsNullOrWhiteSpace(wishlistcookie))
            //{
            //    List<WishlistVM> WishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlistcookie);

            //    List<Wishlist> wishlists = new List<Wishlist>();

            //    foreach (WishlistVM wishlistVM in WishlistVMs)
            //    {
            //        if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
            //        {
            //            Wishlist existedWishlist = appUser.Wishlists.FirstOrDefault(b => b.ProductId != wishlistVM.ProductId);

            //            if (existedWishlist == null)
            //            {
            //                Wishlist wishlist = new Wishlist
            //                {
            //                    AppUserId = appUser.Id,
            //                    ProductId = wishlistVM.ProductId,
            //                    ProductColorSizeId = wishlistVM.ProductColorSizeId,
            //                    Name = wishlistVM.Name,
            //                    Price = wishlistVM.Price
            //                };

            //                wishlists.Add(wishlist);
            //            }
            //        }
            //        else
            //        {
            //            Wishlist wishlist = new Wishlist
            //            {
            //                AppUserId = appUser.Id,
            //                ProductId = wishlistVM.ProductId,
            //                ProductColorSizeId = wishlistVM.ProductColorSizeId,
            //                Name = wishlistVM.Name,
            //                Price = wishlistVM.Price
            //            };

            //            wishlists.Add(wishlist);
            //        }
            //    }

            //    wishlistcookie = JsonConvert.SerializeObject(WishlistVMs);

            //    HttpContext.Response.Cookies.Append("wishlist", wishlistcookie);

            //    await _unitOfWork.WishlistRepository.AddRangeAsync(wishlists);
            //    await _unitOfWork.CommitAsync();
            //}
            //else
            //{
            //    if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
            //    {
            //        List<WishlistVM> wishlistVMs = new List<WishlistVM>();

            //        foreach (Wishlist wishlist in appUser.Wishlists)
            //        {
            //            WishlistVM wishlistVM = new WishlistVM
            //            {
            //                ProductId = wishlist.ProductId,
            //                ProductColorSizeId = wishlist.ProductColorSizeId,
            //                Name = wishlist.Name,
            //                Price = wishlist.Price
            //            };

            //            wishlistVMs.Add(wishlistVM);
            //        }

            //        wishlistcookie = JsonConvert.SerializeObject(wishlistVMs);

            //        HttpContext.Response.Cookies.Append("wishlist", wishlistcookie);
            //    }
            //}

            #endregion

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                SurName = registerVM.SurName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                GenderId = registerVM.GenderId,
                PhoneNumber = registerVM.PhoneNumber
            };

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            result = await _userManager.AddToRoleAsync(appUser, "Member");

            await _signInManager.SignInAsync(appUser, true);

            #region basket

            //string basketCookie = HttpContext.Request.Cookies["basket"];

            //if (!string.IsNullOrWhiteSpace(basketCookie))
            //{
            //    List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);
            //    //koki prines
            //    List<Basket> baskets = new List<Basket>();
            //    //sozdal noviy list uje DBskiy
            //    foreach (BasketVM basketVM in basketVMs)
            //    {
            //        if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
            //        {//esli on koqda to shto to dobavlal v basket, u neqo v DB est basketskie veshi s druqoqo kompa naprimer
            //            Basket existedBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId != basketVM.ProductId);
            //            //ego basket v kotorom netu tex productov kotorie est v basketvm iz kuki
            //            if (existedBasket == null)
            //            {//esli on nikoqda nicheqo ne dobavlal v DB basket to sozdayu noviy dobavlayu iz basketVM vse tuda
            //                Basket basket = new Basket
            //                {
            //                    AppUserId = appUser.Id,
            //                    ProductId = basketVM.ProductId,
            //                    ProductColorSizeId = basketVM.ProductColorSizeId,
            //                    Count = basketVM.Count
            //                };

            //                baskets.Add(basket);
            //            }
            //            else
            //            {//esli je basket ne null dla kajdogo basket obyekta proverayu esli est to count uvelicivayu
            //                existedBasket.Count += basketVM.Count;
            //                basketVM.Count = existedBasket.Count;
            //            }
            //        }
            //        else
            //        {
            //            Basket basket = new Basket
            //            {
            //                AppUserId = appUser.Id,
            //                ProductId = basketVM.ProductId,
            //                ProductColorSizeId = basketVM.ProductColorSizeId,
            //                Count = basketVM.Count
            //            };

            //            baskets.Add(basket);
            //        }
            //    }

            //    basketCookie = JsonConvert.SerializeObject(basketVMs);

            //    HttpContext.Response.Cookies.Append("basket", basketCookie);

            //    await _unitOfWork.BasketRepository.AddRangeAsync(baskets);
            //    await _unitOfWork.CommitAsync();
            //}
            //else
            //{
            //    if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
            //    {
            //        List<BasketVM> BasketVMs = new List<BasketVM>();

            //        foreach (Basket basket in appUser.Baskets)
            //        {
            //            BasketVM basketVM = new BasketVM
            //            {
            //                ProductId = basket.ProductId,
            //                ProductColorSizeId = basket.ProductColorSizeId,
            //                Count = basket.Count,
            //                Price = basket.Price,
            //                Name = basket.Name
            //            };

            //            BasketVMs.Add(basketVM);
            //        }

            //        basketCookie = JsonConvert.SerializeObject(BasketVMs);

            //        HttpContext.Response.Cookies.Append("basket", basketCookie);
            //    }
            //}

            #endregion

            #region wishlist

            //string wishlistcookie = HttpContext.Request.Cookies["wishlist"];

            //if (!string.IsNullOrWhiteSpace(wishlistcookie))
            //{
            //    List<WishlistVM> WishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlistcookie);

            //    List<Wishlist> wishlists = new List<Wishlist>();

            //    foreach (WishlistVM wishlistVM in WishlistVMs)
            //    {
            //        if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
            //        {
            //            Wishlist existedWishlist = appUser.Wishlists.FirstOrDefault(b => b.ProductId != wishlistVM.ProductId);

            //            if (existedWishlist == null)
            //            {
            //                Wishlist wishlist = new Wishlist
            //                {
            //                    AppUserId = appUser.Id,
            //                    ProductId = wishlistVM.ProductId,
            //                    ProductColorSizeId = wishlistVM.ProductColorSizeId,
            //                    Name = wishlistVM.Name,
            //                    Price = wishlistVM.Price
            //                };

            //                wishlists.Add(wishlist);
            //            }
            //        }
            //        else
            //        {
            //            Wishlist wishlist = new Wishlist
            //            {
            //                AppUserId = appUser.Id,
            //                ProductId = wishlistVM.ProductId,
            //                ProductColorSizeId = wishlistVM.ProductColorSizeId,
            //                Name = wishlistVM.Name,
            //                Price = wishlistVM.Price
            //            };

            //            wishlists.Add(wishlist);
            //        }
            //    }

            //    wishlistcookie = JsonConvert.SerializeObject(WishlistVMs);

            //    HttpContext.Response.Cookies.Append("wishlist", wishlistcookie);

            //    await _unitOfWork.WishlistRepository.AddRangeAsync(wishlists);
            //    await _unitOfWork.CommitAsync();
            //}
            //else
            //{
            //    if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
            //    {
            //        List<WishlistVM> wishlistVMs = new List<WishlistVM>();

            //        foreach (Wishlist wishlist in appUser.Wishlists)
            //        {
            //            WishlistVM wishlistVM = new WishlistVM
            //            {
            //                ProductId = wishlist.ProductId,
            //                ProductColorSizeId = wishlist.ProductColorSizeId,
            //                Name = wishlist.Name,
            //                Price = wishlist.Price
            //            };

            //            wishlistVMs.Add(wishlistVM);
            //        }

            //        wishlistcookie = JsonConvert.SerializeObject(wishlistVMs);

            //        HttpContext.Response.Cookies.Append("wishlist", wishlistcookie);
            //    }
            //}

            #endregion

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
