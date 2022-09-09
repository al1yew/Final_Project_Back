using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.HeaderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.ViewComponents.HeaderViewComponent
{
    public class Header : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Header(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string basket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

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

                        HttpContext.Response.Cookies.Append("basket", basket);
                    }
                }

                foreach (BasketVM basketVM in basketVMs)
                {
                    Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == basketVM.ProductId, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category");

                    basketVM.Name = dbProduct.Name;
                    basketVM.Price = dbProduct.DiscountPrice;
                    basketVM.ProductImage = dbProduct.ProductImage;
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            List<CategoryListVM> categories = _mapper.Map<List<CategoryListVM>>(await _unitOfWork.CategoryRepository.GetAllByExAsync(x => x.IsMain && !x.IsDeleted, "Parent", "Children", "Gender"));

            HeaderVM headerVM = new HeaderVM()
            {
                Categories = categories,
                BasketVMs = basketVMs
            };

            return View(await Task.FromResult(headerVM));
        }
    }
}
