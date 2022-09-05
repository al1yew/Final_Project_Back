using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.SortVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public async Task<IActionResult> Index(/*[FromBody] SortVM sortVM*/)
        {
            #region bilo
            // IQueryable<Product> products = _context.Products
            //.Include(p => p.Category)
            //.Include(p => p.Brand)
            //.Include(p => p.ProductToColors).ThenInclude(p => p.Color)
            //.Include(p => p.ProductToSizes).ThenInclude(p => p.Size);

            // if (categoryId != null)
            // {
            //     products = products
            //         .Where(p => p.CategoryId == categoryId);
            // }

            // if (brandId != null)
            // {
            //     products = products
            //         .Where(p => p.BrandId == brandId);
            // }

            // if (searchValue != null)
            // {
            //     products = products
            //     .Where(p => p.Name.ToLower().Contains(searchValue.ToLower()) ||
            //     p.Brand.Name.ToLower().Contains(searchValue.ToLower()) ||
            //     p.Category.Name.ToLower().Contains(searchValue.ToLower()) ||
            //     p.Description.ToLower().Contains(searchValue.ToLower()) ||
            //     p.FirstText.ToLower().Contains(searchValue.ToLower()) ||
            //     p.SecondText.ToLower().Contains(searchValue.ToLower()));
            // }

            // if (colorId != null)
            // {
            //     products = _context.ProductToColors
            //        .Include(x => x.Product).Where(e => e.ColorId == colorId).Select(e => e.Product);
            // }

            // if (sizeId != null)
            // {
            //     products = _context.ProductToSizes
            //         .Include(x => x.Product).Where(e => e.SizeId == sizeId).Select(e => e.Product);
            // }

            // if (sortby != null && sortby > 0)
            // {
            //     if (sortby == 1)
            //     {
            //         products = products.OrderBy(c => c.Name);
            //     }
            //     else if (sortby == 2)
            //     {
            //         products = products.OrderByDescending(c => c.Name);
            //     }
            //     else if (sortby == 3)
            //     {
            //         products = products.OrderBy(c => c.Price);
            //     }
            //     else if (sortby == 4)
            //     {
            //         products = products.OrderByDescending(c => c.Price);
            //     }
            // }

            // if (sortbycount <= 0)
            // {
            //     sortbycount = 5;
            // }

            // ProductVM productVM = new ProductVM
            // {
            //     Products = PaginationList<Product>.Create(products, page, sortbycount),
            //     Settings = await _context.Settings.ToDictionaryAsync(x => x.Key, x => x.Value),
            //     Sizes = await _context.Sizes.Include(c => c.ProductToSizes).ThenInclude(pc => pc.Product).ToListAsync(),
            //     Colors = await _context.Colors.Include(c => c.ProductToColors).ThenInclude(pc => pc.Product).ToListAsync(),
            //     Categories = await _context.Categories.Include(c => c.Products).ToListAsync(),
            //     Brands = await _context.Brands.Include(b => b.Products).ToListAsync()
            // };

            // ViewBag.CategoriesForProductsPage = categoryId;
            // ViewBag.BrandsForProductsPage = brandId;
            // ViewBag.HeaderSearchForProductsPage = searchValue;
            // ViewBag.ColorForProductsPage = colorId;
            // ViewBag.SizeForProductsPage = sizeId;
            // ViewBag.Sortby = sortby;
            // ViewBag.Select = sortbycount;

            //asp-route-categoryId="@ViewBag.CategoriesForProductsPage" asp-route-brandId="@ViewBag.BrandsForProductsPage" asp-route-searchValue="@ViewBag.HeaderSearchForProductsPage" asp-route-colorId="@ViewBag.ColorForProductsPage" asp-route-sizeId="@ViewBag.SizeForProductsPage" asp-route-sortby="@ViewBag.Sortby" asp-route-sortbycount="@ViewBag.Select"

            #endregion

            return View(await _shopService.GetDataAsync());
        }

        ////[Authorize(Roles = "Member")]
        //public async Task<IActionResult> ProductDetail(int? id)
        //{
        //    if (id == null) return BadRequest();

        //    Product product = await _context.Products
        //        .Include(p => p.ProductToColors).ThenInclude(p => p.Color)
        //        .Include(p => p.ProductToSizes).ThenInclude(p => p.Size)
        //        .Include(p => p.ProductImages)
        //        .Include(p => p.Brand)
        //        .Include(p => p.Category)
        //        .Include(p => p.ProductInformation)
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    if (product == null) return NotFound();

        //    ProductReviewVM productReviewVM = new ProductReviewVM
        //    {
        //        Name = appUser.Name,
        //        Email = appUser.Email,
        //        AppUserId = appUser.Id
        //    };

        //    ProductDetailVM productDetailVM = new ProductDetailVM
        //    {
        //        Product = product,
        //        Products = await _context.Products.ToListAsync(),
        //        ProductReviewVM = productReviewVM,
        //        ProductReviews = await _context.ProductReviews.Where(pr => pr.ProductId == id).ToListAsync()
        //    };

        //    ViewBag.ProductId = id;

        //    return View(productDetailVM);
        //}

        //public async Task<IActionResult> Search(string search)
        //{
        //    List<Product> products = await _context.Products
        //        .Where(p => p.Name.ToLower().Contains(search.ToLower()) ||
        //        p.Brand.Name.ToLower().Contains(search.ToLower()) ||
        //        p.Category.Name.ToLower().Contains(search.ToLower()) ||
        //        p.Description.ToLower().Contains(search.ToLower()) ||
        //        p.FirstText.ToLower().Contains(search.ToLower()) ||
        //        p.SecondText.ToLower().Contains(search.ToLower()))
        //        .ToListAsync();

        //    return PartialView("_SearchPartial", products);
        //}

        //[HttpPost]
        ////[Authorize(Roles = "Member")]
        //public async Task<IActionResult> AddProductReview(ProductReviewVM productReviewVM, int id)
        //{
        //    if (!ModelState.IsValid) return Redirect($"http://localhost:15866/Product/Detail/{id}");

        //    if (id == null && id <= 0) return NotFound();

        //    if (await _context.ProductReviews.Where(x => x.ProductId == productReviewVM.ProductId).AnyAsync(pr => pr.Email.Trim().ToLower() == productReviewVM.Email.Trim().ToLower()))
        //    {
        //        ModelState.AddModelError("", "You have already placed your review!");
        //        return Redirect($"http://localhost:15866/Product/Detail/{id}");
        //    }

        //    ProductReview productReview = new ProductReview
        //    {
        //        CreatedAt = DateTime.UtcNow.AddHours(4),
        //        Email = productReviewVM.Email,
        //        Name = productReviewVM.Name,
        //        Rating = productReviewVM.Rating,
        //        ReviewText = productReviewVM.ReviewText,
        //        ProductId = id,
        //        AppUserId = productReviewVM.AppUserId,
        //    };

        //    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        //    product.ReviewCount++;

        //    //await _context.Products.AddAsync(product);
        //    await _context.ProductReviews.AddAsync(productReview);
        //    await _context.SaveChangesAsync();

        //    TempData["success"] = "Thanks for review!";

        //    return Redirect($"http://localhost:15866/Product/Detail/{id}");
        //}
    }
}
