using Pull_Bear.Service.ViewModels.ProductColorSizeVMs;
using Pull_Bear.Service.ViewModels.ProductImageVMs;
using Pull_Bear.Service.ViewModels.ProductToTagVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IProductService
    {
        Task<IQueryable<ProductListVM>> GetAllAsync(int? status, int? type);

        Task<ProductGetVM> GetById(int? id);

        Task CreateAsync(ProductCreateVM productCreateVM);

        Task UpdateAsync(int? id, ProductUpdateVM productUpdateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);

        Task<List<ProductImageGetVM>> DeleteImage(int? id);
        Task<List<ProductToTagGetVM>> DeleteTag(int? id);
        Task<List<ProductColorSizeGetVM>> DeleteColorSize(int? id);
    }
}
