using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.AccountVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == loginVM.Email.Trim().ToUpperInvariant() && u.IsAdmin);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(loginVM);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", $"Your account is blocked. Wait {((appUser.LockoutEnd.Value - DateTime.UtcNow).TotalMinutes).ToString("0")} minutes to login again!");
                return View(loginVM);
            }

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong!");
                return View(loginVM);
            }

            return RedirectToAction("Index", "Home", new { area = "Manage" });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        #region Created Roles

        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });

        //    return Content("Salammmmm");
        //}

        #endregion

        #region Created Super Admin

        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Admin",
        //        SurName = "Admin",
        //        UserName = "Admin",
        //        Email = "admin@admin"
        //    };

        //    appUser.IsAdmin = true;

        //    await _userManager.CreateAsync(appUser, "Admin@123");

        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

        //    return Content("Super admin est ");
        //}
        #endregion

        #region Created user

        //public async Task<IActionResult> Createuser()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Vasif",
        //        SurName = "Aliyev",
        //        UserName = "Vasya",
        //        Email = "vasif@vasif"
        //    };

        //    appUser.IsAdmin = false;

        //    await _userManager.CreateAsync(appUser, "Vasif123");

        //    await _userManager.AddToRoleAsync(appUser, "Member");

        //    return Content("ya yest ");

        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Mamed",
        //        SurName = "Aliyev",
        //        UserName = "Mamed",
        //        Email = "mamed@mamed"
        //    };

        //    appUser.IsAdmin = false;

        //    await _userManager.CreateAsync(appUser, "Mamed123");

        //    await _userManager.AddToRoleAsync(appUser, "Member");

        //    return Content("ya yest mamed");
        //}
        #endregion

    }
}
