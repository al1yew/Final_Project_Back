using Pull_Bear.Service.ViewModels.SettingVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ISettingService
    {
        Task<IDictionary<string, string>> GetAllAsync();
        Task<List<SettingUpdateVM>> Update(SettingUpdateVM settingUpdateVM);
    }
}
