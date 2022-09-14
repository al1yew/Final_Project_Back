using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.WishlistVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class WishlistService : IWishlistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WishlistService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<WishlistVM>> GetWishlists()
        {
            string wishlist = _httpContextAccessor.HttpContext.Request.Cookies["wishlist"];

            List<WishlistVM> wishlistVMs = null;

            if (!string.IsNullOrWhiteSpace(wishlist))
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlist);
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();
            }

            return await _getWishlistItems(wishlistVMs);
        }

        public async Task<bool> AddToWishlist(int? id)
        {
            Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id);

            if (dbProduct == null) return false;

            string wishlist = _httpContextAccessor.HttpContext.Request.Cookies["wishlist"];

            List<WishlistVM> wishlistVMs = null;

            if (!string.IsNullOrWhiteSpace(wishlist))
            {
                wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlist);
            }
            else
            {
                wishlistVMs = new List<WishlistVM>();
            }

            if (!wishlistVMs.Exists(w => w.ProductId == id))
            {
                WishlistVM wishlistVM = new WishlistVM
                {
                    Name = dbProduct.Name,
                    Price = dbProduct.Price,
                    ProductId = dbProduct.Id,
                    Image = dbProduct.ShopImage,
                    DiscountPrice = dbProduct.DiscountPrice,
                };

                wishlistVMs.Add(wishlistVM);
            }

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Wishlists).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

                if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
                {
                    Wishlist dbWishlist = appUser.Wishlists.FirstOrDefault(b => b.ProductId == id);

                    if (dbWishlist == null)
                    {
                        Wishlist newWishlist = new Wishlist()
                        {
                            Name = dbProduct.Name,
                            Price = dbProduct.Price,
                            ProductId = dbProduct.Id,
                            Image = dbProduct.ShopImage,
                            DiscountPrice = dbProduct.DiscountPrice
                        };

                        appUser.Wishlists.Add(newWishlist);
                    }
                }
                else
                {
                    List<Wishlist> wishlists = new List<Wishlist>
                    {
                        new Wishlist{
                            Name = dbProduct.Name,
                            Price = dbProduct.Price,
                            ProductId = dbProduct.Id,
                            Image = dbProduct.ShopImage,
                            DiscountPrice = dbProduct.DiscountPrice
                        }
                    };

                    appUser.Wishlists = wishlists;
                }

                await _unitOfWork.CommitAsync();
            }

            wishlist = JsonConvert.SerializeObject(wishlistVMs);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("wishlist", wishlist);

            return true;
        }

        public async Task<List<WishlistVM>> DeleteFromWishlist(int? id)
        {
            if (id == null) throw new BadRequestException("Id is null!");

            if (!await _unitOfWork.ProductRepository.IsExistAsync(p => p.Id == id)) throw new NotFoundException("Product cannot be found!");

            string wishlist = _httpContextAccessor.HttpContext.Request.Cookies["wishlist"];

            if (string.IsNullOrWhiteSpace(wishlist)) throw new BadRequestException("Wishlist cookie is null!");

            List<WishlistVM> wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlist);

            WishlistVM wishlistVM = wishlistVMs.Find(b => b.ProductId == id);

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Wishlists).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

                if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
                {
                    Wishlist dbWishlist = await _unitOfWork.WishlistRepository.GetAsync(x => x.ProductId == id && x.AppUserId == appUser.Id);

                    if (dbWishlist != null)
                    {
                        _unitOfWork.WishlistRepository.Remove(dbWishlist);

                        await _unitOfWork.CommitAsync();
                    }
                }
            }

            wishlistVMs.Remove(wishlistVM);

            wishlist = JsonConvert.SerializeObject(wishlistVMs);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("wishlist", wishlist);

            return await _getWishlistItems(wishlistVMs);
        }

        private async Task<List<WishlistVM>> _getWishlistItems(List<WishlistVM> wishlistVMs)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Wishlists).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);
            }

            foreach (WishlistVM item in wishlistVMs)
            {
                Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == item.ProductId);

                item.Name = dbProduct.Name;
                item.Price = dbProduct.Price;
                item.ProductId = dbProduct.Id;
                item.Image = dbProduct.ShopImage;
                item.DiscountPrice = dbProduct.DiscountPrice;
            }

            return wishlistVMs;
        }
    }
}
