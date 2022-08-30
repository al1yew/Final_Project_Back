using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.ColorVMs;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.SizeVMs;
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

        public async Task<IActionResult> Index(int? status, int? type, int select, int page = 1)
        {
            IQueryable<ProductListVM> productListVMs = await _productService.GetAllAsync(status, type);

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

        public async Task<IActionResult> Detail(int? id)
        {
            ProductGetVM productGetVM = await _productService.GetById(id);

            return View(productGetVM);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = await _tagService.GetAllAsync();
            ViewBag.Colors = await _colorService.GetAllAsync();
            ViewBag.Sizes = await _sizeService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = _tagService.GetAllAsync().Result.ToList();
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _productService.CreateAsync(productCreateVM);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = _tagService.GetAllAsync().Result.ToList();
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            ProductUpdateVM productUpdateVM = _mapper.Map<ProductUpdateVM>(await _productService.GetById(id));

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = _tagService.GetAllAsync().Result.ToList();
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            await _productService.UpdateAsync(id, productUpdateVM);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id, int? status, int? type, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            await _productService.DeleteAsync(id);

            IQueryable<ProductListVM> productListVMs = await _productService.GetAllAsync(status, type);

            return PartialView("_ProductIndexPartial", PaginationList<ProductListVM>.Create(productListVMs, page, select));
        }

        public async Task<IActionResult> Restore(int? id, int? status, int? type, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Type = type;
            ViewBag.Page = page;

            await _productService.RestoreAsync(id);

            IQueryable<ProductListVM> productListVMs = await _productService.GetAllAsync(status, type);

            return PartialView("_ProductIndexPartial", PaginationList<ProductListVM>.Create(productListVMs, page, select));
        }

        public IActionResult GetInputs()
        {
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            return PartialView("_ProductColorSizePartial");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImage(int? id)
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = _tagService.GetAllAsync().Result.ToList();
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            return PartialView("_ProductImagePartial", await _productService.DeleteImage(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTag(int? id)
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = _tagService.GetAllAsync().Result.ToList();
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            return PartialView("_ProductTagPartial", await _productService.DeleteTag(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteColorSize(int? id)
        {
            ViewBag.MaleChildCategories = await _categoryService.GetChildrenMaleAsync();
            ViewBag.FemaleChildCategories = await _categoryService.GetChildrenFemaleAsync();
            ViewBag.MaleBodyFits = await _bodyFitService.GetMaleBodyFitsAsync();
            ViewBag.FemaleBodyFits = await _bodyFitService.GetFemaleBodyFitsAsync();
            ViewBag.Tags = _tagService.GetAllAsync().Result.ToList();
            ViewBag.Colors = _colorService.GetAllAsync().Result.ToList();
            ViewBag.Sizes = _sizeService.GetAllAsync().Result.ToList();

            return PartialView("_ProductColorSizePartial", await _productService.DeleteColorSize(id));
        }
    }
}
