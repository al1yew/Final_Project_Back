using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AccountVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public AppUserService(IAppUserRepository appUserRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IQueryable<AppUserListVM> GetAllAsync(ClaimsPrincipal user)
        {
            List<AppUserListVM> appUserListVM = _mapper.Map<List<AppUserListVM>>(_userManager.Users.Where(u => u.UserName != user.Identity.Name));

            return appUserListVM.AsQueryable();
        }

        public IQueryable<AppUserListVM> GetAllAsync(int? status, int? role, ClaimsPrincipal user)
        {
            List<AppUserListVM> appUserListVM = _mapper.Map<List<AppUserListVM>>(_userManager.Users.Where(u => u.UserName != user.Identity.Name));

            IQueryable<AppUserListVM> query = appUserListVM.AsQueryable();

            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = query.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = query.Where(b => !b.IsDeleted);
                }
            }

            if (role != null && role > 0)
            {
                if (role == 1)
                {
                    query = query.Where(c => c.IsAdmin);
                }
                else if (role == 2)
                {
                    query = query.Where(c => !c.IsAdmin);
                }
            }

            return query;
        }

        public async Task<AppUserGetVM> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotFoundException($"Id is null!");

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");

            return _mapper.Map<AppUserGetVM>(appUser);
        }

        public async Task ResetPassword(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotFoundException($"Id is null!");

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");
        }

        public async Task<List<string>> ResetPassword(ResetPasswordVM resetPasswordVM, string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new NotFoundException($"Id is null!");

            AppUser appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");

            if (await _userManager.CheckPasswordAsync(appUser, resetPasswordVM.Password))
                throw new BadRequestException("This password is not appropriate!");

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, token, resetPasswordVM.Password);

            List<string> errors = new List<string>();

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    errors.Add(item.Description);
                }

                return errors;
            }

            return errors;
        }

        public async Task<List<string>> CreateAsync(AppUserCreateVM appUserCreateVM)
        {
            AppUser appUser = _mapper.Map<AppUser>(appUserCreateVM);

            IdentityResult result = await _userManager.CreateAsync(appUser, appUserCreateVM.Password);

            List<string> errors = new List<string>();

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    errors.Add(item.Description);
                }

                return errors;
            }

            if (appUserCreateVM.IsAdmin)
            {
                result = await _userManager.AddToRoleAsync(appUser, "Admin");
            }
            else
            {
                result = await _userManager.AddToRoleAsync(appUser, "Member");
            }

            return errors;
        }

        public async Task<List<string>> UpdateAsync(string id, AppUserUpdateVM appUserCreateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != appUserCreateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            AppUser dbAppUser = await _appUserRepository.GetAsync(x => x.Id == id);

            if (dbAppUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");

            dbAppUser.Name = appUserCreateVM.Name;
            dbAppUser.SurName = appUserCreateVM.SurName;
            dbAppUser.Email = appUserCreateVM.Email;
            dbAppUser.UserName = appUserCreateVM.UserName;
            dbAppUser.IsAdmin = appUserCreateVM.IsAdmin;
            dbAppUser.PhoneNumber = appUserCreateVM.Phone;
            dbAppUser.UpdatedAt = DateTime.UtcNow.AddHours(4);

            IdentityResult result = await _userManager.UpdateAsync(dbAppUser);

            List<string> errors = new List<string>();

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    errors.Add(item.Description);
                }

                return errors;
            }

            if (appUserCreateVM.IsAdmin && !dbAppUser.IsAdmin)
            {
                await _userManager.RemoveFromRoleAsync(dbAppUser, "Member");
                await _userManager.AddToRoleAsync(dbAppUser, "Admin");
            }
            else if (!appUserCreateVM.IsAdmin && dbAppUser.IsAdmin)
            {
                await _userManager.RemoveFromRoleAsync(dbAppUser, "Admin");
                await _userManager.AddToRoleAsync(dbAppUser, "Member");
            }

            return errors;
        }

        public async Task DeleteAsync(string id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            AppUser dbAppUser = await _appUserRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (dbAppUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");

            dbAppUser.IsDeleted = true;
            dbAppUser.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _appUserRepository.CommitAsync();
        }

        public async Task RestoreAsync(string id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            AppUser dbAppUser = await _appUserRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (dbAppUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");

            dbAppUser.IsDeleted = false;
            dbAppUser.DeletedAt = null;

            await _appUserRepository.CommitAsync();
        }
    }
}
