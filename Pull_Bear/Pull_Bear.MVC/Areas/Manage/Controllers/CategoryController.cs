using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IActionResult Index(int? status, int? type, int select, int page = 1)
        {
            IQueryable<CategoryListVM> categoryListVMs = _categoryService.GetAllAsync(status, type);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;

            return View(PaginationList<CategoryListVM>.Create(categoryListVMs, page, select));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MainCategories = _categoryService.GetMainAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            ViewBag.MainCategories = _categoryService.GetMainAsync();

            if (!ModelState.IsValid) return View();

            await _categoryService.CreateAsync(categoryCreateVM);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.MainCategories = _categoryService.GetMainAsync();

            return View(_mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, CategoryUpdateVM categoryUpdateVM)
        {
            ViewBag.MainCategories = _categoryService.GetMainAsync();

            if (!ModelState.IsValid) return View();

            await _categoryService.UpdateAsync(id, categoryUpdateVM);

            return RedirectToAction("Index");
        }


    }
}
