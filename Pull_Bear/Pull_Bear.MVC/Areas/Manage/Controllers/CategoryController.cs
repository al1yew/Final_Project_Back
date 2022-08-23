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
            IQueryable<CategoryListVM> categoryListVMs = _categoryService.GetAllAsync().AsQueryable();

            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    categoryListVMs = categoryListVMs.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    categoryListVMs = categoryListVMs.Where(b => !b.IsDeleted);
                }
            }

            if (type != null && type > 0)
            {
                if (type == 1)
                {
                    categoryListVMs = categoryListVMs.Where(c => !c.IsMain);
                }
                else if (type == 2)
                {
                    categoryListVMs = categoryListVMs.Where(c => c.IsMain);
                }
            }

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;

            ViewBag.Status = status;

            ViewBag.Type = type;

            return View(PaginationList<CategoryListVM>.Create(categoryListVMs, page, select));
        }


    }
}
