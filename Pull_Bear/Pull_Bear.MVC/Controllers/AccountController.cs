using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Extensions.EmailSender;
using Pull_Bear.Service.ViewModels.AccountVMs;
using Pull_Bear.Service.ViewModels.BasketVMs;
using Pull_Bear.Service.ViewModels.WishlistVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Pull_Bear.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountController> _logger;

        public AccountController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, IUnitOfWork unitOfWork, IMapper mapper, ILogger<AccountController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = await _userManager.Users.Include(u => u.Baskets).Include(x => x.Wishlists).FirstOrDefaultAsync(u => (u.NormalizedEmail == loginVM.Email.Trim().ToUpperInvariant() || u.NormalizedUserName == loginVM.Email.Trim().ToUpperInvariant()) && !u.IsAdmin && !u.IsDeleted);

            if (appUser == null || appUser.IsAdmin || !await _userManager.CheckPasswordAsync(appUser, loginVM.Password))
            {
                ModelState.AddModelError("", "Email or Password is wrong!");

                return View();
            }

            await _signInManager.SignInAsync(appUser, loginVM.RememberMe);

            #region Basket

            string basketCookie = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(basketCookie))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);

                foreach (BasketVM basketVM in basketVMs)
                {
                    if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                    {
                        Basket existedBasket = appUser.Baskets.FirstOrDefault(b => b.ProductId == basketVM.ProductId && b.ColorId == basketVM.ColorId && b.SizeId == basketVM.SizeId);

                        if (existedBasket == null)
                        {
                            appUser.Baskets.Add(_mapper.Map<Basket>(basketVM));
                        }
                        else
                        {
                            existedBasket.Count = basketVM.Count;
                        }
                    }
                    else
                    {
                        appUser.Baskets.Add(_mapper.Map<Basket>(basketVM));
                    }
                }

                HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));

                await _unitOfWork.CommitAsync();
            }
            else
            {
                if (appUser.Baskets != null && appUser.Baskets.Count() > 0)
                {
                    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(_mapper.Map<List<BasketVM>>(appUser.Baskets)));
                }
            }

            #endregion

            #region Wishlist

            string wishlistCookie = HttpContext.Request.Cookies["wishlist"];

            if (!string.IsNullOrWhiteSpace(wishlistCookie))
            {
                List<WishlistVM> wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlistCookie);

                foreach (WishlistVM wishlistVM in wishlistVMs)
                {
                    if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
                    {
                        Wishlist existedwishlist = appUser.Wishlists.FirstOrDefault(b => b.ProductId == wishlistVM.ProductId);

                        if (existedwishlist == null)
                        {
                            appUser.Wishlists.Add(_mapper.Map<Wishlist>(wishlistVM));
                        }
                    }
                    else
                    {
                        appUser.Wishlists.Add(_mapper.Map<Wishlist>(wishlistVM));
                    }
                }

                HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlistVMs));

                await _unitOfWork.CommitAsync();
            }
            else
            {
                if (appUser.Wishlists != null && appUser.Wishlists.Count() > 0)
                {
                    HttpContext.Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(_mapper.Map<List<WishlistVM>>(appUser.Wishlists)));
                }
            }

            #endregion

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser appUser = _mapper.Map<AppUser>(registerVM);

            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            result = await _userManager.AddToRoleAsync(appUser, "Member");

            await _signInManager.SignInAsync(appUser, true);

            #region Basket

            string basketCookie = HttpContext.Request.Cookies["basket"];

            if (!string.IsNullOrWhiteSpace(basketCookie))
            {
                List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basketCookie);

                if (appUser.Baskets == null)
                {
                    appUser.Baskets = _mapper.Map<List<Basket>>(basketVMs);
                }
                else
                {
                    appUser.Baskets.AddRange(_mapper.Map<List<Basket>>(basketVMs));
                }

                basketCookie = JsonConvert.SerializeObject(basketVMs);

                HttpContext.Response.Cookies.Append("basket", basketCookie);

                await _unitOfWork.CommitAsync();
            }

            #endregion

            #region Wishlist

            string wishlistCookie = HttpContext.Request.Cookies["wishlist"];

            if (!string.IsNullOrWhiteSpace(wishlistCookie))
            {
                List<WishlistVM> wishlistVMs = JsonConvert.DeserializeObject<List<WishlistVM>>(wishlistCookie);

                if (appUser.Wishlists == null)
                {
                    appUser.Wishlists = _mapper.Map<List<Wishlist>>(wishlistVMs);
                }
                else
                {
                    appUser.Wishlists.AddRange(_mapper.Map<List<Wishlist>>(wishlistVMs));
                }

                wishlistCookie = JsonConvert.SerializeObject(wishlistVMs);

                HttpContext.Response.Cookies.Append("wishlist", wishlistCookie);

                await _unitOfWork.CommitAsync();
            }

            #endregion

            await ConfirmEmail(registerVM.Email);

            return View("ConfirmEmail");
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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Email is not correct!");
                return View(forgotPasswordVM);
            }

            AppUser appUser = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);

            if (appUser == null)
            {
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            string link = Url.Action("ResetPassword", "Account", new { email = forgotPasswordVM.Email, token = token }, Request.Scheme);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pullandbear.az@gmail.com", "yrjizuufmdacaslu");
            client.EnableSsl = true;
            string text = "Please click the button to reset your password!";
            var message = await EmailSender.SendMail("pullandbear.az@gmail.com", appUser.Email, link, "Reset Password", "Reset", text);
            message.IsBodyHtml = true;
            client.Send(message);
            message.Dispose();

            return View("EmailHasBeenSent");
        }


        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            if (token == null && email == null)
            {
                ModelState.AddModelError("", "Invalid password or email!");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Provided data is incorrect!");
                return View(resetPasswordVM);
            }

            AppUser appUser = await _userManager.FindByEmailAsync(resetPasswordVM.Email);

            if (appUser == null)
            {
                return View("ResetPassword");
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(resetPasswordVM);
            }

            return RedirectToAction("ResetPasswordConfirmed");
        }

        public IActionResult ResetPasswordConfirmed()
        {
            return View();
        }
    }
}
