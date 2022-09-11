using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<OrderListVM>> GetOrders()
        {
            AppUser appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            List<OrderListVM> orders = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

            return orders;
        }

        public async Task<OrderIndexVM> GetOrderViewModel()
        {
            AppUser appUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name, "Cards", "Addresses", "Baskets", "Baskets.Product");

            OrderIndexVM orderIndexVM = new OrderIndexVM()
            {
                AddressCreateVM = new AddressCreateVM(),
                AppUserUpdateVM = new AppUserUpdateVM(),
                CardCreateVM = new CardCreateVM(),
                OrderCreateVM = _mapper.Map<OrderCreateVM>(appUser),
                AppUserGetVM = _mapper.Map<AppUserGetVM>(appUser),
                Baskets = _mapper.Map<List<BasketVM>>(appUser.Baskets)
            };

            return orderIndexVM;
        }

        public async Task CreateCard(CardCreateVM cardCreateVM)
        {
            if (await _unitOfWork.CardRepository.IsExistAsync(x => x.CardNo == cardCreateVM.CardNo))
                throw new RecordDublicateException($"Card Already Exists!");

            if (cardCreateVM.Save)
            {
                AppUser appUser = _userManager.Users.Include(x => x.Cards).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

                if (appUser.Cards.Count < 3)
                {
                    Card newcard = _mapper.Map<Card>(cardCreateVM);

                    newcard.AppUserId = appUser.Id;
                    newcard.CardHolder = appUser.GenderId == 1 ? "Mrs." + " " + newcard.CardHolder : "Mr." + " " + newcard.CardHolder;
                    newcard.IsMain = false;

                    await _unitOfWork.CardRepository.AddAsync(newcard);
                    await _unitOfWork.CommitAsync();
                }
            }
        }

        public async Task CreateAddress(AddressCreateVM addressCreateVM)
        {
            if (addressCreateVM.Save)
            {
                AppUser appUser = _userManager.Users.Include(x => x.Addresses).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

                if (appUser.Addresses.Count < 3)
                {
                    Address newAddress = _mapper.Map<Address>(addressCreateVM);

                    newAddress.AppUserId = appUser.Id;
                    newAddress.IsMain = false;

                    await _unitOfWork.AddressRepository.AddAsync(newAddress);
                    await _unitOfWork.CommitAsync();
                }
            }
        }

        public async Task<List<string>> UpdateUser(AppUserUpdateVM appUserUpdateVM)
        {
            AppUser dbAppUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            dbAppUser.Name = appUserUpdateVM.Name.Trim();
            dbAppUser.SurName = appUserUpdateVM.SurName.Trim();
            dbAppUser.Email = appUserUpdateVM.Email.Trim();
            dbAppUser.PhoneNumber = appUserUpdateVM.PhoneNumber.Trim();

            IdentityResult identityResult = await _userManager.UpdateAsync(dbAppUser);

            List<string> errors = new List<string>();

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    errors.Add(item.Description);
                }

                return errors;
            }

            return errors;
        }

        public Task CreateOrder(OrderCreateVM orderCreateVM)
        {
            throw new NotImplementedException();
        }
    }
}
