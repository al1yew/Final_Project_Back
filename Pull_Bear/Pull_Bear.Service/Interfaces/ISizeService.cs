using Pull_Bear.Service.ViewModels.SizeVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ISizeService
    {
        IQueryable<SizeListVM> GetAllAsync(int? status);

        Task<SizeGetVM> GetById(int? id);

        Task CreateAsync(SizeCreateVM sizeCreateVM);

        Task UpdateAsync(int? id, SizeUpdateVM sizeUpdateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
