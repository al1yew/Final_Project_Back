using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SettingVMs;
using Pull_Bear.Service.ViewModels.ShopVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using Pull_Bear.Service.ViewModels.SortVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ShopVM> GetDataAsync(int? genderId)
        {
            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => x.GenderId == (genderId == null || genderId <= 0 ? 1 : genderId), "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category"));

            IQueryable<ProductListVM> query = products.AsQueryable();

            ShopVM shopVM = new ShopVM()
            {
                Products = PaginationList<ProductListVM>.Create(query, 1, 6),

                BodyFits = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllByExAsync(x => !x.IsDeleted && x.GenderId == (genderId == null || genderId <= 0 ? 1 : genderId))),

                Categories = _mapper.Map<List<CategoryListVM>>(await _unitOfWork.CategoryRepository.GetAllByExAsync(x => !x.IsDeleted && x.GenderId == (genderId == null || genderId <= 0 ? 1 : genderId), "Children", "Parent")),

                Colors = _mapper.Map<List<ColorListVM>>(await _unitOfWork.ColorRepository.GetAllByExAsync(x => !x.IsDeleted)),

                Sizes = _mapper.Map<List<SizeListVM>>(await _unitOfWork.SizeRepository.GetAllByExAsync(x => !x.IsDeleted)),

                //ProductColorSizes = PaginationList<ProductColorSizeGetVM>.Create(query, 1, 6),

                Settings = _mapper.Map<List<SettingListVM>>(await _unitOfWork.SettingRepository.GetAllAsync()).ToDictionary(x => x.Key, x => x.Value)
            };

            return shopVM;
        }

        public async Task<IQueryable<ProductListVM>> CreateSort(SortVM sortVM)
        {
            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => x.GenderId == (sortVM.GenderId == null || sortVM.GenderId <= 0 ? 1 : sortVM.GenderId), "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category"));

            IQueryable<ProductListVM> query = products.AsQueryable();

            if (sortVM == null)
            {
                return query;
            }

            if (sortVM.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == sortVM.CategoryId);
            }

            if (sortVM.ParentCategoryId > 0)
            {
                query = query.Where(x => x.ParentCategoryId == sortVM.ParentCategoryId);
            }

            if (sortVM.BodyFitId > 0)
            {
                query = query.Where(x => x.BodyFitId == sortVM.BodyFitId);
            }

            if (sortVM.ColorId > 0)
            {
                query = query.Where(x => x.ProductColorSizes.Any(x => x.ColorId == sortVM.ColorId));
            }

            if (sortVM.SizeId > 0)
            {
                query = query.Where(x => x.ProductColorSizes.Any(x => x.SizeId == sortVM.SizeId));
            }

            if (sortVM.GenderId > 0)
            {
                query = query.Where(x => x.GenderId == sortVM.GenderId);
            }

            if (sortVM.MinValue > 0)
            {
                query = query.Where(x => x.DiscountPrice > sortVM.MinValue);
            }

            if (sortVM.MaxValue > 0)
            {
                query = query.Where(x => x.DiscountPrice < sortVM.MaxValue);
            }

            if (sortVM.OrderBy > 0)
            {
                switch (sortVM.OrderBy)
                {
                    case 1:

                        query = query.OrderByDescending(x => x.DiscountPrice);

                        return query;

                    case 2:

                        query = query.OrderBy(x => x.DiscountPrice);

                        return query;

                    case 3:

                        query = query.OrderBy(x => x.CreatedAt);

                        return query;

                    case 4:

                        query = query.OrderBy(x => x.AverageRating);

                        return query;

                    case 5:

                        query = query.OrderBy(x => x.ReviewCount);

                        return query;
                }
            }

            return query;
        }

        public async Task<ProductDetailVM> GetProduct(int? id)
        {
            ProductGetVM product = _mapper.Map<ProductGetVM>(await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category", "ProductReviews", "ProductReviews.ReviewImages"));

            if (product == null)
                throw new NotFoundException("Product cannot be found!");

            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => !x.IsDeleted, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category"));

            ProductDetailVM productDetailVM = new ProductDetailVM()
            {
                Product = product,
                Products = products,
            };

            return productDetailVM;
        }
    }
}
