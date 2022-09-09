using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.BasketVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            return View(await _getBasketItemAsync(basketVMs));
        }

        public async Task<IActionResult> AddToBasket(AddToBasketVM addToBasketVM)
        {
            if (addToBasketVM.ColorId <= 0 || addToBasketVM.SizeId <= 0 || addToBasketVM.ProductId <= 0) return BadRequest();

            Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == addToBasketVM.ProductId, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category");

            if (dbProduct == null) return NotFound();

            if (dbProduct.Count <= 0) return BadRequest();

            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            if (basketVMs.Exists(bvm => bvm.ProductId == addToBasketVM.ProductId && bvm.ColorId == addToBasketVM.ColorId && bvm.SizeId == addToBasketVM.SizeId))
            {
                basketVMs.Find(bvm => bvm.ProductId == addToBasketVM.ProductId && bvm.ColorId == addToBasketVM.ColorId && bvm.SizeId == addToBasketVM.SizeId).Count++;
            }
            else
            {
                BasketVM basketVM = new BasketVM
                {
                    ProductId = addToBasketVM.ProductId,
                    SizeId = addToBasketVM.SizeId,
                    ColorId = addToBasketVM.ColorId,
                    ProductImage = dbProduct.ProductImage,
                    ColorHexCode = _unitOfWork.ColorRepository.GetAsync(x => x.Id == addToBasketVM.ColorId).Result.HexCode,
                    ColorName = _unitOfWork.ColorRepository.GetAsync(x => x.Id == addToBasketVM.ColorId).Result.Name,
                    Name = dbProduct.Name,
                    Price = dbProduct.DiscountPrice,
                    SizeName = _unitOfWork.SizeRepository.GetAsync(x => x.Id == addToBasketVM.SizeId).Result.Name,
                    Count = 1
                };

                basketVMs.Add(basketVM);
            }

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == addToBasketVM.ProductId && b.ColorId == addToBasketVM.ColorId && b.SizeId == addToBasketVM.SizeId);

                    if (dbBasket != null)
                    {
                        dbBasket.Count += 1;
                    }
                    else
                    {
                        Basket newBasket = new Basket
                        {
                            ProductId = addToBasketVM.ProductId,
                            SizeId = addToBasketVM.SizeId,
                            ColorId = addToBasketVM.ColorId,
                            Name = dbProduct.Name,
                            Price = dbProduct.DiscountPrice,
                            Count = 1
                        };

                        appUser.Baskets.Add(newBasket);
                    }
                }
                else
                {
                    List<Basket> baskets = new List<Basket>
                    {
                        new Basket
                        {
                            ProductId = addToBasketVM.ProductId,
                            SizeId = addToBasketVM.SizeId,
                            ColorId = addToBasketVM.ColorId,
                            Name = dbProduct.Name,
                            Price = dbProduct.DiscountPrice,
                            Count = 1
                        }
                    };

                    appUser.Baskets = baskets;
                }

                await _unitOfWork.CommitAsync();
            }

            basket = JsonConvert.SerializeObject(basketVMs);

            HttpContext.Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", await _getBasketItemAsync(basketVMs));
        }

        //        //[Authorize(Roles = "Member")]
        //        public async Task<IActionResult> UpdateCount(int? id, int count)
        //        {
        //            if (id == null) return BadRequest();

        //            if (!await _context.Products.AnyAsync(p => p.Id == id)) return NotFound();

        //            string basket = HttpContext.Request.Cookies["basket"];

        //            List<BasketVM> basketVMs = null;

        //            if (!string.IsNullOrWhiteSpace(basket))
        //            {
        //                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

        //                BasketVM basketVM = basketVMs.FirstOrDefault(b => b.ProductId == id);

        //                if (basketVM == null) return NotFound();

        //                basketVM.Count = count <= 0 ? 1 : count;

        //                if (User.Identity.IsAuthenticated)
        //                {
        //                    AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        //                    if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
        //                    {
        //                        Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == id);

        //                        if (dbBasket != null)
        //                        {
        //                            dbBasket.Count = basketVM.Count;

        //                            //ViewBag.BasketCountForProductDetail = dbBasket.Count;

        //                            await _context.SaveChangesAsync();
        //                        }
        //                    }
        //                }

        //                basket = JsonConvert.SerializeObject(basketVMs);

        //                HttpContext.Response.Cookies.Append("basket", basket);
        //            }
        //            else
        //            {
        //                return BadRequest();
        //            }

        //            return PartialView("_BasketIndexPartial", await _getBasketItemAsync(basketVMs));
        //        }
        //        //[Authorize(Roles = "Member")]
        //        public async Task<IActionResult> DeleteFromCart(int? id)
        //        {
        //            if (id == null) return BadRequest();

        //            if (!await _context.Products.AnyAsync(p => p.Id == id)) return NotFound();

        //            string basket = HttpContext.Request.Cookies["basket"];

        //            if (string.IsNullOrWhiteSpace(basket)) return BadRequest();

        //            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

        //            BasketVM basketVM = basketVMs.Find(b => b.ProductId == id);

        //            if (basketVM == null) return NotFound();

        //            if (User.Identity.IsAuthenticated)
        //            {
        //                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        //                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
        //                {
        //                    Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == id);

        //                    if (dbBasket != null)
        //                    {
        //                        appUser.Baskets.Remove(dbBasket);
        //                        _context.Baskets.Remove(dbBasket);
        //                        await _context.SaveChangesAsync();
        //                    }
        //                }
        //            }

        //            basketVMs.Remove(basketVM);

        //            basket = JsonConvert.SerializeObject(basketVMs);

        //            Response.Cookies.Append("basket", basket);

        //            return PartialView("_BasketIndexPartial", await _getBasketItemAsync(basketVMs));
        //        }
        //        //[Authorize(Roles = "Member")]
        //        public async Task<IActionResult> DeleteFromBasket(int? id)
        //        {
        //            if (id == null) return BadRequest();

        //            if (!await _context.Products.AnyAsync(p => p.Id == id)) return NotFound();

        //            string basket = HttpContext.Request.Cookies["basket"];

        //            if (string.IsNullOrWhiteSpace(basket)) return BadRequest();

        //            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

        //            BasketVM basketVM = basketVMs.Find(b => b.ProductId == id);

        //            if (basketVM == null) return NotFound();

        //            if (User.Identity.IsAuthenticated)
        //            {
        //                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

        //                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
        //                {
        //                    Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == id);

        //                    if (dbBasket != null)
        //                    {
        //                        appUser.Baskets.Remove(dbBasket);
        //                        _context.Baskets.Remove(dbBasket);
        //                        await _context.SaveChangesAsync();
        //                    }
        //                }
        //            }

        //            basketVMs.Remove(basketVM);

        //            basket = JsonConvert.SerializeObject(basketVMs);

        //            Response.Cookies.Append("basket", basket);

        //            return PartialView("_BasketPartial", await _getBasketItemAsync(basketVMs));
        //        }

        private async Task<List<BasketVM>> _getBasketItemAsync(List<BasketVM> basketVms)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            }

            foreach (BasketVM item in basketVms)
            {
                Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category");

                item.Name = dbProduct.Name;
                item.Price = dbProduct.DiscountPrice;
                item.ProductImage = dbProduct.ProductImage;
            }

            return basketVms;
        }

        public async Task<IActionResult> GetBasket()
        {
            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    foreach (var item in appUser.Baskets)
                    {
                        if (!basketVMs.Any(b => b.ProductId == item.ProductId))
                        {
                            BasketVM basketVM = new BasketVM
                            {
                                ProductId = item.ProductId,
                                SizeId = item.SizeId,
                                ColorId = item.ColorId,
                                Name = item.Name,
                                Price = item.Price,
                                Count = item.Count
                            };

                            basketVMs.Add(basketVM);
                        }
                    }

                    basket = JsonConvert.SerializeObject(basketVMs);

                    Response.Cookies.Append("basket", basket);
                }
            }

            return PartialView("_BasketPartial", await _getBasketItemAsync(basketVMs));
        }
    }
}
