using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels;
using Pull_Bear.Service.ViewModels.AccountVMs;
using Pull_Bear.Service.ViewModels.AppUserVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Areas.Manage.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Area("Manage")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, IAppUserService appUserService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public IActionResult Index(int? status, int select, int role, int page = 1)
        {
            IQueryable<AppUserListVM> appUserListVM = _appUserService.GetAllAsync(status, role, User);

            if (select <= 0)
            {
                select = 5;
            }

            ViewBag.Select = select;
            ViewBag.Role = role;
            ViewBag.Status = status;
            ViewBag.Page = page;

            return View(PaginationList<AppUserListVM>.Create(appUserListVM, page, select));
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string id)
        {
            await _appUserService.ResetPassword(id);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            List<string> errors = await _appUserService.ResetPassword(resetPasswordVM, id);

            if (errors.Count > 0 && errors != null)
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item);
                }
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppUserCreateVM appUserCreateVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View();
            }

            List<string> errors = await _appUserService.CreateAsync(appUserCreateVM);

            if (errors.Count > 0 && errors != null)
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item);
                }
                return View();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            return View(_mapper.Map<AppUserUpdateVM>(await _appUserService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateVM appUserUpdateVM, string id)
        {
            if (!ModelState.IsValid) return View();

            List<string> errors = await _appUserService.UpdateAsync(id, appUserUpdateVM);

            if (errors.Count > 0 && errors != null)
            {
                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item);
                }
                return View();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id, int? status, int? role, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Status = status;
            ViewBag.Role = role;
            ViewBag.Page = page;

            await _appUserService.DeleteAsync(id);

            IQueryable<AppUserListVM> appUserListVMs = _appUserService.GetAllAsync(status, role, User);

            return PartialView("_AppUserIndexPartial", PaginationList<AppUserListVM>.Create(appUserListVMs, page, select));
        }

        public async Task<IActionResult> Restore(string id, int? status, int? role, int select, int page)
        {
            ViewBag.Select = select;
            ViewBag.Role = role;
            ViewBag.Status = status;
            ViewBag.Page = page;

            await _appUserService.RestoreAsync(id);

            IQueryable<AppUserListVM> appUserListVMs = _appUserService.GetAllAsync(status, role, User);

            return PartialView("_AppUserIndexPartial", PaginationList<AppUserListVM>.Create(appUserListVMs, page, select));
        }

    }
}
