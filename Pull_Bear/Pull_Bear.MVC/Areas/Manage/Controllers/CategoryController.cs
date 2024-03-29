﻿using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Enums;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
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

        public async Task<IActionResult> Index(int? status, int? type, int select, int page = 1)
        {
            IQueryable<CategoryListVM> categoryListVMs = await _categoryService.GetAllAsync(status, type);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            return View(PaginationList<CategoryListVM>.Create(categoryListVMs, page, select));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MainMaleCategories = await _categoryService.GetMainMaleAsync();
            ViewBag.MainFemaleCategories = await _categoryService.GetMainFemaleAsync();

            return View(new CategoryCreateVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            ViewBag.MainMaleCategories = await _categoryService.GetMainMaleAsync();
            ViewBag.MainFemaleCategories = await _categoryService.GetMainFemaleAsync();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _categoryService.CreateAsync(categoryCreateVM);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.MainMaleCategories = await _categoryService.GetMainMaleAsync();
            ViewBag.MainFemaleCategories = await _categoryService.GetMainFemaleAsync();

            return View(_mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, CategoryUpdateVM categoryUpdateVM)
        {
            ViewBag.MainMaleCategories = await _categoryService.GetMainMaleAsync();
            ViewBag.MainFemaleCategories = await _categoryService.GetMainFemaleAsync();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _categoryService.UpdateAsync(id, categoryUpdateVM);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, int? status, int? type, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            await _categoryService.DeleteAsync(id);

            IQueryable<CategoryListVM> categoryListVMs = await _categoryService.GetAllAsync(status, type);

            return PartialView("_CategoryIndexPartial", PaginationList<CategoryListVM>.Create(categoryListVMs, page, select));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int? type, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            await _categoryService.RestoreAsync(id);

            IQueryable<CategoryListVM> categoryListVMs = await _categoryService.GetAllAsync(status, type);

            return PartialView("_CategoryIndexPartial", PaginationList<CategoryListVM>.Create(categoryListVMs, page, select));
        }
    }
}
