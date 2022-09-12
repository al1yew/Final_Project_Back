using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.ViewModels.AccountVMs;
using Pull_Bear.Service.ViewModels.AddressVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CardVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.OrderItemVMs;
using Pull_Bear.Service.ViewModels.OrderVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.ReviewImageVMs;
using Pull_Bear.Service.ViewModels.SettingVMs;
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
                .ForMember(des => des.Description, src => src.MapFrom(x => x.Description.Trim()))
                .ForMember(des => des.Care, src => src.MapFrom(x => x.Care.Trim()))
                .ForMember(des => des.Composition, src => src.MapFrom(x => x.Composition.Trim()))
                .ForMember(des => des.PhotoModelIndicators, src => src.MapFrom(x => x.PhotoModelIndicators.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<Product, ProductGetVM>()
                .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes))
                .ForPath(des => des.ProductReviews, src => src.MapFrom(x => x.ProductReviews))
                .ForPath(des => des.ProductToTags, src => src.MapFrom(x => x.ProductToTags));

            CreateMap<ProductGetVM, ProductUpdateVM>()
                .ForMember(des => des.MaleBodyFitId, src => src.MapFrom(x => (x.GenderId == 2) ? x.BodyFitId : 0))
                .ForMember(des => des.FemaleBodyFitId, src => src.MapFrom(x => (x.GenderId == 1) ? x.BodyFitId : 0))
                .ForMember(des => des.MaleCategoryId, src => src.MapFrom(x => (x.GenderId == 2) ? x.CategoryId : 0))
                .ForMember(des => des.FemaleCategoryId, src => src.MapFrom(x => (x.GenderId == 1) ? x.CategoryId : 0));

            #endregion

            #region Setting

            CreateMap<Setting, SettingUpdateVM>();
            CreateMap<SettingUpdateVM, Setting>();

            #endregion

            #region AppUser
            CreateMap<AppUser, AppUserListVM>();

            CreateMap<AppUserCreateVM, AppUser>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Name.Trim()))
                .ForMember(des => des.CreatedAt, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)));

            CreateMap<AppUser, AppUserGetVM>();

            CreateMap<AppUserGetVM, AppUserUpdateVM>();

            CreateMap<AppUser, AppUserUpdateVM>();
            CreateMap<AppUserUpdateVM, AppUser>();

            CreateMap<RegisterVM, AppUser>();
            #endregion

            #region Home View

            CreateMap<Product, ProductListVM>();
            CreateMap<Setting, SettingListVM>();

            #endregion

            #region Product Review and Review Image

            CreateMap<ProductReview, ProductReviewGetVM>();
            CreateMap<ProductReviewGetVM, ProductReview>();

            CreateMap<WriteReviewVM, ProductReview>()
                .ForMember(des => des.PublishDate, src => src.MapFrom(x => DateTime.UtcNow.AddHours(4)))
                .ForMember(des => des.Review, src => src.MapFrom(x => x.Review.Trim()))
                .ForMember(des => des.Rating, src => src.MapFrom(x => x.Rating))
                .ForMember(des => des.AppUserId, src => src.MapFrom(x => x.AppUserId))
                .ForMember(des => des.Author, src => src.MapFrom(x => (x.Name.Trim() + " " + x.Surname.Trim().Substring(0, 1) + ".")));

            CreateMap<ReviewImage, ReviewImageGetVM>();
            CreateMap<ReviewImageGetVM, ReviewImage>();

            #endregion

            #region Basket

            CreateMap<BasketVM, Basket>();
            CreateMap<Basket, BasketVM>();

            #endregion

            #region Card

            CreateMap<Card, CardListVM>();
            CreateMap<CardListVM, Card>();

            CreateMap<Card, CardGetVM>();
            CreateMap<CardGetVM, Card>();

            CreateMap<CardCreateVM, Card>()
                .ForMember(des => des.CardHolder, src => src.MapFrom(x => x.Name.ToUpperInvariant() + " " + x.Surname.ToUpperInvariant()));

            #endregion

            #region Address

            CreateMap<Address, AddressListVM>();
            CreateMap<AddressListVM, Address>();

            CreateMap<Address, AddressGetVM>();
            CreateMap<AddressGetVM, Address>();

            CreateMap<AddressCreateVM, Address>();

            #endregion

            #region Order

            CreateMap<Order, OrderListVM>()
                .ForPath(des => des.OrderItems, src => src.MapFrom(x => x.OrderItems))
                .ForMember(des => des.DeliveredAt, src => src.MapFrom(x => x.DeliveredAt != null ? x.DeliveredAt : null));

            CreateMap<OrderItem, OrderItemListVM>();
            CreateMap<OrderItemListVM, OrderItem>();

            CreateMap<OrderListVM, Order>();

            CreateMap<OrderCreateVM, Order>();

            CreateMap<AppUser, OrderCreateVM>()
                .ForMember(des => des.FullName, src => src.MapFrom(x => x.Name + " " + x.SurName))
                .ForMember(des => des.Address, src => src.MapFrom(x => (x.Addresses.Where(x => x.IsMain).Select(x => x.Address1).FirstOrDefault() != null ? x.Addresses.Where(x => x.IsMain).Select(x => x.Address1).FirstOrDefault() + ", " : "") + (x.Addresses.Where(x => x.IsMain).Select(x => x.Address2).FirstOrDefault() != null ? x.Addresses.Where(x => x.IsMain).Select(x => x.Address2).FirstOrDefault() + ", " : "")))
                .ForMember(des => des.ZipCode, src => src.MapFrom(x => (x.Addresses.Where(x => x.IsMain).Select(x => x.ZipCode).FirstOrDefault() != null ? x.Addresses.Where(x => x.IsMain).Select(x => x.ZipCode).FirstOrDefault() : "")))
                .ForMember(des => des.CityCountry, src => src.MapFrom(x => (x.Addresses.Where(x => x.IsMain).Select(x => x.City).FirstOrDefault() != null ? x.Addresses.Where(x => x.IsMain).Select(x => x.City).FirstOrDefault() + ", " : "") + (x.Addresses.Where(x => x.IsMain).Select(x => x.Country).FirstOrDefault() != null ? x.Addresses.Where(x => x.IsMain).Select(x => x.Country).FirstOrDefault() + ", " : "")))
                .ForMember(des => des.CardNo, src => src.MapFrom(x => (x.Cards.Where(x => x.IsMain).Select(x => x.CardNo).FirstOrDefault()) != null ? x.Cards.Where(x => x.IsMain).Select(x => x.CardNo).FirstOrDefault() : ""))
                .ForMember(des => des.CardHolder, src => src.MapFrom(x => (x.Cards.Where(x => x.IsMain).Select(x => x.CardHolder).FirstOrDefault() != null ? x.Cards.Where(x => x.IsMain).Select(x => x.CardHolder).FirstOrDefault() : "")))
                .ForMember(des => des.CVV, src => src.MapFrom(x => (x.Cards.Where(x => x.IsMain).Select(x => x.CVV).FirstOrDefault() != null ? x.Cards.Where(x => x.IsMain).Select(x => x.CVV).FirstOrDefault() : "")))
                .ForMember(des => des.ExpireDate, src => src.MapFrom(x => (x.Cards.Where(x => x.IsMain).Select(x => x.ExpireDate).FirstOrDefault() != null ? x.Cards.Where(x => x.IsMain).Select(x => x.ExpireDate).FirstOrDefault() : "")));

            CreateMap<OrderCreateVM, Order>();

            CreateMap<Product, ProductGetVM>()
                .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes));

            Random random = new Random();

            CreateMap<Basket, OrderItem>()
                .ForMember(des => des.Id, src => src.MapFrom(x => 0))
                .ForMember(des => des.TrackingNumber, src => src.MapFrom(x => random.Next()));

            CreateMap<ProductGetVM, Product>()
              .ForPath(des => des.ProductColorSizes, src => src.MapFrom(x => x.ProductColorSizes));

            #endregion
        }
    }
}
