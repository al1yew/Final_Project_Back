using Pull_Bear.Service.ViewModels.ColorVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IColorService
    {
        Task<IQueryable<ColorListVM>> GetAllAsync(int? status);

        Task<IQueryable<ColorListVM>> GetAllAsync();

        Task<ColorGetVM> GetById(int? id);

        Task CreateAsync(ColorCreateVM colorCreateVM);

        Task UpdateAsync(int? id, ColorUpdateVM colorUpdateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
