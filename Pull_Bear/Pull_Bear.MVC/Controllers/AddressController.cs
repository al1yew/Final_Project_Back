using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AddressVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            AddressIndexVM addressIndexVM = new AddressIndexVM() { AddressCreateVM = new AddressCreateVM(), Addresses = await _addressService.GetAllAsync() };

            return View(addressIndexVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] AddressCreateVM addressCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return PartialView("_AddressListPartial", await _addressService.GetAllAsync());
            }

            await _addressService.CreateAsync(addressCreateVM);

            return PartialView("_AddressListPartial", await _addressService.GetAllAsync());
        }

        public async Task<IActionResult> DeleteAddress(int? id)
        {
            await _addressService.DeleteAsync(id);

            return PartialView("_AddressListPartial", await _addressService.GetAllAsync());
        }

        public async Task<IActionResult> MakeMain(int? id)
        {
            await _addressService.MakeMain(id);

            return PartialView("_AddressListPartial", await _addressService.GetAllAsync());
        }

    }
}
