using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.HomeVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SettingVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<HomeVM> GetDataAsync()
        {
            HomeVM homeVM = new HomeVM
            {
                Products = _mapper.Map<List<ProductListVM>>(await _unitOfWork.ProductRepository.GetAllByExAsync(x => !x.IsDeleted)),
                Settings = _mapper.Map<List<SettingListVM>>(await _unitOfWork.SettingRepository.GetAllAsync()).ToDictionary(x => x.Key, x => x.Value)
            };

            return homeVM;
        }
    }
}
