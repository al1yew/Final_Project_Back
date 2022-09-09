using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
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
        private readonly IMapper _mapper;

        public BasketController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            return View(new BasketIndexVM() { BasketVM = await _getBasketItemAsync(basketVMs), Products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllAsync("ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category")) });
        }

        public async Task<IActionResult> AddToBasket(AddToBasketVM addToBasketVM)
        {
            if (addToBasketVM.ColorId <= 0 || addToBasketVM.SizeId <= 0 || addToBasketVM.ProductId <= 0) return BadRequest();

            Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == addToBasketVM.ProductId, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category");

            if (dbProduct == null) return NotFound();

            if (dbProduct.Count <= 0) return BadRequest();

            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            ProductColorSize productColorSize = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == addToBasketVM.ProductId && x.ColorId == addToBasketVM.ColorId && x.SizeId == addToBasketVM.SizeId, "Product", "Size", "Color");

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
                ProductColorSize pcs = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == addToBasketVM.ProductId && x.ColorId == addToBasketVM.ColorId && x.SizeId == addToBasketVM.SizeId, "Product", "Size", "Color");

                if (pcs != null)
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
                        Seria = dbProduct.Seria,
                        Count = 1
                    };

                    basketVMs.Add(basketVM);
                }
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
                        ProductColorSize pcs = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == addToBasketVM.ProductId && x.ColorId == addToBasketVM.ColorId && x.SizeId == addToBasketVM.SizeId, "Product", "Size", "Color");

                        if (pcs != null)
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
                }
                else
                {
                    ProductColorSize pcs = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == addToBasketVM.ProductId && x.ColorId == addToBasketVM.ColorId && x.SizeId == addToBasketVM.SizeId, "Product", "Size", "Color");

                    if (pcs != null)
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
                }

                await _unitOfWork.CommitAsync();
            }

            basket = JsonConvert.SerializeObject(basketVMs);

            HttpContext.Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", await _getBasketItemAsync(basketVMs));
        }

        public async Task<IActionResult> DeleteFromBasket(DeleteFromBasketVM deleteFromBasketVM)
        {
            if (deleteFromBasketVM == null) return BadRequest();

            if (await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == deleteFromBasketVM.ProductId && x.ColorId == deleteFromBasketVM.ColorId && x.SizeId == deleteFromBasketVM.SizeId && !x.Product.IsDeleted, "Product", "Color", "Size") == null) return NotFound();

            string basket = HttpContext.Request.Cookies["basket"];

            if (string.IsNullOrWhiteSpace(basket)) return BadRequest();

            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            BasketVM basketVM = basketVMs.Find(b => b.ProductId == deleteFromBasketVM.ProductId && b.ColorId == deleteFromBasketVM.ColorId && b.SizeId == deleteFromBasketVM.SizeId);

            if (basketVM == null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == deleteFromBasketVM.ProductId && b.ColorId == deleteFromBasketVM.ColorId && b.SizeId == deleteFromBasketVM.SizeId);

                    if (dbBasket != null)
                    {
                        _unitOfWork.BasketRepository.Remove(dbBasket);

                        await _unitOfWork.CommitAsync();
                    }
                }
            }

            basketVMs.Remove(basketVM);

            basket = JsonConvert.SerializeObject(basketVMs);

            Response.Cookies.Append("basket", basket);

            return PartialView("_BasketPartial", await _getBasketItemAsync(basketVMs));
        }

        public async Task<IActionResult> DeleteFromCart(DeleteFromBasketVM deleteFromBasketVM)
        {
            if (deleteFromBasketVM == null) return BadRequest();

            if (await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == deleteFromBasketVM.ProductId && x.ColorId == deleteFromBasketVM.ColorId && x.SizeId == deleteFromBasketVM.SizeId && !x.Product.IsDeleted, "Product", "Color", "Size") == null) return NotFound();

            string basket = HttpContext.Request.Cookies["basket"];

            if (string.IsNullOrWhiteSpace(basket)) return BadRequest();

            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            BasketVM basketVM = basketVMs.Find(b => b.ProductId == deleteFromBasketVM.ProductId && b.ColorId == deleteFromBasketVM.ColorId && b.SizeId == deleteFromBasketVM.SizeId);

            if (basketVM == null) return NotFound();

            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == deleteFromBasketVM.ProductId && b.ColorId == deleteFromBasketVM.ColorId && b.SizeId == deleteFromBasketVM.SizeId);

                    if (dbBasket != null)
                    {
                        _unitOfWork.BasketRepository.Remove(dbBasket);

                        await _unitOfWork.CommitAsync();
                    }
                }
            }

            basketVMs.Remove(basketVM);

            basket = JsonConvert.SerializeObject(basketVMs);

            Response.Cookies.Append("basket", basket);

            return PartialView("_BasketIndexPartial", await _getBasketItemAsync(basketVMs));
        }

        public async Task<IActionResult> UpdateCount(UpdateBasketVM updateBasketVM)
        {
            if (updateBasketVM == null) return BadRequest();

            if (await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == updateBasketVM.ProductId && x.ColorId == updateBasketVM.ColorId && x.SizeId == updateBasketVM.SizeId && !x.Product.IsDeleted, "Product", "Color", "Size") == null) return NotFound();

            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                BasketVM basketVM = basketVMs.FirstOrDefault(b => b.ProductId == updateBasketVM.ProductId && b.ColorId == updateBasketVM.ColorId && b.SizeId == updateBasketVM.SizeId);

                if (basketVM == null) return NotFound();

                ProductColorSize pcs = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == updateBasketVM.ProductId && x.ColorId == updateBasketVM.ColorId && x.SizeId == updateBasketVM.SizeId);

                if (updateBasketVM.Count <= pcs.Count)
                {
                    if (updateBasketVM.Count <= 5)
                    {
                        basketVM.Count = updateBasketVM.Count <= 0 ? 1 : updateBasketVM.Count;
                    }

                    if (User.Identity.IsAuthenticated)
                    {
                        AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

                        if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                        {
                            Basket dbBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == updateBasketVM.ProductId && b.ColorId == updateBasketVM.ColorId && b.SizeId == updateBasketVM.SizeId);

                            if (dbBasket != null)
                            {
                                if (updateBasketVM.Count <= 5)
                                {
                                    dbBasket.Count = basketVM.Count;
                                }

                                await _unitOfWork.CommitAsync();
                            }
                        }
                    }
                }

                basket = JsonConvert.SerializeObject(basketVMs);

                HttpContext.Response.Cookies.Append("basket", basket);
            }
            else
            {
                return BadRequest();
            }

            return PartialView("_BasketIndexPartial", await _getBasketItemAsync(basketVMs));
        }



        private async Task<List<BasketVM>> _getBasketItemAsync(List<BasketVM> basketVms)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            }

            foreach (BasketVM item in basketVms)
            {
                ProductColorSize pcs = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == item.ProductId && x.ColorId == item.ColorId && x.SizeId == item.SizeId, "Product", "Size", "Color");

                if (pcs != null)
                {
                    item.Name = pcs.Product.Name;
                    item.Price = pcs.Product.DiscountPrice;
                    item.ProductImage = pcs.Product.ProductImage;
                    item.SizeId = pcs.SizeId;
                    item.ColorId = pcs.ColorId;
                    item.ColorHexCode = pcs.Color.HexCode;
                    item.ColorName = pcs.Color.Name;
                    item.SizeName = pcs.Size.Name;
                    item.Seria = pcs.Product.Seria;
                }
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
                    foreach (Basket item in appUser.Baskets)
                    {
                        if (!basketVMs.Any(b => b.ProductId == item.ProductId && b.ColorId == item.ColorId && b.SizeId == item.SizeId))
                        {
                            BasketVM basketVM = _mapper.Map<BasketVM>(item);

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
