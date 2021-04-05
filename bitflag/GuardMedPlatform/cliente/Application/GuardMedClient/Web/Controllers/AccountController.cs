using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendasDbContext.Models;
using Web.DTO.Account;
using Web.Services.IUGU;
using Web.Services.Pagamento;
using Web.Services.SeguradoProfissional;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SeguradoProfissionalService seguradoProfissionalService;
        private readonly SeguradoProfissionalHistoricoService seguradoProfissionalHistoricoService;
        private readonly PagamentoTipoService pagamentoTipoService;
        private readonly IUGUService IUGUService;
        private readonly InsuranceAccessPermissionService insuranceAccessPermissionService;

        public AccountController(SeguradoProfissionalService seguradoProfissionalService, IUGUService IUGUService, PagamentoTipoService pagamentoTipoService, SeguradoProfissionalHistoricoService seguradoProfissionalHistoricoService, InsuranceAccessPermissionService insuranceAccessPermissionService)
        {
            this.seguradoProfissionalService = seguradoProfissionalService;
            this.IUGUService = IUGUService;
            this.pagamentoTipoService = pagamentoTipoService;
            this.seguradoProfissionalHistoricoService = seguradoProfissionalHistoricoService;
            this.insuranceAccessPermissionService = insuranceAccessPermissionService;
        }

        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync();

            return await Task.Run(() => View(new LoginViewModel()));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return await Task.Run(() => View("Login", new LoginViewModel()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> RecoveryPassword(string token)
        {
            var user = (await seguradoProfissionalService.GetDataAsNoTrackingAsync(x => x.TokenSenha == new Guid(token))).FirstOrDefault();
            if (user == null) return NotFound();

            return View(user);
        }

        #region [XHR]
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

            SeguradoProfissional user = null;
            try
            {
                var users = await seguradoProfissionalService.GetDataAsNoTrackingAsync(x => x.Email == model.Email && x.Senha == model.Password && x.CertificadoGerado == true);

                user = users.Where(x => !seguradoProfissionalService.dbSet.Any(c => c.RenovadoPor == x.SeguradoProfissionalId)).LastOrDefault(); //Apenas seguros que não foram renovados
            }
            catch (Exception exception)
            {
                exception.ToString();
            }

            if (user == null)
            {
                ViewData["ErrorMessage"] = "E-mail ou senha incorretos.";
                return await Task.Run(() => View(model));
            }
            else
            {
                bool suspended = false;
                if (user.VezesPagamento > 1)
                {
                    var subscription = (await IUGUService.GetSubscription(user.SeguradoProfissionalId)).Items;
                    if (subscription.Count > 0) //Possuí uma assinatura
                        suspended = subscription.Last().Suspended;
                }
                else
                {
                    var invoice = await IUGUService.GetInvoice(user.SeguradoProfissionalId);
                    //var costumer = await IUGUService.GetCostumer(user.SeguradoProfissionalId);

                    var historicos = await seguradoProfissionalHistoricoService.GetDataAsNoTrackingAsync(x => x.SeguradoProfissionalId == user.SeguradoProfissionalId);

                    if (invoice == null || invoice.Status?.ToUpper() != "PAID")
                        suspended = true;
                    else
                        if (historicos.Count > 0)
                        suspended = !(historicos.First().DataAtualizacao.Value < DateTime.Now.AddYears(1));
                    else
                        suspended = !(user.DataAtualizacao.Value < DateTime.Now.AddYears(1));

                }

                if (user.ByPassPayment) suspended = false;
                if (suspended && !await insuranceAccessPermissionService.InsuranceHasAccess(user.SeguradoProfissionalId))
                {
                    ViewData["ErrorMessage"] = "Não foi possível completar seu login.<br/>Aguardando confirmação de pagamento.";
                    return await Task.Run(() => View(model));
                }
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.SeguradoProfissionalId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nome));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = model.RememberMe,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);

            return await Task.Run(() => RedirectToAction("Index", "Home")); //!string.IsNullOrWhiteSpace(returnUrl) ? await Task.Run(() => RedirectToAction(returnUrl)) : 
        }

        [AllowAnonymous]
        [HttpPost]
        [ActionName("SendRecoveryMail")]
        public async Task<IActionResult> SendRecoveryMail(string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return Json(new { hasError = true, message = "Digite um e-mail!" });

            var segurado = (await seguradoProfissionalService.GetDataAsNoTrackingAsync(x => x.Email == mail && x.CertificadoGerado.Value && !x.IsDeleted)).LastOrDefault();
            if (segurado == null)
                return Json(new { hasError = true, message = "E-mail inexistente!" });

            var token = await seguradoProfissionalService.GeneratePasswordResetTokenAsync(segurado.SeguradoProfissionalId);

            await Services.Mail.MailFunctions.SendAsync("Alteração de senha", TextoRecuperacaoSenhaEmail(segurado, token.ToString()), new List<string> { mail }, null);
            return Json(new { hasError = false });
        }

        [AllowAnonymous]
        public async Task<IActionResult> NewPassword(int userId, string newPassword, string TokenPassword)
        {
            var d = await seguradoProfissionalService.TrocarSenha(userId, newPassword, TokenPassword);

            var segurado = seguradoProfissionalService.GetDataById(userId);

            while (segurado.RenovadoPor.HasValue)
            {
                await seguradoProfissionalService.TrocarSenha(segurado.RenovadoPor.Value, newPassword);

                segurado = seguradoProfissionalService.GetDataById(segurado.RenovadoPor.Value);
            }

            return Json(d);
        }
        #endregion

        private string TextoRecuperacaoSenhaEmail(SeguradoProfissional segurado, string token)
        {
            string text = "Olá <b>" + segurado.Nome + "</b>," +
            "<br/><br/>" +
            "Clique no link abaixo para criar uma nova senha:" +
            "<br/>" +
            "<a href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("RecoveryPassword", "Account") + "?token=" + token + "\">Criar nova senha.</a>" +
            "<br/><br/>" +
            "Atenciosamente," +
            "<br/><br/>" +
            "Equipe GuardMed.";
            return text;
        }
    }
}