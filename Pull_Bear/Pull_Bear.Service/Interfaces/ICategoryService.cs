using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryListVM> GetAllAsync();
        Task<CategoryGetVM> GetById(int id);
        Task CreateAsync(CategoryCreateVM categoryCreateVM);
        Task UpdateAsync(int id, CategoryUpdateVM categoryUpdateVM);
        Task DeleteAsync(int id);
        Task RestoreAsync(int id);

    }
}
