using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pull_Bear.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryListVM>();

            CreateMap<CategoryListVM, Category>();

            CreateMap<List<Category>, List<CategoryListVM>>();

            CreateMap<List<CategoryListVM>, List<Category>>();
        }
    }
}
