using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMaisImob_WEB.Controllers
{
    [Authorize(Roles = "Administrator, Corretor")]
    public class AccountController : Controller
    {
        private readonly BLL.UserFunctions userFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.RoleFunctions roleFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.UserListFunctions userListFunctions;
        private readonly BLL.MailFunctions mailFunctions;

        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly SignInManager<AMaisImob_DB.Models.User> signInManager;

        public AccountController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager, SignInManager<AMaisImob_DB.Models.User> signInManager, BLL.UserListFunctions userListFunctions, BLL.MailFunctions mailFunctions)
        {
            this.userFunctions = new BLL.UserFunctions(context, userManager);
            this.roleFunctions = new BLL.RoleFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userListFunctions = userListFunctions;
            this.mailFunctions = mailFunctions;
        }

        #region [AllowAnonymous]
        [AllowAnonymous]
        public async Task<IActionResult> Login() => await Task.Run(() => View());

        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> _Login(Models.LoginViewModel model, string returnUrl = null)
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

            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                var userCompany = userCompanyFunctions.GetData().FirstOrDefault(x => x.UserId == user.Id);
                if (userCompany != null)
                {
                    var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
                    var company = companyFunctions.GetDataByID(userCompany.CompanyId);
                    if (company.CompanyTypeId == realEstateId && !company.TermAccepted)
                    {
                        await this.signInManager.SignOutAsync();
                        ViewData["ErroAdherenceTerms"] = "Os termos de adesão da imobiliária ainda não foram aceitos.";
                        return View(model);
                    }
                }
                if (!string.IsNullOrWhiteSpace(returnUrl)) return Redirect(returnUrl);

                if(userFunctions.GetRolesByUserId(user.Id) == "Imobiliária - Vendas")
                    return RedirectToAction("New", "ContractualGuarantee");

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
        public async Task<IActionResult> NoCompany() => await Task.Run(() => View());
        #endregion

        public async Task<IActionResult> Index() => await Task.Run(() => View());

        public async Task<IActionResult> Manage(int? id)
        {
            if (!await ValidateLoggedUser(id))
                return await Task.Run(() => Forbid());

            return await Task.Run(() => View(id));
        }

        [AllowAnonymous]
        public IActionResult RecoveryPassword(int userId)
        {
            var user = userFunctions.GetDataByID(userId);
            if (user == null) return NotFound();

            return View(userFunctions.GetDataViewModel(user));
        }

        private string TextoRecuperacaoSenhaEmail(AMaisImob_DB.Models.User user, string token)
        {
            string text = "Olá <b>" + user.FirstName + " " + user.LastName + "</b>," +
            "<br/><br/>" +
            "Clique no link abaixo para criar uma nova senha:" +
            "<br/>" +
            "<a href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("RecoveryPassword", "Account") + "?userId=" + user.Id + "&token=" + token + "\">Criar nova senha.</a>" +
            "<br/><br/>" +
            "Atenciosamente," +
            "<br/><br/>" +
            "Equipe AMaisImob.";
            return text;
        }

        #region [ViewComponents]
        [AllowAnonymous]
        public IActionResult AccountManageComponent(int? id, bool? fromRealEstateAgency)
        {
            if (id.HasValue && !User.Identity.IsAuthenticated) return Forbid();

            Models.UserViewModel model = new Models.UserViewModel();

            if (id.HasValue)
                model = userFunctions.GetDataViewModel(userFunctions.GetDataByID(id));

            if(fromRealEstateAgency.HasValue) ViewData["FromRealEstateAgency"] = fromRealEstateAgency;

            return ViewComponent(typeof(ViewComponents.Account.AccountManageViewComponent), new { model = model });
        }

        public IActionResult AccountIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Account.AccountIndexViewComponent));
        }
        #endregion

        #region [XHR]
        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(Models.UserViewModel model, int? companyId)
        {
            if (!await ValidateLoggedUser(model.UserId) || !await ValidateLoggedUserCompany(companyId) || model.Role == "Administrator")
                return await Task.Run(() => Forbid());

            var _user = await userManager.GetUserAsync(User);
            model.LastHandler = _user.Id;
            Utils.DBActionType actionType;
            if (model.UserId.HasValue) actionType = Utils.DBActionType.UPDATE;
            else actionType = Utils.DBActionType.CREATE;

            var userId = userFunctions.CreateOrUpdate(model);

            if (userId != 0)
            {
                userFunctions.ClearUserRoles(userId);
                userFunctions.AddUserToRole(userId, model.Role);
                auditLogFunctions.Log("UserViewModel", userId, "UserId", actionType, userFunctions.GetDataViewModel(userFunctions.GetDataByID(userId)), _user.Id);

                if (User.IsInRole("Corretor"))
                {
                    if (model.Role == "Corretor")//copia a corretora do usuário atual para o usuário criado
                    {
                        await userCompanyFunctions.DeleteByUserId(userId);
                        await userCompanyFunctions.CopyCompaniesFromUser((await userManager.GetUserAsync(User)).Id, userId);
                    }
                    if (companyId.HasValue)
                    {
                        await userCompanyFunctions.DeleteByUserId(userId);
                        await companyFunctions.TryClearUserPartner(userId);

                        userCompanyFunctions.Create(new Models.UserCompanyViewModel { CompanyId = companyId.Value, UserId = userId });

                        if (model.Role.ToUpper() == "IMOBILIARIOSOCIO")
                            await companyFunctions.AddUserPartner(companyId.Value, userId);
                    }
                }
                else if (companyId.HasValue)//Usuário é administrador
                {
                    await userCompanyFunctions.DeleteByUserId(userId);
                    await companyFunctions.TryClearUserPartner(userId);

                    userCompanyFunctions.Create(new Models.UserCompanyViewModel { CompanyId = companyId.Value, UserId = userId });

                    if(model.Role.ToUpper() == "IMOBILIARIOSOCIO")
                        await companyFunctions.AddUserPartner(companyId.Value, userId);
                }
            }

            return Json(userId);
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            List<Models.UserListViewModel> d;
            if (User.IsInRole("Corretor"))
            {
                var loggedUserId = (await userManager.GetUserAsync(User)).Id;
                var companyIds = userCompanyFunctions.GetDataByUserId(loggedUserId).Select(x => x.CompanyId);

                if (companyIds.Count() == 0) return await Task.Run(() => Forbid());

                d = this.userListFunctions.GetDataViewModel(await this.userCompanyFunctions.GetUsersByCompanyId(companyIds.First(), true));
            }
            else
            {
                d = this.userListFunctions.GetDataViewModel(this.userListFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null).ToList());
            }
            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("RemoveUser")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            if (!userFunctions.Exists(id)) return Json(null);

            var _user = await userManager.GetUserAsync(User);

            userFunctions.Delete(id);
            await userCompanyFunctions.DeleteByUserId(id);
            await companyFunctions.TryClearUserPartner(id);

            auditLogFunctions.Log("UserViewModel", id, "UserId", Utils.DBActionType.DELETE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(id)), _user.Id, "Exclusão");
            return Json(true);
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

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            await mailFunctions.SendAsync("A+Imob - Criação de nova senha", TextoRecuperacaoSenhaEmail(user, token), mailToSend, null);
            return Json(new { hasError = false });
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

        [AllowAnonymous] //usado em modo anônimo na tela de criação de imobiliária (/Company/New)
        public async Task<IActionResult> CheckEmail(int? userId, string email) => await Task.Run(async () => Json(await userFunctions.CheckEmail(userId, email)));

        #endregion

        private async Task<bool> ValidateLoggedUser(int? userId)
        {
            if (User.IsInRole("Corretor"))
            {
                var loggedUserId = (await userManager.GetUserAsync(User)).Id;
                var companyIds = userCompanyFunctions.GetDataByUserId(loggedUserId).Select(x => x.CompanyId).ToList();

                if (companyIds.Count() == 0) return false;

                if (userId.HasValue && !await userCompanyFunctions.Exits(companyIds.First(), userId.Value))
                    return false;
            }

            return true;
        }
        private async Task<bool> ValidateLoggedUserCompany(int? companyId)
        {
            if (User.IsInRole("Corretor"))
            {
                var loggedUserId = (await userManager.GetUserAsync(User)).Id;
                var companyIds = userCompanyFunctions.GetDataByUserId(loggedUserId).Select(x => x.CompanyId);

                if (companyIds.Count() == 0) return false;

                if (!companyId.HasValue) return false;

                var company = companyFunctions.GetDataByID(companyId);

                if (!companyIds.Contains(company.CompanyId) && !companyIds.Contains(company.ParentCompanyId ?? -1))
                    return false;
            }

            return true;
        }
    }
}