using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBodyFitService _bodyFitService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, IBodyFitService bodyFitService, IColorService colorService, ISizeService sizeService, ITagService tagService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _bodyFitService = bodyFitService;
            _colorService = colorService;
            _sizeService = sizeService;
            _tagService = tagService;
        }

        public IActionResult Index(int? status, int? type, int select, int page = 1)
        {
            IQueryable<ProductListVM> productListVMs = _productService.GetAllAsync(status, type);

            if (select <= 0)
            {
                select = 10;
            }

            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            return View(PaginationList<ProductListVM>.Create(productListVMs, page, select));
        }

        public IActionResult Detail(int? id)
        {
            ProductGetVM productGetVM = _productService.GetById(id);

            return View(productGetVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ChildCategories = _categoryService.GetChildrenAsync();
            ViewBag.BodyFits = _bodyFitService.GetAllAsync();
            ViewBag.Tags = _tagService.GetAllAsync();
            ViewBag.Colors = _colorService.GetAllAsync();
            ViewBag.Sizes = _sizeService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            ViewBag.ChildCategories = _categoryService.GetChildrenAsync();
            ViewBag.BodyFits = _bodyFitService.GetAllAsync();
            ViewBag.Tags = _tagService.GetAllAsync();


            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _productService.CreateAsync(productCreateVM);

            return View();
        }

        public IActionResult GetInputs()
        {
            ViewBag.Colors = _colorService.GetAllAsync();
            ViewBag.Sizes = _sizeService.GetAllAsync();

            return PartialView("_ProductColorSizePatial");
        }
    }
}
