using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.ColorVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Manage")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ColorController(IMapper mapper, IColorService colorService)
        {
            _mapper = mapper;
            _colorService = colorService;
        }

        public async Task<IActionResult> Index(int? status, int select, int page = 1)
        {
            IQueryable<ColorListVM> colorListVMs = await _colorService.GetAllAsync(status);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            return View(PaginationList<ColorListVM>.Create(colorListVMs, page, select));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColorCreateVM colorCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _colorService.CreateAsync(colorCreateVM);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            return View(_mapper.Map<ColorUpdateVM>(await _colorService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ColorUpdateVM colorUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _colorService.UpdateAsync(id, colorUpdateVM);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, int? status, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _colorService.DeleteAsync(id);

            IQueryable<ColorListVM> colorListVMs = await _colorService.GetAllAsync(status);

            return PartialView("_ColorIndexPartial", PaginationList<ColorListVM>.Create(colorListVMs, page, select));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _colorService.RestoreAsync(id);

            IQueryable<ColorListVM> colorListVMs = await _colorService.GetAllAsync(status);

            return PartialView("_ColorIndexPartial", PaginationList<ColorListVM>.Create(colorListVMs, page, select));
        }
    }
}
