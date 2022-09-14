using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Extensions.EmailSender;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class AccountInfoController : Controller
    {
        private readonly IAccountInfoService _accountInfoService;
        private readonly UserManager<AppUser> _userManager;

        public AccountInfoController(IAccountInfoService accountInfoService, UserManager<AppUser> userManager)
        {
            _accountInfoService = accountInfoService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            return View(await _accountInfoService.GetUser());
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateVM appUserUpdateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return StatusCode(406);
            }

            List<string> errors = await _accountInfoService.UpdateUser(appUserUpdateVM);

            if (errors.Count > 0)
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item);
                }

                return StatusCode(406);
            }

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (appUser.NormalizedEmail != appUserUpdateVM.Email.Trim().ToUpperInvariant())
            {
                await ConfirmEmail(appUserUpdateVM.Email);

                return View("ConfirmEmail");
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            string link = Url.Action("Confirm", "Account", new { email = appUser.Email, token = token }, Request.Scheme);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pullandbear.az@gmail.com", "yrjizuufmdacaslu");
            client.EnableSsl = true;
            string text = "Please click the button to confirm your email!";
            var message = await EmailSender.SendMail("pullandbear.az@gmail.com", appUser.Email, link, "Confirm Email", "Confirm", text);
            message.IsBodyHtml = true;
            client.Send(message);
            message.Dispose();

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Confirm(string email)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(email);

            appUser.EmailConfirmed = true;

            await _userManager.UpdateAsync(appUser);

            return RedirectToAction("Index", "home");
        }
    }
}
