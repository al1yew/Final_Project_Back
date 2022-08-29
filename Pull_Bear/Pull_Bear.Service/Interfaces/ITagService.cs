using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ITagService
    {
        Task<IQueryable<TagListVM>> GetAllAsync(int? status);

        Task<IQueryable<TagListVM>> GetAllAsync();

        Task<TagGetVM> GetById(int? id);

        Task CreateAsync(TagCreateVM tagCreateVM);

        Task UpdateAsync(int? id, TagUpdateVM tagUpdateVM);

        Task DeleteAsync(int? id);

        Task RestoreAsync(int? id);
    }
}
