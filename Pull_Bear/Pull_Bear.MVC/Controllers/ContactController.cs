using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.ContactVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactCreateVM contactCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View("Index");
            }

            await _contactService.Contact(contactCreateVM);

            return RedirectToAction("Index", "Home");
        }
    }
}
