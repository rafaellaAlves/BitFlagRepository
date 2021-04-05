using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        private readonly SignInManager<TerraNostraIdentityDbContext.User> signInManager;
        private readonly FUNCTIONS.User.UserFunctions userFunctions;

        public AccountController(UserManager<TerraNostraIdentityDbContext.User> userManager, SignInManager<TerraNostraIdentityDbContext.User> signInManager, FUNCTIONS.User.UserFunctions userFunctions)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userFunctions = userFunctions;
        }

        #region [SHARED]
        private string TextoRecuperacaoSenhaEmail(TerraNostraIdentityDbContext.User user, string token)
        {
            string text = "Olá <strong>" + user.FirstName + " " + user.LastName + "</strong>," +
            "<br/>" +
            "Clique no link abaixo para criar uma nova senha:" +
            "<br/>" +
            "<a href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("RecoveryPassword", "Account") + "?reference=" + user.PasswordRecoveryReference + "&token=" + token + "\">Criar nova senha.</a>";
            return text;
        }
        #endregion

        #region [PAGES]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new DTO.Account.LoginViewModel());
        }

        [AllowAnonymous]
        public IActionResult RecoveryPassword(string reference)
        {
            var user = userFunctions.GetDataByReference(reference);
            if (user == null) return NotFound();

            return View(userFunctions.GetDataViewModel(user));
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View(new DTO.Account.LoginViewModel());
        }
        #endregion

        #region [XHR]
        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> _Login(DTO.Account.LoginViewModel model, string returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                ViewData["ErroEmail"] = "Preencha o e-mail.";
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                ViewData["ErroPassword"] = "Preencha a senha.";
                return View(model);
            }

            

            var loggedUser = await userManager.FindByEmailAsync(model.Email);
            if (loggedUser != null && !loggedUser.IsActive)
            {
                ViewData["InactiveUser"] = "Seu usuário está inativo!";
                return View(model);
            }

            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrWhiteSpace(returnUrl)) return RedirectToAction(returnUrl);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewData["ErroPassword"] = "E-mail ou senha incorretos.";
            }

           

            return View(model);

           

            



        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await this.signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("SendRecoveryMail")]
        public async Task<IActionResult> SendRecoveryMail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return Json(new { hasError = true, message = "Digite um e-mail!" });

            var validUser = userFunctions.GetData().FirstOrDefault(x => x.Email == mail && x.IsDeleted == false);
            if (validUser == null)
                return Json(new { hasError = true, message = "E-mail inexistente!" });

            var user = await userManager.FindByIdAsync(validUser.Id.ToString());

            var mailToSend = new List<string>
            {
                mail
            };

            user.PasswordRecoveryReference = userFunctions.GeneratePasswordRecoveryReference(user.Id);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            await FUNCTIONS.Mail.MailFunctions.SendAsync("Recuperção de senha", TextoRecuperacaoSenhaEmail(user, token), "", mailToSend, null);
            return Json(new { hasError = false });
        }

        [AllowAnonymous]
        [ActionName("NewPassword")]
        public async Task<IActionResult> NewPassword(int userId, string newPassword, string TokenPassword)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            TokenPassword = TokenPassword.Replace(" ", "+");
            var d = await this.userManager.ResetPasswordAsync(user, TokenPassword, newPassword);

            userFunctions.ClearReference(user.Id);

            if (d == IdentityResult.Success)
            {
                return Json(true);
            }
            return Json(false);
        }

        #endregion
    }
}