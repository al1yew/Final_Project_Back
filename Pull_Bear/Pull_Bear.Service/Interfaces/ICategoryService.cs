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
        Task<IQueryable<CategoryListVM>> GetAllAsync(int? status, int? type);

        Task<List<CategoryListVM>> GetMainMaleAsync();
        Task<List<CategoryListVM>> GetMainFemaleAsync();
        Task<List<CategoryListVM>> GetChildrenMaleAsync();
        Task<List<CategoryListVM>> GetChildrenFemaleAsync();
        Task<List<CategoryListVM>> GetMainAsync();
        Task<List<CategoryListVM>> GetChildrenAsync();
        Task<CategoryGetVM> GetById(int? id);
        Task CreateAsync(CategoryCreateVM categoryCreateVM);

        Task UpdateAsync(int? id, CategoryUpdateVM categoryUpdateVM);
        Task DeleteAsync(int? id);
        Task RestoreAsync(int? id);
    }
}
