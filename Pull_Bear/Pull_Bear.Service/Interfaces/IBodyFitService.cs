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
        Task<IQueryable<BodyFitListVM>> GetAllAsync(int? status, int? type);
        Task<IQueryable<BodyFitListVM>> GetAllAsync();
        Task<List<BodyFitListVM>> GetMaleBodyFitsAsync();
        Task<List<BodyFitListVM>> GetFemaleBodyFitsAsync();

        Task<BodyFitGetVM> GetById(int? id);

        Task CreateAsync(BodyFitCreateVM bodyFitCreateVM);

        Task UpdateAsync(int? id, BodyFitUpdateVM bodyFitCreateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
