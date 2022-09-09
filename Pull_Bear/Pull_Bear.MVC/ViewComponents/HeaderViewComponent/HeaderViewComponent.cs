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
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HeaderViewComponent(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
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
                            if (!basketVMs.Any(b => b.ProductId == item.ProductId && b.ColorId == item.ColorId && b.SizeId == item.SizeId))
                            {
                                BasketVM basketVM = _mapper.Map<BasketVM>(item);

                                basketVMs.Add(basketVM);
                            }
                        }

                        basket = JsonConvert.SerializeObject(basketVMs);

                        HttpContext.Response.Cookies.Append("basket", basket);
                    }
                }

                foreach (BasketVM item in basketVMs)
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
