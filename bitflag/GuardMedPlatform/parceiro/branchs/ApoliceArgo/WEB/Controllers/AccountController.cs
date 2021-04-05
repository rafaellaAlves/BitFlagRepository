using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WEB.Controllers
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
        private readonly BLL.UserMedicGroupFunctions userMedicGroupFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private readonly SignInManager<DB.Models.AspNetUser> signInManager;
        private readonly DB.Models.Insurance_HomologContext context;
        private readonly IConfiguration iConfiguration;

        public AccountController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager, SignInManager<DB.Models.AspNetUser> signInManager, BLL.UserMedicGroupFunctions userMedicGroupFunctions, IConfiguration iConfiguration)
        {
            this.userFunctions = new BLL.UserFunctions(context, userManager);
            this.roleFunctions = new BLL.RoleFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
            this.userMedicGroupFunctions = userMedicGroupFunctions;
            this.iConfiguration = iConfiguration;
        }

        #region [AllowAnonymous]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

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
                var user = userFunctions.GetDataViewModel(await userManager.FindByNameAsync(model.Email));
                if (user.Role == "CORRETOR" || user.Role == "IMOBILIARIAOPERACIONAL" || user.Role == "IMOBILIARIOADMINISTRATIVO")
                {
                    var userCompany = userCompanyFunctions.GetData().SingleOrDefault(x => x.UserId == user.UserId);

                    if (userCompany == null)
                    {
                        await this.signInManager.SignOutAsync();
                        ViewData["ErroAdherenceTerms"] = $"Este usuário não está vinuclado a nenhuma {iConfiguration.GetValue<string>("CorretoraDisplayName")}/{iConfiguration.GetValue<string>("PartnerDisplayName")}.";
                        return View(model);
                    }

                    var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
                    var company = companyFunctions.GetDataByID(userCompany.CompanyId);
                    if (company.CompanyTypeId == realEstateId && !company.TermAccepted)
                    {
                        await this.signInManager.SignOutAsync();
                        ViewData["ErroAdherenceTerms"] = "Os termos de adesão de " + Configuration.InsuranceConfiguration.PartnerDisplayName + " ainda não foram aceitos.";
                        return View(model);
                    }
                }

                if (user.Role == "GRUPOMEDICO")
                {
                    var medicGroupId = await userMedicGroupFunctions.GetMedicGroupIdByUserId(user.UserId.Value);

                    if (!medicGroupId.HasValue)
                    {
                        await this.signInManager.SignOutAsync();
                        ViewData["ErroAdherenceTerms"] = "Este usuário não possui vinculo com nenhum grupo médico.";
                        return View(model);
                    }
                }


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
        public IActionResult NoCompany()
        {
            return View();
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(int? id)
        {
            return View(id);
        }

        [AllowAnonymous]
        public IActionResult RecoveryPassword(int userId)
        {
            var user = userFunctions.GetDataByID(userId);
            if (user == null) return NotFound();

            return View(userFunctions.GetDataViewModel(user));
        }

        private string TextoRecuperacaoSenhaEmail(DB.Models.AspNetUser user, string token)
        {
            string text = "Olá <b>" + user.FirstName + " " + user.LastName + "</b>," +
            "<br/><br/>" +
            "Clique no link abaixo para criar uma nova senha:" +
            "<br/>" +
            "<a href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("RecoveryPassword", "Account") + "?userId=" + user.Id + "&token=" + token + "\">Criar nova senha.</a>" +
            "<br/><br/>" +
            "Atenciosamente," +
            "<br/><br/>" +
            "Equipe" + @WEB.Configuration.InsuranceConfiguration.ClientDisplayName + ".";
            return text;
        }

        #region [ViewComponents]
        public IActionResult AccountManageComponent(int? id)
        {
            Models.UserViewModel model = new Models.UserViewModel();

            if (id.HasValue)
                model = userFunctions.GetDataViewModel(userFunctions.GetDataByID(id));

            var userId = userManager.GetUserId(User);

            if (User.IsInRole("Corretor"))
            {
                ViewData["Roles"] = roleFunctions.GetRoleByLevel(Convert.ToInt32(userId)).ToList();
            }



            if (User.IsInRole("Administrator"))
            {
                ViewData["Roles"] = roleFunctions.GetData().ToList();
            }

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateAgencyId).ToList();
            if (User.IsInRole("Corretor"))
            {
                ViewData["RealEstateAgency"] = companyFunctions.GetData();
            }



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
        public async Task<IActionResult> _Manage(Models.UserViewModel model, int companyId, int partnerId, int? medicGroupId)
        {
            try
            {
                if (model.Password?.Length < 6)
                    return Json(new { hasError = true, message = "A senha de conter ao menos 6 caracteres.", fieldError = "_AccountManagePassword" });

                if (userFunctions.ExistEmail(model.Email, model.UserId))
                    return Json(new { hasError = true, message = "Este e-mail já esta sendo utilizado.", fieldError = "_AccountManageEmail" });

                var _user = await userManager.GetUserAsync(User);

                var roleId = this.context.AspNetUserRoles.FirstOrDefault(x => x.UserId == _user.Id);
                var userRole = this.context.Role.FirstOrDefault(x => x.Id == roleId.RoleId);

                model.LastHandler = _user.Id;
                Utils.DBActionType actionType;
                if (model.UserId.HasValue) actionType = Utils.DBActionType.UPDATE;
                else actionType = Utils.DBActionType.CREATE;

                var userId = userFunctions.CreateOrUpdate(model);

                var modelRow = roleFunctions.GetData(x => x.NormalizedName == model.Role).FirstOrDefault();

                if (userRole.Nivel > modelRow.Nivel)
                    return Forbid();

                //FAZER VERIFICACOES PARA NAO BURLAR A CRIACAO DE OUTROS ESCRITORIOS DESSA PLATAFORMA

                if (User.IsInRole("Corretor") && partnerId != 0)
                {
                    var userCompany = userCompanyFunctions.GetDataByUserId(_user.Id).FirstOrDefault();
                    var escritorio = companyFunctions.GetDataByID(partnerId);

                    if (userCompany.CompanyId != escritorio.ParentCompanyId)
                        return Forbid();
                }


                if (partnerId != 0)
                    companyId = partnerId;

                if (userId != 0)
                {
                    userFunctions.ClearUserRoles(userId);
                    userFunctions.AddUserToRole(userId, model.Role);

                    userMedicGroupFunctions.DeleteByUserId(userId);

                    if (model.Role == "CORRETOR" || model.Role == "IMOBILIARIAOPERACIONAL" || model.Role == "IMOBILIARIOADMINISTRATIVO")
                        userCompanyFunctions.AttachedToCompany(companyId, userId);

                    if (model.Role == "GRUPOMEDICO" && medicGroupId.HasValue)
                        userMedicGroupFunctions.TryCreate(new DB.Models.UserMedicGroup { UserId = userId, MedicGroupId = medicGroupId.Value });

                    auditLogFunctions.Log("UserViewModel", userId, "UserId", actionType, userFunctions.GetDataViewModel(userFunctions.GetDataByID(userId)), _user.Id);
                }

                return Json(new { hasError = userId == 0, message = userId == 0 ? "Houve um erro ao salvar o usuário." : "Usuário salvo com sucesso." });
            }
            catch (Exception exception)
            {
                return Json(new { hasError = true, message = "Houve um erro ao salvar o usuário." });
            }
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            var d = new List<Models.UserViewModel>();

            if (User.IsInRole("Corretor"))
            {
                var userId = userManager.GetUserId(User);

                var userCompany = userCompanyFunctions.GetDataByUserId(Convert.ToInt32(userId)).FirstOrDefault();


                if (userCompany != null)
                {
                    var escritorios = companyFunctions.GetData(x => x.ParentCompanyId == userCompany.CompanyId);

                    var userCompanies = userCompanyFunctions.GetUsersByCompanyId(escritorios.Select(x => x.CompanyId).ToList());

                    if (userCompanies.Count() > 0)
                    {
                        d = this.userFunctions.GetDataViewModel(this.userFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0 AND UserId IN(" + string.Join(", ", userCompanies.Select(x => x.UserId)) + ")", whereParameters: null).ToList());
                    }
                }
            }
            else if (User.IsInRole("Administrator"))
            {
                d = this.userFunctions.GetDataViewModel(this.userFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null).ToList());
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

            if (!User.IsInRole("Administrator"))
            {
                var roleId = this.context.AspNetUserRoles.FirstOrDefault(x => x.UserId == _user.Id);
                var userRole = this.context.Role.FirstOrDefault(x => x.Id == roleId.RoleId);
                var deletingUserRole = this.context.AspNetUserRoles.FirstOrDefault(x => x.UserId == id);
                var deletingUser = this.context.Role.FirstOrDefault(x => x.Id == deletingUserRole.RoleId);
                if (userRole.Nivel >= deletingUser.Nivel)
                {
                    return Forbid();
                }

                if (User.IsInRole("Corretor"))
                {
                    var userCompany = userCompanyFunctions.GetDataByUserId(_user.Id).FirstOrDefault();
                    var deletingCompanyId = userCompanyFunctions.GetDataByUserId(id).FirstOrDefault();
                    var deletingUserCompany = companyFunctions.GetDataByID(deletingCompanyId.CompanyId);

                    if (userCompany.CompanyId != deletingUserCompany.ParentCompanyId)
                    {
                        return Forbid();
                    }
                }
            }
            userFunctions.Delete(id);
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

            var user = await userManager.FindByIdAsync(validUser.UserId.ToString());

            var mailToSend = new List<string>
            {
                mail
            };

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            await BLL.MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Criação de nova senha", TextoRecuperacaoSenhaEmail(user, token), mailToSend, null);
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
        #endregion
    }
}