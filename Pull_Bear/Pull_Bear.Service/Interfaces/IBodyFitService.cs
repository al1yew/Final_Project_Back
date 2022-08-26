using Pull_Bear.Service.ViewModels.BodyFitVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IBodyFitService
    {
        IQueryable<BodyFitListVM> GetAllAsync(int? status, int? type);

        Task<BodyFitGetVM> GetById(int? id);

        Task CreateAsync(BodyFitCreateVM bodyFitCreateVM);

        Task UpdateAsync(int? id, BodyFitUpdateVM bodyFitCreateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
