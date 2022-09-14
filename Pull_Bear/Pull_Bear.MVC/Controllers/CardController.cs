using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.CardVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardService _cardService;
         
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Index()
        {
            CardIndexVM cardIndexVM = new CardIndexVM() { CardCreateVM = new CardCreateVM(), Cards = await _cardService.GetAllAsync() };

            return View(cardIndexVM);
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> GetCards()
        {
            return PartialView("_CheckoutCurrentUserCardPartial", await _cardService.GetAllAsync());
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardCreateVM cardCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                //return PartialView("_CardListPartial", await _cardService.GetAllAsync());
                return StatusCode(406);
            }

            await _cardService.CreateAsync(cardCreateVM);
            return PartialView("_CardListPartial", await _cardService.GetAllAsync());
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> DeleteCard(int? id)
        {
            await _cardService.DeleteAsync(id);

            return PartialView("_CardListPartial", await _cardService.GetAllAsync());
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> MakeMain(int? id)
        {
            await _cardService.MakeMain(id);

            return PartialView("_CardListPartial", await _cardService.GetAllAsync());
        }
    }
}
