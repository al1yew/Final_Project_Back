using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(IMapper mapper, ITagService tagService)
        {
            _mapper = mapper;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int? status, int select, int page = 1)
        {
            IQueryable<TagListVM> tagListVMs = await _tagService.GetAllAsync(status);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            return View(PaginationList<TagListVM>.Create(tagListVMs, page, select));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TagCreateVM tagCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _tagService.CreateAsync(tagCreateVM);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            return View(_mapper.Map<TagUpdateVM>(await _tagService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, TagUpdateVM tagUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _tagService.UpdateAsync(id, tagUpdateVM);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, int? status, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _tagService.DeleteAsync(id);

            IQueryable<TagListVM> tagListVMs = await _tagService.GetAllAsync(status);

            return PartialView("_TagIndexPartial", PaginationList<TagListVM>.Create(tagListVMs, page, select));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _tagService.RestoreAsync(id);

            IQueryable<TagListVM> tagListVMs = await _tagService.GetAllAsync(status);

            return PartialView("_TagIndexPartial", PaginationList<TagListVM>.Create(tagListVMs, page, select));
        }
    }
}
