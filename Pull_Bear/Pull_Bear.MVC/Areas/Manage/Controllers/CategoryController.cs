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
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
        public async Task<IActionResult> Create()
        {
            return View();
        }


    }
}
