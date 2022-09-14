using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Core;
using Pull_Bear.Service.ViewModels.SettingVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AboutController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<SettingListVM> settings = _mapper.Map<List<SettingListVM>>(await _unitOfWork.SettingRepository.GetAllAsync());

            return View(settings.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
