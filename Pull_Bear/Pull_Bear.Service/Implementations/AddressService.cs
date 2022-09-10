using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AddressVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddressService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<AddressListVM>> GetAllAsync()
        {
            AppUser appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            List<AddressListVM> addresses = _mapper.Map<List<AddressListVM>>(await _unitOfWork.AddressRepository.GetAllByExAsync(x => x.AppUserId == appUser.Id));

            return addresses;
        }

        public async Task<AddressGetVM> GetById(int? id)
        {
            AppUser appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            AddressGetVM address = _mapper.Map<AddressGetVM>(await _unitOfWork.AddressRepository.GetAsync(x => x.AppUserId == appUser.Id && x.Id == id));

            return address;
        }

        public async Task CreateAsync(AddressCreateVM addressCreateVM)
        {
            AppUser appUser = _userManager.Users.Include(x => x.Addresses).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (appUser.Addresses.Count < 3)
            {
                Address newAddress = _mapper.Map<Address>(addressCreateVM);

                newAddress.AppUserId = appUser.Id;

                if (addressCreateVM.IsMain)
                {
                    Address dbAddress = await _unitOfWork.AddressRepository.GetAsync(x => x.IsMain && x.AppUserId == appUser.Id);

                    if (dbAddress != null)
                    {
                        dbAddress.IsMain = false;
                    }

                    newAddress.IsMain = addressCreateVM.IsMain;
                }

                await _unitOfWork.AddressRepository.AddAsync(newAddress);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteAsync(int? id)
        {
            Address Address = await _unitOfWork.AddressRepository.GetAsync(x => x.Id == id);

            if (Address == null) throw new NotFoundException("Address cannot be found!");

            AppUser appUser = _userManager.Users.Include(x => x.Addresses).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (Address.IsMain)
            {
                if (appUser.Addresses.Count > 1)
                {
                    appUser.Addresses.FirstOrDefault(x => !x.IsMain).IsMain = true;
                }
            }

            _unitOfWork.AddressRepository.Remove(Address);
            await _unitOfWork.CommitAsync();
        }

        public async Task MakeMain(int? id)
        {
            AppUser appUser = _userManager.Users.Include(x => x.Addresses).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (appUser.Addresses != null)
            {
                if (appUser.Addresses.FirstOrDefault(x => x.IsMain) != null)
                {
                    appUser.Addresses.FirstOrDefault(x => x.IsMain).IsMain = false;
                }
                appUser.Addresses.FirstOrDefault(x => x.Id == id).IsMain = true;
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
