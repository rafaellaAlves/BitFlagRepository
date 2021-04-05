using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using DTO.Account;
using DTO.Client;
using DTO.Shared;
using DTO.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Services.Account;
using Services.Client;
using Services.Email;
using Web.Controllers.Shared;
using Web.Helpers;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly SignInManager<AspNetIdentityDbContext.User> signInManager;
        private readonly Services.Account.UserService userService;
        private readonly ClientUserServices clientUserServices;
        private readonly ClientActivityServices clientActivityServices;
        private readonly ClientServices clientServices;
        private readonly ClientContactTypeServices clientContactTypeServices;
        private readonly ClientContactServices clientContactServices;
        private readonly EmailServices emailServices;
        private readonly IConfiguration configuration;
        ViewEngineHelper viewEngineHelper;

        public AccountController(SignInManager<AspNetIdentityDbContext.User> signInManager, UserManager<AspNetIdentityDbContext.User> userManager, Services.Account.UserService userService, ClientUserServices clientUserServices, ClientActivityServices clientActivityServices, ClientServices clientServices, ClientContactTypeServices clientContactTypeServices, ClientContactServices clientContactServices, EmailServices emailServices, IConfiguration configuration, ViewEngineHelper viewEngineHelper) : base(userManager)
        {
            this.signInManager = signInManager;
            this.userService = userService;
            this.clientUserServices = clientUserServices;
            this.clientActivityServices = clientActivityServices;
            this.clientServices = clientServices;
            this.clientContactTypeServices = clientContactTypeServices;
            this.clientContactServices = clientContactServices;
            this.emailServices = emailServices;
            this.configuration = configuration;
            this.viewEngineHelper = viewEngineHelper;
        }

        #region [Login]
        [AllowAnonymous]
        public async Task<IActionResult> AlternativeLogin() => await Task.Run(() => View(new LoginViewModel()));
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email) => await Task.Run(() => View(new LoginViewModel() { Email = email }));
        [AllowAnonymous]
        [HttpPost]
        [ActionName("AlternativeLogin")]
        public async Task<IActionResult> _AlternativeLogin(LoginViewModel model, string returnUrl = null) => await Login(model, returnUrl);

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> _Login(LoginViewModel model, string returnUrl = null) => await Login(model, returnUrl);

        private async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
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

            if (!(await userService.IsActive(model.Email)) || await userService.IsDeleted(model.Email))
            {
                ViewData["ErrorMessage"] = "E-mail ou senha incorretos.";
                return await Task.Run(() => View(model));
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ViewData["ErrorMessage"] = "E-mail ou senha incorretos.";
                return await Task.Run(() => View(model));
            }

            var role = await userService.GetRoleByUserId(user.Id);

            if (role?.NormalizedName == "CLIENTE")
            {
                var client = await clientUserServices.GetClientByUser(user.Id);

                if (client == null)
                {
                    ViewData["ErrorMessage"] = "Este usuário ainda não possuí vinculo com um gerador, entre em contato com a equipe técnica para realizarem o vinculo.";
                    return await Task.Run(() => View(model));
                }

                HttpContext.Session.SetInt32(Constants.UserClientSessionKey, client.ClientId);
            }

            if (user.TemporaryPassword)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                return await Task.Run(() => Redirect(Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme)));
            }

            var signInResult = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            await this.signInManager.SignInAsync(user, false);
            if (signInResult.Succeeded)
            {
                if (role?.NormalizedName == "CLIENTADMINISTRATOR")
                    return await Task.Run(() => RedirectToAction("ChooseClient", "Account"));

                return !string.IsNullOrWhiteSpace(returnUrl) ? await Task.Run(() => RedirectToAction(returnUrl)) : await Task.Run(() => RedirectToAction("Index", "Home"));
            }

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

        #region [New]
        [AllowAnonymous]
        public async Task<IActionResult> New() => await Task.Run(() => View());

        [HttpPost]
        [ActionName("New")]
        [AllowAnonymous]
        public async Task<IActionResult> _New(DTO.Account.SingUpViewModel model, [FromServices] ICompositeViewEngine viewEngine)
        {
            if (await userService.EmailExists(model.Email))
            {
                ViewData["ErrorMessage"] = "O e-mail informado já está em uso.";

                return await Task.Run(() => View());
            }

            var userModel = new DTO.User.UserViewModel
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsActive = false,
                RoleName = "Cliente",
                Password = StringExtensions.GetReference(),
                CreationToken = StringExtensions.GetReference(),
                TemporaryPassword = true
            };

            userModel.UserId = await userService.CreateUser(userModel);

            var clientModel = new DTO.Client.ClientViewModel
            {
                FullName = $"{model.FirstName} {model.LastName}",
                NickName = $"{model.FirstName} {model.LastName}",
                CompanyName = model.CompanyName,
                CentralEmail = model.Email,
                Phone = model.Phone,
                CNPJ = model.CNPJ,
                CPF = model.CPF,
                ClientActivityId = (await clientActivityServices.GetDataByExternalCode("OUTROS"))?.ClientActivityId ?? (await clientActivityServices.GetFirstDataAsync()).ClientActivityId,
                ActivityDescription = "Outros",
                Solicitation = true,
                City = model.City,
                State = model.State
            };

            clientModel.ClientId = await clientServices.CreateAsync(clientModel);

            var clientContactModel = new DTO.Client.ClientContactViewModel
            {
                ClientId = clientModel.ClientId.Value,
                ClientContactTypeId = (await clientContactTypeServices.GetFirstDataAsync()).ClientContactTypeId,
                CPF = model.CPF,
                Email = model.Email,
                MainContact = true,
                MobilePhone = model.MobilePhone,
                Name = $"{model.FirstName} {model.LastName}",
                Phone = model.Phone.IfNullChange(model.MobilePhone),
                Role = "Outros"
            };

            await clientContactServices.CreateAsync(clientContactModel);

            await clientUserServices.CreateAsync(new ApplicationDbContext.Models.ClientUser
            {
                ClientId = clientModel.ClientId.Value,
                UserId = userModel.UserId.Value
            });

            if (configuration.GetValue<bool>("Emails:SendNewClientAccountEmail"))
            {
                var emailModel = new NewClientEmailViewModel(clientModel, userModel);
                var html_ClientEmail = await RenderPartialViewToString("NewClient_ClientEmail", emailModel, viewEngine);
                var html_AdministratorEmail = await RenderPartialViewToString("NewClient_AdministratorEmail", emailModel, viewEngine);

                LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg) { ContentId = "Logo" };

                emailServices.Send($"Destine Já - Olá, {emailModel.User.FirstName}, seja bem-vindo(a) à Destine Já.", html_ClientEmail, new List<string>() { model.Email }, null, null, null, new List<LinkedResource> { pic }, false); //envio para cliente
                emailServices.Send($"Destine Já - Novo cadastro realizado, {emailModel.Client.Name}!", html_AdministratorEmail, new List<string>() { "desenvolvimento@destineja.com.br" }, null, null, null, new List<LinkedResource> { pic }, false); //envio para administrador
            }

            return await Task.Run(() => RedirectToAction("Login", new { success = true, email = model.Email }));
        }

        [AllowAnonymous]
        public async Task<IActionResult> EmailConfirm(int userId, string token)
        {
            var result = await userService.ConfirmCreationToken(userId, token);

            if (!result)
                return await Task.Run(() => RedirectToAction("Login", new { creationTokenValidation = false }));

            var user = await userManager.FindByIdAsync(userId.ToString());
            return await Task.Run(() => RedirectToAction("Login", new { creationTokenValidation = true, email = user.Email }));
        }
        #endregion

        #region [PesswordRecovery]
        [AllowAnonymous]
        public async Task<IActionResult> PasswordRecovery() => await Task.Run(() => View());
        [HttpPost]
        [ActionName("PasswordRecovery")]
        [AllowAnonymous]
        public async Task<IActionResult> _PasswordRecovery(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    TempData["ErrorMessage"] = "E-mail não encontrado.";
                    return await Task.Run(() => RedirectToAction(nameof(PasswordRecovery), new { notfound = true }));
                }

                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var callback = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

                var model = new PasswordRecoveryEmailViewModel(new DTO.User.UserViewModel { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email }, callback);
                var html = await viewEngineHelper.RenderPartialViewToString(ControllerContext, ViewData, TempData, "PasswordRecoveryEmail", model);

                emailServices.Send("Recuperação de Senha", html, new List<string> { email });

                return await Task.Run(() => RedirectToAction(nameof(PasswordRecovery), new { emailsent = true }));
            }
            catch (Exception exception)
            {
                return await Task.Run(() => RedirectToAction(nameof(PasswordRecovery), new { error = true }));
            }
        }
        #endregion

        #region [ResetPassword]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
                return await Task.Run(() => Forbid());

            return await Task.Run(() => View(new DTO.Account.ResetPasswordViewModel(token, email)));
        }

        [HttpPost]
        [ActionName("ResetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> _ResetPassword(DTO.Account.ResetPasswordViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) RedirectToAction(nameof(ResetPassword));

            var resetPasswordResult = await userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!resetPasswordResult.Succeeded)
            {
                foreach (var error in resetPasswordResult.Errors)
                    ModelState.TryAddModelError(error.Code, error.Description);

                return await Task.Run(() => RedirectToAction(nameof(ResetPassword), new { token = model.Token, email = model.Email, error = true }));
            }
            else
            {
                await userService.ClearTemporaryPassword(user.Id);
            }

            return await Task.Run(() => RedirectToAction(nameof(Login), new { passwordchanged = true }));
        }
        #endregion

        #region [ChooseClient]
        [Authorize(Roles = "ClientAdministrator")]
        public async Task<IActionResult> ChooseClient() => await Task.Run(() => View());

        [HttpPost]
        [Authorize(Roles = "ClientAdministrator")]
        public async Task<IActionResult> ChooseClient(int clientId)
        {
            HttpContext.Session.SetInt32(Constants.UserClientSessionKey, clientId);

            return await Task.Run(() => RedirectToAction("Index", "Home"));
        }
        #endregion
    }
}