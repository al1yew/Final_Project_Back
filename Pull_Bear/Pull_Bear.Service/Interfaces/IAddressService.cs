using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Pull_Bear.Service.ViewModels.AddressVMs;

namespace Pull_Bear.Service.Interfaces
{
    public interface IAddressService
    {
        Task<List<AddressListVM>> GetAllAsync();

        Task<AddressGetVM> GetById(int? id);

        Task CreateAsync(AddressCreateVM addressCreateVM);

        Task MakeMain(int? id);

        Task DeleteAsync(int? id);
    }
}
