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
using Pull_Bear.Core;

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

            services.FluentValidatorBuilder();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.IdentityBuilder();

            services.AddAutoMapper(options =>
            {
                options.AddProfile(new MappingProfile());
            });

            services.ServicesBuilder();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ExceptionHandling();
            //budu

            app.UseSession();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.EndpointBuilder();
        }
    }
}
