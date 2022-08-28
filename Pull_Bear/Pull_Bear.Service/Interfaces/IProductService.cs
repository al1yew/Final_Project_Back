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
        IQueryable<ProductListVM> GetAllAsync(int? status, int? type);

        ProductGetVM GetById(int? id);

        Task CreateAsync(ProductCreateVM productCreateVM);

        Task UpdateAsync(int? id, ProductUpdateVM productUpdateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
