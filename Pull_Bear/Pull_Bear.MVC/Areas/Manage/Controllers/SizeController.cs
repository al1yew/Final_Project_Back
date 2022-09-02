using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.SizeVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Manage")]
    public class SizeController : Controller
    {
        private readonly ISizeService _sizeService;
        private readonly IMapper _mapper;

        public SizeController(IMapper mapper, ISizeService sizeService)
        {
            _mapper = mapper;
            _sizeService = sizeService;
        }

        public async Task<IActionResult> Index(int? status, int select, int page = 1)
        {
            IQueryable<SizeListVM> sizeListVMs = await _sizeService.GetAllAsync(status);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            return View(PaginationList<SizeListVM>.Create(sizeListVMs, page, select));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SizeCreateVM sizeCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _sizeService.CreateAsync(sizeCreateVM);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            return View(_mapper.Map<SizeUpdateVM>(await _sizeService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, SizeUpdateVM sizeUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _sizeService.UpdateAsync(id, sizeUpdateVM);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, int? status, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _sizeService.DeleteAsync(id);

            IQueryable<SizeListVM> sizeListVMs = await _sizeService.GetAllAsync(status);

            return PartialView("_SizeIndexPartial", PaginationList<SizeListVM>.Create(sizeListVMs, page, select));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _sizeService.RestoreAsync(id);

            IQueryable<SizeListVM> sizeListVMs = await _sizeService.GetAllAsync(status);

            return PartialView("_SizeIndexPartial", PaginationList<SizeListVM>.Create(sizeListVMs, page, select));
        }
    }
}
