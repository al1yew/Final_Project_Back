using Pull_Bear.Service.ViewModels.AccountVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IAccountService
    {
        Task<int> Login(LoginVM loginVM);
        Task Logout();
        Task<string> GetLockoutTime(LoginVM loginVM);
    }
}
