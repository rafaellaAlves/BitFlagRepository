using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;

namespace GLAS2Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly SignInManager<DAL.Identity.User> _signInManager;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;
        public AccountController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, SignInManager<DAL.Identity.User> signInManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userManager = userManager;
            this._signInManager = signInManager;
            this.mailFunctions = mailFunctions;
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        #region [Login]
        [AllowAnonymous]
        public IActionResult Login(string error)
        {
            ViewData["Error"] = error;

            return View();
        }

        public IActionResult TimeOut()
        {
            return RedirectToAction("Login", new { error = "Ocorreu um erro e você foi direcionado para tela de login. <br/>Conecte-se novamente para continuar." });
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
            
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                if (userFunctions.UserIsDeleted(user.Id))
                {
                    ViewData["ErroPassword"] = "E-mail ou senha incorretos.";
                }
            }
            if (ViewData["ErroEmail"] != null || ViewData["ErroPassword"] != null)
            {
                return View(model);
            }
            
            var result = await this._signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            
            if (result.Succeeded)
            {
                var claimIdentity = new ClaimsIdentity(new Claim[] { new Claim("CultureInfo", user.CultureInfo) });

                if (!string.IsNullOrWhiteSpace(returnUrl)) return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }
            else if (result.RequiresTwoFactor)
            {
                // RequiresTwoFactor
            }
            else if (result.IsLockedOut)
            {
                // IsLockedOut
            }
            else
            {
                ViewData["ErroPassword"] = "E-mail ou senha incorretos.";
            }

            return View(model);
        }
        #endregion

        #region [LogOut]
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await this._signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        [Authorize]
        public async Task<IActionResult> Info()
        {
            var user = await userManager.GetUserAsync(User);
            var model = this.userFunctions.GetDataViewModel(this.userFunctions.GetDataByID(user.Id));
            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ActionName("Info")]
        public async Task<IActionResult> _Info([FromForm]DTO.Account.NewPasswordViewModel model)
        {
            var user = await this.userManager.GetUserAsync(User);
            bool passwordOk = await this.userManager.CheckPasswordAsync(user, model.CurrentPassword);
            var _model = this.userFunctions.GetDataViewModel(this.userFunctions.GetDataByID(user.Id));

            if (!passwordOk)
            {
                ViewData["ErrorMessage"] = "Senha atual incorreta.";
                return View(_model);
            }
            else
            {
                var result = await this.userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);


                //string htmlTable = mailUtils.UserTable(user.Id);
                //htmlTable += "<table style='width:60%;' align='center' class='table-bottom-rounded'><tbody><tr><td style='text-align:center;'>Senha para acesso: " + model.NewPassword + "</td></tr></tbody></table>";

                //await mailFunctions.SendAsync("ALTERAÇÃO DE SENHA: " + user.FullName + " - " + _model.Email, htmlTable, null, null, user.Id);

                return RedirectToAction("Info", new { saved = true });
            }
        }
        
        [HttpPost]
        [ActionName("SendRecoveryMail")]
        public async Task<IActionResult> SendRecoveryMail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return Json(-1);

            var validUser = userFunctions.GetData().Where(x => x.Email == mail && x.IsDeleted == false);
            if(validUser.Count() == 0)
                return Json(0);

            var user = await userManager.FindByIdAsync(validUser.First().Id.ToString());

            var mailToSend = new List<string>();
            mailToSend.Add(mail);

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            await mailFunctions.SendAsync("Recuperação de senha", "Clique no link abaixo para criar uma nova senha:<br/><a href=\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("RecoveryPassword", "Account") + "?userId=" + user.Id + "&token=" + token + "\">Recuperar senha</a>" , mailToSend, null, user.Id, false);
            return Json(1);
        }

        [AllowAnonymous]
        public IActionResult RecoveryPassword(int userId)
        {
            var user = userFunctions.GetDataByID(userId);
                if (user == null) return NotFound();

            return View(userFunctions.GetDataViewModel(user));
        }

        [AllowAnonymous]
        [ActionName("NewPassword")]
        public async Task<IActionResult> NewPassword(int userId, string newPassword, string TokenPassword)
        {
            var userModel = await userManager.FindByIdAsync(userId.ToString());
            TokenPassword = TokenPassword.Replace(" ", "+");
            var d = await this.userManager.ResetPasswordAsync(userModel, TokenPassword, newPassword);
            if (d == IdentityResult.Success)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
 }