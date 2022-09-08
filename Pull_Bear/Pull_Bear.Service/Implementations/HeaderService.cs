using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using Pull_Bear.Service.ViewModels.HeaderVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class HeaderService : IHeaderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HeaderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<HeaderVM> GetData()
        {
            List<CategoryListVM> categories = _mapper.Map<List<CategoryListVM>>(await _unitOfWork.CategoryRepository.GetAllByExAsync(x => x.IsMain && !x.IsDeleted, "Parent", "Children", "Gender"));

            HeaderVM headerVM = new HeaderVM()
            {
                Categories = categories
            };

            return headerVM;
        }
    }
}
