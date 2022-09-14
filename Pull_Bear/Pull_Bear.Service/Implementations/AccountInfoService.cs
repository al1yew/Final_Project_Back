using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class AccountInfoService : IAccountInfoService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountInfoService(UserManager<AppUser> userManager, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUserUpdateVM> GetUser()
        {
            AppUserUpdateVM appUser = _mapper.Map<AppUserUpdateVM>(await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name));

            if (appUser == null) throw new NotFoundException("User cannot be found!");

            return appUser;
        }


        public async Task<bool> UpdateUser(AppUserUpdateVM appUserUpdateVM)
        {
            AppUser dbAppUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);

            dbAppUser.Name = appUserUpdateVM.Name.Trim();
            dbAppUser.SurName = appUserUpdateVM.SurName.Trim();
            dbAppUser.Email = appUserUpdateVM.Email.Trim();
            dbAppUser.PhoneNumber = appUserUpdateVM.PhoneNumber.Trim();

            IdentityResult identityResult = await _userManager.UpdateAsync(dbAppUser);

            if (!identityResult.Succeeded) return true;

            if (appUserUpdateVM.NewPassword != null && appUserUpdateVM.ConfirmPassword != null && appUserUpdateVM.CurrentPassword != null)
            {
                if (!await _userManager.CheckPasswordAsync(dbAppUser, appUserUpdateVM.CurrentPassword) || appUserUpdateVM.CurrentPassword == appUserUpdateVM.NewPassword) return true;

                IdentityResult result = await _userManager.ChangePasswordAsync(dbAppUser, appUserUpdateVM.CurrentPassword, appUserUpdateVM.NewPassword);

                if (!identityResult.Succeeded) return true;
            }

            return false;
        }
    }
}
