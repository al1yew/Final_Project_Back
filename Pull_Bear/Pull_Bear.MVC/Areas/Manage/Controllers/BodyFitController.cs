using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BodyFitController : Controller
    {
        private readonly IBodyFitService _bodyFitService;
        private readonly IMapper _mapper;

        public BodyFitController(IMapper mapper, IBodyFitService bodyFitService)
        {
            _mapper = mapper;
            _bodyFitService = bodyFitService;
        }

        public IActionResult Index(int? status, int? type, int select, int page = 1)
        {
            IQueryable<BodyFitListVM> bodyFitListVMs = _bodyFitService.GetAllAsync(status, type);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Type = type;
            ViewBag.Status = status;
            ViewBag.Page = page;

            return View(PaginationList<BodyFitListVM>.Create(bodyFitListVMs, page, select));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BodyFitCreateVM bodyFitCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _bodyFitService.CreateAsync(bodyFitCreateVM);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            return View(_mapper.Map<BodyFitUpdateVM>(await _bodyFitService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, BodyFitUpdateVM bodyFitUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _bodyFitService.UpdateAsync(id, bodyFitUpdateVM);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, int? status, int? type, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            await _bodyFitService.DeleteAsync(id);

            IQueryable<BodyFitListVM> bodyFitListVMs = _bodyFitService.GetAllAsync(status, type);

            return PartialView("_BodyFitIndexPartial", PaginationList<BodyFitListVM>.Create(bodyFitListVMs, page, select));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int? type, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Type = type;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _bodyFitService.RestoreAsync(id);

            IQueryable<BodyFitListVM> bodyFitListVMs = _bodyFitService.GetAllAsync(status, type);

            return PartialView("_BodyFitIndexPartial", PaginationList<BodyFitListVM>.Create(bodyFitListVMs, page, select));
        }




    }
}
