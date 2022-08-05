﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{ 
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        //GET account/register
        [AllowAnonymous]
        public IActionResult Register() => View();

        //POST account/register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    { 
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(user);
        }


        //GET account/register
        [AllowAnonymous]
        public IActionResult Login(string retunrUrl)
        {
            Login login = new Login
            {
                ReturnUrl = retunrUrl,
            };

            return View(login);
        }
    }

}
