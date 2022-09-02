using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pull_Bear.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.Mappings;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Data.Repositories;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.Implementations;
using Microsoft.AspNetCore.Diagnostics;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.MVC.Extensions;
using Pull_Bear.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Pull_Bear.MVC
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<CategoryCreateVMValidator>();
                options.DisableDataAnnotationsValidation = true;
            });

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(options =>
            {
                options.AddProfile(new MappingProfile());
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBodyFitRepository, BodyFitRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProductToTagRepository, ProductToTagRepository>();
            services.AddScoped<IProductColorSizeRepository, ProductColorSizeRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();


            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBodyFitService, BodyFitService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IAppUserService, AppUserService>();


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            //services.AddScoped<ILayoutService, LayoutService>();

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.ExceptionHandling();

            //app.UseSession();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("Default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
