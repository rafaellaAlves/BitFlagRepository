using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AspNetIdentityDbContext.User> signInManager;
        private readonly UserManager<AspNetIdentityDbContext.User> userManager;

        public AccountController(SignInManager<AspNetIdentityDbContext.User> signInManager, UserManager<AspNetIdentityDbContext.User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        #region [Login]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            //var result = await userManager.CreateAsync(new AspNetIdentityDbContext.User() { Email = "hperon@gmail.com", UserName = "hperon@gmail.com" }, "Foco#web");
            return await Task.Run(() => View(new LoginViewModel()));
        }
        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> _Login(LoginViewModel model, string returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ViewData["ErrorMessage"] = "Por favor, preencha o e-mail.";
                return await Task.Run(() => View(model));
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                ViewData["ErrorMessage"] = "Por favor, preencha a senha.";
                return await Task.Run(() => View(model));
            }

            var signInResult = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
                return !string.IsNullOrWhiteSpace(returnUrl) ? await Task.Run(() => RedirectToAction(returnUrl)) :  await Task.Run(() => RedirectToAction("Index", "Home"));

            ViewData["ErrorMessage"] = "E-mail ou senha incorretos.";
            return await Task.Run(() => View(model));
        }
        #endregion

        #region [Logout]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return await Task.Run(() => RedirectToAction("Login"));
        }
        #endregion
    }
}