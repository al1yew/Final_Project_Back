using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.ViewComponents.HeaderViewComponent
{
    public class Header : ViewComponent
    {
        private readonly IHeaderService _headerService;
        public Header(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _headerService.GetData());
        }
    }
}
