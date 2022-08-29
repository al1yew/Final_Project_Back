using Pull_Bear.Service.ViewModels.SearchVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ISearchService
    {
        Task<SearchListVM> GetAllAsync(string search);
    }
}
