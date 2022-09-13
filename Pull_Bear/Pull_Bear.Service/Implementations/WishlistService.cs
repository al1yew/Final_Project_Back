using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
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
            AppUser appUser = await _userManager.Users.Include(u => u.Wishlists).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            return _mapper.Map<List<WishlistVM>>(appUser.Wishlists);
        }

        public async Task<bool> AddToWishlist(int? id)
        {
            AppUser appUser = await _userManager.Users.Include(u => u.Wishlists).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (appUser == null) return false;

            if (!appUser.Wishlists.Any(x => x.ProductId == id))
            {
                Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id);

                if (dbProduct == null) return false;

                Wishlist wishlist = new Wishlist()
                {
                    Name = dbProduct.Name,
                    Price = dbProduct.Price,
                    ProductId = dbProduct.Id,
                    Image = dbProduct.ShopImage,
                    DiscountPrice = dbProduct.DiscountPrice
                };

                appUser.Wishlists.Add(wishlist);

                await _unitOfWork.CommitAsync();
            }

            return true;
        }

        public async Task<List<WishlistVM>> DeleteFromWishlist(int? id)
        {
            Wishlist wishlist = await _unitOfWork.WishlistRepository.GetAsync(x => x.Id == id);

            _unitOfWork.WishlistRepository.Remove(wishlist);
            await _unitOfWork.CommitAsync();

            AppUser appUser = await _userManager.Users.Include(u => u.Wishlists).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            List<WishlistVM> wishlists = _mapper.Map<List<WishlistVM>>(await _unitOfWork.WishlistRepository.GetAllByExAsync(x => x.AppUserId == appUser.Id));

            return wishlists;
        }
    }
}
