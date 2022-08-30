using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
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
                .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes))
                .ForPath(des => des.ProductToTags, src => src.MapFrom(x => x.ProductToTags));

            CreateMap<ProductColorSize, ProductColorSizeGetVM>();
            CreateMap<ProductColorSizeGetVM, ProductColorSize>();

            CreateMap<ProductImage, ProductImageGetVM>();
            CreateMap<ProductImageGetVM, ProductImage>();

            CreateMap<ProductToTag, ProductToTagGetVM>();
            CreateMap<ProductToTagGetVM, ProductToTag>();

            CreateMap<ProductCreateVM, Product>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.BodyFitId, src => src.MapFrom(x => x.BodyFitId))
                .ForMember(des => des.CategoryId, src => src.MapFrom(x => x.CategoryId))
                .ForMember(des => des.GenderId, src => src.MapFrom(x => x.GenderId))
                .ForMember(des => des.Count, src => src.MapFrom(x => 0))
                .ForMember(des => des.DiscountPrice, src => src.MapFrom(x => x.DiscountPrice))
                .ForMember(des => des.Price, src => src.MapFrom(x => x.Price))
                .ForMember(des => des.IsHotSale, src => src.MapFrom(x => x.IsHotSale))
                .ForMember(des => des.IsNew, src => src.MapFrom(x => x.IsNew))
                .ForMember(des => des.IsPreOrder, src => src.MapFrom(x => x.IsPreOrder))
                .ForMember(des => des.MainImage1, src => src.MapFrom(x => ""))
                .ForMember(des => des.MainImage2, src => src.MapFrom(x => ""))
                .ForMember(des => des.ProductImage, src => src.MapFrom(x => ""))
                .ForMember(des => des.Seria, src => src.MapFrom(x => ""))
                .ForMember(des => des.Count, src => src.MapFrom(x => 0))
                .ForMember(des => des.Description, src => src.MapFrom(x => x.Description.Trim()))
                .ForMember(des => des.Care, src => src.MapFrom(x => x.Care.Trim()))
                .ForMember(des => des.Composition, src => src.MapFrom(x => x.Composition.Trim()))
                .ForMember(des => des.PhotoModelIndicators, src => src.MapFrom(x => x.PhotoModelIndicators.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)))
                .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes))
                .ForPath(des => des.ProductToTags, src => src.MapFrom(x => x.ProductToTags));

            CreateMap<Product, ProductGetVM>()
                .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes));

            CreateMap<ProductGetVM, ProductUpdateVM>();
            #endregion
        }
    }
}
