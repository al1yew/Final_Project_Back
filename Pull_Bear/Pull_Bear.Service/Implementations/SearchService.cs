using AutoMapper;
using Pull_Bear.Core;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<SearchListVM> GetAllAsync(string search)
        {
            SearchListVM searchVM = new SearchListVM
            {
                Categories = _mapper.Map<List<CategoryListVM>>(await _unitOfWork.CategoryRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()), "Gender", "Children", "Parent")),

                BodyFits = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()), "Gender")),

                Colors = _mapper.Map<List<ColorListVM>>(await _unitOfWork.ColorRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()))),

                Sizes = _mapper.Map<List<SizeListVM>>(await _unitOfWork.SizeRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()))),

                Tags = _mapper.Map<List<TagListVM>>(await _unitOfWork.TagRepository.GetAllByExAsync(c => c.Name.ToLower().Contains(search.ToLower()))),

                Products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(
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

                Users = _mapper.Map<List<AppUserListVM>>(await _unitOfWork.AppUserRepository.GetAllByExAsync(x => x.UserName.ToLower().Trim() == search.Trim().ToLower()))
            };

            return searchVM;
        }
    }
}
