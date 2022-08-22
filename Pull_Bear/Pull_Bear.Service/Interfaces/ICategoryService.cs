using Pull_Bear.Service.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ICategoryService
    {
        Task PostAsync(CategoryCreateVM categoryCreateVM);
        Task<List<CategoryListVM>> GetAllAsync();
        Task<CategoryGetVM> GetById(int id);
        Task UpdateAsync(int id, CategoryUpdateVM categoryUpdateVM);
        Task DeleteAsync(int id);
    }
}
