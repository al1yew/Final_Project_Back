using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.OrderVMs;
using System;
using System.Collections.Generic;
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

        public Task<OrderGetVm> GetOrder(int? id)
        {
            throw new NotImplementedException();
        }
        public Task CreateOrder(OrderCreateVM orderCreateVM)
        {
            
        }
    }
}
