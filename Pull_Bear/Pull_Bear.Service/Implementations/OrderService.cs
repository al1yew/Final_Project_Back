using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Enums;
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

        public async Task<IQueryable<OrderListVM>> GetAllOrders(int? ordertype, int select)
        {
            List<OrderListVM> orders = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllAsync("OrderItems.Product", "AppUser", "OrderItems", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

            IQueryable<OrderListVM> query = orders.AsQueryable();

            if (ordertype != null && ordertype > 0)
            {
                switch (ordertype)
                {
                    case 1:
                        query = query.Where(x => x.OrderStatus == OrderStatus.Pending);
                        break;
                    case 2:
                        query = query.Where(x => x.OrderStatus == OrderStatus.Accepted);
                        break;
                    case 3:
                        query = query.Where(x => x.OrderStatus == OrderStatus.Rejected);
                        break;
                    case 4:
                        query = query.Where(x => x.OrderStatus == OrderStatus.Rejected);
                        break;
                    case 5:
                        query = query.Where(x => x.OrderStatus == OrderStatus.Shipped);
                        break;
                    case 6:
                        query = query.Where(x => x.OrderStatus == OrderStatus.Shipped);
                        break;
                    default:
                        break;
                }
            }
            return query;
        }

        public async Task<List<OrderListVM>> GetOrders()
        {
            AppUser appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            List<OrderListVM> orders = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

            return orders;
        }

        public async Task<OrderListVM> GetOrderById(int? id)
        {
            if (id == null) throw new NotFoundException("Order cannot be found!");

            OrderListVM order = _mapper.Map<OrderListVM>(await _unitOfWork.OrderRepository.GetAsync(x => x.Id == id, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

            return order;
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

        public async Task<List<CardListVM>> CreateCard(CardCreateVM cardCreateVM)
        {
            if (await _unitOfWork.CardRepository.IsExistAsync(x => x.CardNo == cardCreateVM.CardNo))
                throw new RecordDublicateException($"Card Already Exists!");

            AppUser appUser = _userManager.Users.Include(x => x.Cards).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (cardCreateVM.Save)
            {
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

            return _mapper.Map<List<CardListVM>>(await _unitOfWork.CardRepository.GetAllByExAsync(x => x.AppUserId == appUser.Id));
        }

        public async Task<List<AddressListVM>> CreateAddress(AddressCreateVM addressCreateVM)
        {
            AppUser appUser = _userManager.Users.Include(x => x.Addresses).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (addressCreateVM.Save)
            {
                if (appUser.Addresses.Count < 3)
                {
                    Address newAddress = _mapper.Map<Address>(addressCreateVM);

                    newAddress.AppUserId = appUser.Id;
                    newAddress.IsMain = false;

                    await _unitOfWork.AddressRepository.AddAsync(newAddress);
                    await _unitOfWork.CommitAsync();
                }
            }

            return _mapper.Map<List<AddressListVM>>(await _unitOfWork.AddressRepository.GetAllByExAsync(x => x.AppUserId == appUser.Id));
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

        public async Task<List<BasketVM>> DeleteFromBasket(DeleteFromBasketVM deleteFromBasketVM)
        {
            if (await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == deleteFromBasketVM.ProductId && x.ColorId == deleteFromBasketVM.ColorId && x.SizeId == deleteFromBasketVM.SizeId && !x.Product.IsDeleted, "Product", "Color", "Size") == null) throw new NotFoundException("Product cannot be found!");

            ProductColorSize pcs = await _unitOfWork.ProductColorSizeRepository.GetAsync(x => x.ProductId == deleteFromBasketVM.ProductId && x.ColorId == deleteFromBasketVM.ColorId && x.SizeId == deleteFromBasketVM.SizeId, "Product", "Size", "Color");

            pcs.Count += deleteFromBasketVM.CountInBasket;

            Product product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == deleteFromBasketVM.ProductId);

            product.Count += deleteFromBasketVM.CountInBasket;

            await _unitOfWork.CommitAsync();

            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

            if (string.IsNullOrWhiteSpace(basket)) throw new BadRequestException("Basket is null!");

            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            BasketVM basketVM = basketVMs.Find(b => b.ProductId == deleteFromBasketVM.ProductId && b.ColorId == deleteFromBasketVM.ColorId && b.SizeId == deleteFromBasketVM.SizeId);

            if (basketVM == null) throw new NotFoundException("Basket cannot be found!");

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser appUser = await _userManager.Users.Include(u => u.Baskets).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

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

            _httpContextAccessor.HttpContext.Response.Cookies.Append("basket", basket);

            AppUser user = await _userManager.Users.Include(u => u.Baskets).ThenInclude(u => u.Product).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            return _mapper.Map<List<BasketVM>>(user.Baskets);
        }

        public async Task CreateOrder(OrderCreateVM orderCreateVM)
        {
            if (orderCreateVM == null) throw new BadRequestException("Basket is null!");

            AppUser appUser = await _userManager.Users.Include(u => u.Baskets).ThenInclude(x => x.Product).FirstOrDefaultAsync(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            List<OrderItem> orderItems = _mapper.Map<List<OrderItem>>(appUser.Baskets);

            Order order = _mapper.Map<Order>(orderCreateVM);

            order.AppUserId = appUser.Id;
            order.OrderStatus = OrderStatus.Pending;
            order.Price = orderItems.Sum(x => x.Count * x.Price);
            order.CreatedAt = DateTime.UtcNow.AddHours(4);
            order.OrderItems = orderItems;
            order.DeliveredAt = null;

            List<Basket> userbaskets = await _unitOfWork.BasketRepository.GetAllByExAsync(x => x.AppUserId == appUser.Id);

            foreach (Basket item in userbaskets)
            {
                _unitOfWork.BasketRepository.Remove(item);
            }

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            basketVMs = new List<BasketVM>();

            basket = JsonConvert.SerializeObject(basketVMs);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("basket", basket);
        }


        public async Task<double> GetBasket()
        {
            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

            return basketVMs.Sum(x => x.Count * x.Price);
        }

        public async Task<List<OrderListVM>> SortOrders(string sortvalue)
        {
            AppUser appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            switch (sortvalue)
            {
                case "Pending":

                    List<OrderListVM> orders1 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id && x.OrderStatus == OrderStatus.Pending, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

                    return orders1;

                case "Rejected":

                    List<OrderListVM> orders2 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id && x.OrderStatus == OrderStatus.Rejected, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

                    return orders2;

                case "Shipped":

                    List<OrderListVM> orders3 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id && x.OrderStatus == OrderStatus.Shipped, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

                    return orders3;

                case "Delivered":

                    List<OrderListVM> orders4 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id && x.OrderStatus == OrderStatus.Delivered, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

                    return orders4;

                case "Courier":

                    List<OrderListVM> orders5 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id && x.OrderStatus == OrderStatus.Courier, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

                    return orders5;

                case "Accepted":

                    List<OrderListVM> orders6 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id && x.OrderStatus == OrderStatus.Accepted, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

                    return orders6;

                case "All":

                    List<OrderListVM> orders = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));
                    return orders;

                default:

                    List<OrderListVM> orders12 = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));
                    return orders12;
            }
        }

        public async Task<List<OrderListVM>> Search(string search)
        {
            AppUser appUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            List<OrderListVM> orders = _mapper.Map<List<OrderListVM>>(await _unitOfWork.OrderRepository.GetAllByExAsync(x => !x.IsDeleted && x.AppUserId == appUser.Id, "OrderItems", "OrderItems.Product", "OrderItems.Product.ProductColorSizes", "OrderItems.Product.ProductColorSizes.Color", "OrderItems.Product.ProductColorSizes.Size"));

            orders = orders.Where(x => x.OrderItems.Any(x => x.TrackingNumber.ToString().Contains(search))).ToList();

            return orders;
        }

        public async Task UpdateOrder(int? id, OrderStatus orderStatus)
        {
            if (id == null) throw new BadRequestException("Id is null!");

            Order order = await _unitOfWork.OrderRepository.GetAsync(x => x.Id == id);

            if (order == null) throw new NotFoundException("Order cannot be found!");

            if (orderStatus != OrderStatus.Rejected)
            {
                order.OrderStatus = orderStatus;
            }

            if (orderStatus == OrderStatus.Delivered)
            {
                order.DeliveredAt = DateTime.UtcNow.AddHours(4);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
