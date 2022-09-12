using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class AccountInfoController : Controller
    {
        private readonly IAccountInfoService _accountInfoService;

        public AccountInfoController(IAccountInfoService accountInfoService)
        {
            _accountInfoService = accountInfoService;
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Index()
        {
            return View(await _accountInfoService.GetUser());
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateVM appUserUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Error!";
                return View("Index", appUserUpdateVM);
            }

            foreach (var item in await _accountInfoService.UpdateUser(appUserUpdateVM))
            {
                ModelState.AddModelError("", item);
                return View("Index");
            }

            TempData["success"] = "Success!";

            return RedirectToAction("Index");
        }
    }
}
