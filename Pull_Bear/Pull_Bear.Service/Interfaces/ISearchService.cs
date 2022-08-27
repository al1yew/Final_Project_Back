using Pull_Bear.Service.ViewModels.SearchVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pull_Bear.Service.Interfaces
{
    public interface ISearchService
    {
        SearchListVM GetAllAsync(string search);
    }
}
