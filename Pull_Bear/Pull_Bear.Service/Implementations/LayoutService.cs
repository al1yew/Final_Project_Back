using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.BasketVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class LayoutService : ILayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public LayoutService(IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<BasketVM>> GetBasket()
        {
            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

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

                        _httpContextAccessor.HttpContext.Response.Cookies.Append("basket", basket);
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
                        item.ItemsCount = pcs.Count;
                    }
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            return basketVMs;
        }
    }
}
