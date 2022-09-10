using Pull_Bear.Service.ViewModels.CardVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface ICardService
    {
        Task<List<CardListVM>> GetAllAsync();

        Task<CardGetVM> GetById(int? id);

        Task CreateAsync(CardCreateVM cardCreateVM);

        Task MakeMain(int? id);

        Task DeleteAsync(int? id);

    }
}
