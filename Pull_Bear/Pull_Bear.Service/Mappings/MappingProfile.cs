using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryCreateVM, Category>()
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x=> DateTime.UtcNow.AddHours(4)));

            CreateMap<Category, CategoryGetVM>();
            CreateMap<Category, CategoryListVM>();
        }
    }
}
