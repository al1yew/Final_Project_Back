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
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
    }
}
