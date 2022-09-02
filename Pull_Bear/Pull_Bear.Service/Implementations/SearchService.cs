using AutoMapper;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Data.Repositories;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SearchVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBodyFitRepository _bodyFitRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public SearchService(ICategoryRepository categoryRepository, IMapper mapper, IBodyFitRepository bodyFitRepository, IColorRepository colorRepository, ISizeRepository sizeRepository, ITagRepository tagRepository, IProductRepository productRepository, IAppUserRepository appUserRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _bodyFitRepository = bodyFitRepository;
            _colorRepository = colorRepository;
            _sizeRepository = sizeRepository;
            _tagRepository = tagRepository;
            _productRepository = productRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task<SearchListVM> GetAllAsync(string search)
        {
            SearchListVM searchVM = new SearchListVM
            {
                Categories = _mapper.Map<List<CategoryListVM>>(await _categoryRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()), "Gender", "Children", "Parent")),

                BodyFits = _mapper.Map<List<BodyFitListVM>>(await _bodyFitRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()), "Gender")),

                Colors = _mapper.Map<List<ColorListVM>>(await _colorRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()))),

                Sizes = _mapper.Map<List<SizeListVM>>(await _sizeRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()))),

                Tags = _mapper.Map<List<TagListVM>>(await _tagRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()))),

                Products = _mapper.Map<List<ProductListVM>>(await _productRepository.GetAllByExAsync(
                    c => c.Name.ToLower().Contains(search.ToLower()) ||
                    c.Description.ToLower().Contains(search.ToLower()) ||
                    c.Price.ToString().Contains(search.ToLower()) ||
                    c.DiscountPrice.ToString().Contains(search.ToLower()) ||
                    c.Composition.ToLower().Contains(search.ToLower()) ||
                    c.PhotoModelIndicators.ToLower().Contains(search.ToLower()) ||
                    c.BodyFit.Name.ToLower().Contains(search.ToLower()) ||
                    c.Category.Name.ToLower().Contains(search.ToLower()) ||
                    c.Gender.Name.ToLower().Contains(search.ToLower()) ||
                    c.Care.ToLower().Contains(search.ToLower()),
                    "ProductColorSizes.Size", "ProductColorSizes.Color", "Category", "BodyFit", "Gender")),

                Users = _mapper.Map<List<AppUserListVM>>(await _appUserRepository.GetAllByExAsync(x=>x.UserName.ToLower().Trim() == search.Trim().ToLower()))
            };

            return searchVM;
        }
    }
}
