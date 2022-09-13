using AutoMapper;
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
        private readonly IMapper _mapper;

        public AccountController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            AppUser appUser = await _userManager.Users.Include(u => u.Baskets).Include(x => x.Wishlists).FirstOrDefaultAsync(u => (u.NormalizedEmail == loginVM.Email.Trim().ToUpperInvariant() || u.NormalizedUserName == loginVM.Email.Trim().ToUpperInvariant()) && !u.IsAdmin && !u.IsDeleted);

            if (appUser == null || appUser.IsAdmin || !await _userManager.CheckPasswordAsync(appUser, loginVM.Password))
            {
                ModelState.AddModelError("", "Email or Password is wrong!");

                return View();
            }

            await _signInManager.SignInAsync(appUser, loginVM.RememberMe);

            #region Basket

            string basketCookie = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(basketCookie))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);

                foreach (BasketVM basketVM in basketVMs)
                {
                    if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                    {
                        Basket existedBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == basketVM.ProductId && b.ColorId == basketVM.ColorId && b.SizeId == basketVM.SizeId);

                        if (existedBasket == null)
                        {
                            appUser.Baskets.Add(_mapper.Map<Basket>(basketVM));
                        }
                        else
                        {
                            existedBasket.Count = basketVM.Count;
                        }
                    }
                    else
                    {
                        appUser.Baskets.Add(_mapper.Map<Basket>(basketVM));
                    }
                }

                HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

                await _unitOfWork.CommitAsync();
            }
            else
            {
                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(_mapper.Map<List<BasketVM>>(appUser.Baskets)));
                }
            }

            #endregion

            #region Wishlist

            string wishlistCookie = HttpContext.Request.Cookies["wishlist"];

            if (!string.IsNullOrWhiteSpace(wishlistCookie))
            {
                List<WishlistVM> wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlistCookie);

                foreach (WishlistVM wishlistVM in wishlistVMs)
                {
                    if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
                    {
                        Wishlist existedwishlist = appUser.Wishlists.FirstOrDefault(b => b.ProductId == wishlistVM.ProductId);

                        if (existedwishlist == null)
                        {
                            appUser.Wishlists.Add(_mapper.Map<Wishlist>(wishlistVM));
                        }
                    }
                    else
                    {
                        appUser.Wishlists.Add(_mapper.Map<Wishlist>(wishlistVM));
                    }
                }

                HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlistVMs));

                await _unitOfWork.CommitAsync();
            }
            else
            {
                if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
                {
                    HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(_mapper.Map<List<WishlistVM>>(appUser.Wishlists)));
                }
            }

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

            AppUser appUser = _mapper.Map<AppUser>(registerVM);

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

            #region Basket

            string basketCookie = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(basketCookie))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);

                if (appUser.Baskets == null)
                {
                    appUser.Baskets = _mapper.Map<List<Basket>>(basketVMs);
                }
                else
                {
                    appUser.Baskets.AddRange(_mapper.Map<List<Basket>>(basketVMs));
                }

                basketCookie = JsonConvert.SerializeObject(basketVMs);

                HttpContext.Response.Cookies.Append("basket", basketCookie);

                await _unitOfWork.CommitAsync();
            }

            #endregion

            #region Wishlist

            string wishlistCookie = HttpContext.Request.Cookies["wishlist"];

            if (!string.IsNullOrWhiteSpace(wishlistCookie))
            {
                List<WishlistVM> wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlistCookie);

                if (appUser.Wishlists == null)
                {
                    appUser.Wishlists = _mapper.Map<List<Wishlist>>(wishlistVMs);
                }
                else
                {
                    appUser.Wishlists.AddRange(_mapper.Map<List<Wishlist>>(wishlistVMs));
                }

                wishlistCookie = JsonConvert.SerializeObject(wishlistVMs);

                HttpContext.Response.Cookies.Append("wishlist", wishlistCookie);

                await _unitOfWork.CommitAsync();
            }

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
