using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
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
            #region Category
            CreateMap<Category, CategoryListVM>()
                .ForMember(des => des.GenderName, src => src.MapFrom(x => x.Gender.Name));

            CreateMap<Category, CategoryGetVM>();

            CreateMap<CategoryCreateVM, Category>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<CategoryGetVM, CategoryUpdateVM>();
            #endregion

            #region BodyFit
            CreateMap<BodyFit, BodyFitListVM>()
                .ForMember(des => des.GenderName, src => src.MapFrom(x => x.Gender.Name));

            CreateMap<BodyFitCreateVM, BodyFit>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<BodyFit, BodyFitGetVM>();

            CreateMap<BodyFitGetVM, BodyFitUpdateVM>();
            #endregion

            #region Color
            CreateMap<Color, ColorListVM>();

            CreateMap<ColorCreateVM, Color>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<Color, ColorGetVM>();

            CreateMap<ColorGetVM, ColorUpdateVM>();
            #endregion

            #region Size
            CreateMap<Size, SizeListVM>();

            CreateMap<SizeCreateVM, Size>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<Size, SizeGetVM>();

            CreateMap<SizeGetVM, SizeUpdateVM>();
            #endregion

        }
    }
}
