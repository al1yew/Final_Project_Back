using Pull_Bear.Service.ViewModels.CategoryVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ICategoryService
    {
        IQueryable<CategoryListVM> GetAllAsync(int? status, int? type);

        List<CategoryListVM> GetMainMaleAsync();

        List<CategoryListVM> GetMainAsync();

        List<CategoryListVM> GetMainFemaleAsync();

        Task<CategoryGetVM> GetById(int? id);

        Task CreateAsync(CategoryCreateVM categoryCreateVM);

        Task UpdateAsync(int? id, CategoryUpdateVM categoryUpdateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
