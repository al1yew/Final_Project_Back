using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.SettingVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;

        public SettingController(IMapper mapper, ISettingService settingService)
        {
            _mapper = mapper;
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _settingService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SettingUpdateVM settingUpdateVM)
        {
            List<SettingUpdateVM> settingUpdateVMs = await _settingService.Update(settingUpdateVM);

            return PartialView("_SettingIndexPartial", settingUpdateVMs.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
