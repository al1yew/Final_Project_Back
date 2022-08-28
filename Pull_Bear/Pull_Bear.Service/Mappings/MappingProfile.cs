﻿using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using Pull_Bear.Service.ViewModels.TagVMs;
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

            #region Tag
            CreateMap<Tag, TagListVM>();

            CreateMap<TagCreateVM, Tag>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<Tag, TagGetVM>();

            CreateMap<TagGetVM, TagUpdateVM>();
            #endregion

            #region Product

            CreateMap<Product, ProductListVM>()
                .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes));

            CreateMap<ProductColorSize, ProductColorSizeListVM>();

            CreateMap<ProductCreateVM, Product>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.Description, src => src.MapFrom(x => x.Description.Trim()))
                .ForMember(des => des.Care, src => src.MapFrom(x => x.Care.Trim()))
                .ForMember(des => des.Composition, src => src.MapFrom(x => x.Composition.Trim()))
                .ForMember(des => des.PhotoModelIndicators, src => src.MapFrom(x => x.PhotoModelIndicators.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<Product, ProductGetVM>();

            CreateMap<ProductGetVM, ProductUpdateVM>();
            #endregion
        }
    }
}
