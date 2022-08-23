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

            CreateMap<CategoryCreateVM, Category>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<CategoryUpdateVM, Category>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.UpdatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)))
                .ForMember(des => des.IsUpdated, src => src.MapFrom(x => true));

            CreateMap<Category, CategoryGetVM>();

            CreateMap<CategoryGetVM, CategoryUpdateVM>();

        }
    }
}
