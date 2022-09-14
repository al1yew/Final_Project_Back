using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductReviewVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using Pull_Bear.Service.ViewModels.ShopVMs;
using Pull_Bear.Service.ViewModels.SortVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IShopService
    {
        Task<ShopVM> GetDataAsync(int genderId, int parentcategoryid);
        Task<IQueryable<ProductListVM>> CreateSort(SortVM sortVM);
        Task<ProductDetailVM> GetProduct(int? id);
        Task<ProductDetailVM> AddReview(WriteReviewVM writeReviewVM, int? id);
        Task<List<ProductListVM>> Search(string search);
        Task<ProductGetVM> GetReviewCount(int? id);
        Task<int> Like(int? id);
    }
}
