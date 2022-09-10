using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.CardVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class CardService : ICardService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CardService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CardListVM>> GetAllAsync()
        {
            AppUser appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            List<CardListVM> cards = _mapper.Map<List<CardListVM>>(await _unitOfWork.CardRepository.GetAllByExAsync(x => x.AppUserId == appUser.Id));

            return cards;
        }

        public async Task<CardGetVM> GetById(int? id)
        {
            AppUser appUser = _userManager.Users.FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            CardGetVM card = _mapper.Map<CardGetVM>(await _unitOfWork.CardRepository.GetAsync(x => x.AppUserId == appUser.Id && x.Id == id));

            return card;
        }

        public async Task CreateAsync(CardCreateVM cardCreateVM)
        {
            if (await _unitOfWork.CardRepository.IsExistAsync(x => x.CardNo == cardCreateVM.CardNo))
                throw new RecordDublicateException($"Card Already Exists!");

            AppUser appUser = _userManager.Users.Include(x => x.Cards).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (appUser.Cards.Count < 3)
            {
                Card newcard = _mapper.Map<Card>(cardCreateVM);

                newcard.AppUserId = appUser.Id;
                newcard.CardHolder = appUser.GenderId == 1 ? "Mrs." + " " + newcard.CardHolder : "Mr." + " " + newcard.CardHolder;

                if (cardCreateVM.IsMain)
                {
                    Card dbCard = await _unitOfWork.CardRepository.GetAsync(x => x.IsMain && x.AppUserId == appUser.Id);

                    if (dbCard != null)
                    {
                        dbCard.IsMain = false;
                    }

                    newcard.IsMain = cardCreateVM.IsMain;
                }

                await _unitOfWork.CardRepository.AddAsync(newcard);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteAsync(int? id)
        {
            Card card = await _unitOfWork.CardRepository.GetAsync(x => x.Id == id);

            if (card == null) throw new NotFoundException("Card cannot be found!");

            AppUser appUser = _userManager.Users.Include(x => x.Cards).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (card.IsMain)
            {
                if (appUser.Cards.Count > 1)
                {
                    appUser.Cards.FirstOrDefault(x => !x.IsMain).IsMain = true;
                }
            }

            _unitOfWork.CardRepository.Remove(card);
            await _unitOfWork.CommitAsync();
        }

        public async Task MakeMain(int? id)
        {
            AppUser appUser = _userManager.Users.Include(x => x.Cards).FirstOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            if (appUser.Cards != null)
            {
                if (appUser.Addresses.FirstOrDefault(x => x.IsMain) != null)
                {
                    appUser.Cards.FirstOrDefault(x => x.IsMain).IsMain = false;
                }
                appUser.Cards.FirstOrDefault(x => x.Id == id).IsMain = true;
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
