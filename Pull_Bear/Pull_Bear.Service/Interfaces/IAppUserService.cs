using Microsoft.AspNetCore.Identity;
using Pull_Bear.Service.ViewModels.AccountVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IAppUserService
    {
        IQueryable<AppUserListVM> GetAllAsync(int? status, int? type, ClaimsPrincipal user);

        IQueryable<AppUserListVM> GetAllAsync(ClaimsPrincipal user);

        Task<AppUserGetVM> GetById(string id);

        Task ResetPassword(string id);

        Task<List<string>> ResetPassword(ResetPasswordVM resetPasswordVM, string id);

        Task<List<string>> CreateAsync(AppUserCreateVM appUserCreateVM);

        Task<List<string>> UpdateAsync(string id, AppUserUpdateVM appUserCreateVM);

        Task DeleteAsync(string id);

        Task RestoreAsync(string id);
    }
}
