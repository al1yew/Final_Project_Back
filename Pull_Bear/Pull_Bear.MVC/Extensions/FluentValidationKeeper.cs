using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Extensions
{
    public static class FluentValidationKeeper
    {
        public static void FluentValidatorBuilder(this IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<CategoryCreateVMValidator>();
                options.DisableDataAnnotationsValidation = true;
            });
        }
    }
}
