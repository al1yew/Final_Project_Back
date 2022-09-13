using Microsoft.Extensions.DependencyInjection;
using Pull_Bear.Core;
using Pull_Bear.Data;
using Pull_Bear.Service.Implementations;
using Pull_Bear.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Extensions
{
    public static class ServiceKeeper
    {
        public static void ServicesBuilder(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBodyFitService, BodyFitService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<ILayoutService, LayoutService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAccountInfoService, AccountInfoService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IWishlistService, WishlistService>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
