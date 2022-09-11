using Pull_Bear.Service.ViewModels.AppUserVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IAccountInfoService
    {
        Task<AppUserUpdateVM> GetUser();
        Task<List<string>> UpdateUser(AppUserUpdateVM appUserUpdateVM);
    }
}
