using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.SearchVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Search(string search)
        {
            SearchListVM searchListVM = _searchService.GetAllAsync(search);

            return PartialView("_SearchPartial", searchListVM);
        }
    }
}
