using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Extensions;
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
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        public ShopService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ShopVM> GetDataAsync(int genderId, int parentcategoryid)
        {
            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => x.GenderId == (genderId <= 0 ? 1 : genderId), "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category"));

            if (parentcategoryid > 0)
            {
                products = products.Where(x => x.ParentCategoryId == parentcategoryid).ToList();
            }

            IQueryable<ProductListVM> query = products.AsQueryable();

            ShopVM shopVM = new ShopVM()
            {
                Products = PaginationList<ProductListVM>.Create(query, 1, 6),

                BodyFits = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllByExAsync(x => !x.IsDeleted && x.GenderId == (genderId <= 0 ? 1 : genderId))),

                Categories = _mapper.Map<List<CategoryListVM>>(await _unitOfWork.CategoryRepository.GetAllByExAsync(x => !x.IsDeleted && x.GenderId == (genderId <= 0 ? 1 : genderId), "Children", "Parent")),

                Colors = _mapper.Map<List<ColorListVM>>(await _unitOfWork.ColorRepository.GetAllByExAsync(x => !x.IsDeleted)),

                Sizes = _mapper.Map<List<SizeListVM>>(await _unitOfWork.SizeRepository.GetAllByExAsync(x => !x.IsDeleted)),

                Settings = _mapper.Map<List<SettingListVM>>(await _unitOfWork.SettingRepository.GetAllAsync()).ToDictionary(x => x.Key, x => x.Value)
            };

            return shopVM;
        }

        public async Task<IQueryable<ProductListVM>> CreateSort(SortVM sortVM)
        {
            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => x.GenderId == (sortVM.GenderId <= 0 ? 1 : sortVM.GenderId), "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category"));

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

                        query = query.OrderBy(x => x.DiscountPrice);

                        return query;

                    case 2:

                        query = query.OrderByDescending(x => x.DiscountPrice);

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

            AppUser appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            ProductDetailVM productDetailVM = new ProductDetailVM()
            {
                Product = product,
                Products = products,
                WriteReviewVM = new WriteReviewVM(),
                CanWrite = appUser != null ? !product.ProductReviews.Any(x => x.AppUserId == appUser.Id) : false
            };

            return productDetailVM;
        }

        public async Task<ProductDetailVM> AddReview(WriteReviewVM writeReviewVM, int? id)
        {
            if (id == null && id <= 0) throw new NotFoundException("ProductCannot be found!");

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = _userManager.Users.FirstOrDefault(u => u.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

                writeReviewVM.AppUserId = user.Id;
                writeReviewVM.Name = user.Name;
                writeReviewVM.Surname = user.SurName;
            }

            ProductReview productReview = _mapper.Map<ProductReview>(writeReviewVM);

            List<ReviewImage> reviewImages = new List<ReviewImage>();

            if (writeReviewVM.Photos != null)
            {
                foreach (IFormFile file in writeReviewVM.Photos)
                {
                    ReviewImage reviewImage = new ReviewImage()
                    {
                        Image = await file.CreateAsync(_env, "assets", "images", "reviews", $"{id}")
                    };

                    reviewImages.Add(reviewImage);
                }
            }

            productReview.ReviewImages = reviewImages;
            productReview.ProductId = (int)id;

            Product dbProduct = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id);

            if (dbProduct.ReviewCount == null)
            {
                dbProduct.ReviewCount = 1;
            }
            else
            {
                dbProduct.ReviewCount++;
            }

            await _unitOfWork.ProductReviewRepository.AddAsync(productReview);
            await _unitOfWork.CommitAsync();

            List<ProductReviewGetVM> productReviews = _mapper.Map<List<ProductReviewGetVM>>(await _unitOfWork.ProductReviewRepository.GetAllByExAsync(x => x.ProductId == id, "ReviewImages"));

            dbProduct.AverageRating = productReviews.Sum(x => x.Rating) / dbProduct.ReviewCount;
            await _unitOfWork.CommitAsync();

            ProductGetVM product = _mapper.Map<ProductGetVM>(await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id && !x.IsDeleted, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category", "ProductReviews", "ProductReviews.ReviewImages"));

            if (product == null)
                throw new NotFoundException("Product cannot be found!");

            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => !x.IsDeleted, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category"));

            AppUser appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            ProductDetailVM productDetailVM = new ProductDetailVM()
            {
                Product = product,
                Products = products,
                WriteReviewVM = new WriteReviewVM(),
                CanWrite = appUser != null ? !product.ProductReviews.Any(x => x.AppUserId == appUser.Id) : false
            };

            return productDetailVM;
        }

        public async Task<List<ProductListVM>> Search(string search)
        {
            List<ProductListVM> products = _mapper.Map<List<ProductListVM>>(
                await _unitOfWork.ProductRepository.GetAllByExAsync(
                p => p.Name.ToLower().Contains(search.ToLower()) ||
                p.Category.Name.ToLower().Contains(search.ToLower()) ||
                p.ProductToTags.Any(x => x.Tag.Name.Contains(search)) ||
                p.Description.ToLower().Contains(search.ToLower()) ||
                p.BodyFit.Name.ToLower().Contains(search.ToLower()) ||
                p.Gender.Name.ToLower().Contains(search.ToLower()), "Category", "Gender", "BodyFit", "ProductToTags"));

            return products;
        }

        public async Task<ProductGetVM> GetReviewCount(int? id)
        {
            ProductGetVM product = _mapper.Map<ProductGetVM>(await _unitOfWork.ProductRepository.GetAsync(x => x.Id == id));

            return product;
        }

        public async Task<int> Like(int? id)
        {
            ProductReview productReview = await _unitOfWork.ProductReviewRepository.GetAsync(x => x.Id == id);

            productReview.LikesCount++;

            await _unitOfWork.CommitAsync();

            return productReview.LikesCount;
        }
    }
}
