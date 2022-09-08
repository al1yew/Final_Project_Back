using Pull_Bear.Service.ViewModels.HeaderVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IHeaderService
    {
        Task<HeaderVM> GetData();
    }
}
