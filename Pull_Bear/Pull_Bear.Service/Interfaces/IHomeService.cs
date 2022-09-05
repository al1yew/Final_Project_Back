using Pull_Bear.Service.ViewModels.HomeVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IHomeService
    {
        Task<HomeVM> GetDataAsync();
    }
}
