using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SettingVMs;
using Pull_Bear.Service.ViewModels.ShopVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
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

        public async Task<ShopVM> GetDataAsync()
        {
            ShopVM shopVM = new ShopVM()
            {
                Products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => !x.IsDeleted, "ProductColorSizes", "ProductColorSizes.Color", "ProductColorSizes.Size", "ProductImages", "BodyFit", "Gender", "Category")),
                BodyFits = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllByExAsync(x => !x.IsDeleted)),
                Categories = _mapper.Map<List<CategoryListVM>>(await _unitOfWork.CategoryRepository.GetAllByExAsync(x => !x.IsDeleted, "Children", "Parent")),
                Colors = _mapper.Map<List<ColorListVM>>(await _unitOfWork.ColorRepository.GetAllByExAsync(x => !x.IsDeleted)),
                Sizes = _mapper.Map<List<SizeListVM>>(await _unitOfWork.SizeRepository.GetAllByExAsync(x => !x.IsDeleted)),
                ProductColorSizes = _mapper.Map<List<ProductColorSizeGetVM>>(await _unitOfWork.ProductColorSizeRepository.GetAllAsync()),
                Settings = _mapper.Map<List<SettingListVM>>(await _unitOfWork.SettingRepository.GetAllAsync()).ToDictionary(x => x.Key, x => x.Value)
            };

            return shopVM;
        }
    }
}
