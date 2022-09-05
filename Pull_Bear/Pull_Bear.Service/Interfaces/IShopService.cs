using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.ShopVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IShopService
    {
        Task<ShopVM> GetDataAsync();
    }
}
