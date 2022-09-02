using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.SettingVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SettingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDictionary<string, string>> GetAllAsync()
        {
            List<Setting> settings = await _unitOfWork.SettingRepository.GetAllAsync();

            return settings.ToDictionary(s => s.Key, s => s.Value);
        }

        public async Task<List<SettingUpdateVM>> Update(SettingUpdateVM settingUpdateVM)
        {
            if (!await _unitOfWork.SettingRepository.IsExistAsync(x => x.Key == settingUpdateVM.Key))
                throw new NotFoundException("Setting cannot be found!");

            Setting setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Key == settingUpdateVM.Key);

            setting.Value = settingUpdateVM.Value;

            await _unitOfWork.CommitAsync();

            return _mapper.Map<List<SettingUpdateVM>>(await _unitOfWork.SettingRepository.GetAllAsync());
        }
    }
}
