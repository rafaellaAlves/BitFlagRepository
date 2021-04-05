using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLAS2Web.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    //[Authorize(Policy = "UserManagesAnyCompany")]
    [Authorize]
    public class UserManagementController : Shared.BaseController
    {

        private readonly DAL.GLAS2Context context;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.User.UserViewFunctions userViewFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Company.CompanyUserFunctions companyUserFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        public UserManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this.context = context;
            this.userManager = userManager;
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.userFunctions = new BLL.User.UserFunctions(this.context, userManager);
            this.userViewFunctions = new BLL.User.UserViewFunctions(this.context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.companyUserFunctions = new BLL.Company.CompanyUserFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.mailFunctions = mailFunctions;
        }

        [Authorize(Policy = "UserManagesAnyCompany")]
        private async Task<bool> CanManageUser(int userId)
        {
            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
                return true;

            var user = await this.userManager.GetUserAsync(User);
            if (User.IsInRole(BLL.User.ProfileNames.Biotera))
            {
                var companiesId = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.BioteraConsultor });
                var usersId = this.companyUserRoleFunctions.UsersIdInCompaniesByRole(companiesId, new List<string> { BLL.User.ProfileNames.BioteraConsultor, BLL.User.ProfileNames.BioteraAuditor, BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteOperador, BLL.User.ProfileNames.ClienteSupervisor });

                return usersId.Any(x => x.Equals(userId));
            }
            else if (User.IsInRole(BLL.User.ProfileNames.Cliente))
            {
                var companiesId = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.ClienteAdministrador });
                var usersId = this.companyUserRoleFunctions.UsersIdInCompaniesByRole(companiesId, new List<string> { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteOperador, BLL.User.ProfileNames.ClienteSupervisor });

                return usersId.Any(x => x.Equals(userId));
            }

            return false;
        }

        [Authorize(Policy = "UserManagesAnyCompany")]
        public IActionResult Index()
        {
            return View();
        }

        private async Task FillViewDataCompanies()
        {
            var _user = await userManager.GetUserAsync(User);

            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
                ViewData["Companies"] = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false));
            else if (User.IsInRole(BLL.User.ProfileNames.Biotera))
            {
                var companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(_user.Id, new List<string> { BLL.User.ProfileNames.BioteraConsultor });
                ViewData["Companies"] = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).Where(x => companyIds.Any(y => y.Equals(x.CompanyId))));
            }
            else if (User.IsInRole(BLL.User.ProfileNames.Cliente))
            {
                var companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(_user.Id, new List<string> { BLL.User.ProfileNames.ClienteAdministrador });
                ViewData["Companies"] = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).Where(x => companyIds.Any(y => y.Equals(x.CompanyId))));
            }
        }

        [Authorize(Policy = "UserManagesAnyCompany")]
        public async Task<IActionResult> Manage(int? id)
        {
            if (id.HasValue)
                if (!(await CanManageUser(id.Value)))
                    return Forbid();

            await FillViewDataCompanies();

            if (!id.HasValue)
                return View(new DTO.User.UserModel());

            if (!userFunctions.Exists(id))
                return NotFound();

            var user = this.userFunctions.GetDataByID(id);
            if (user.IsDeleted)
                return NotFound();

            return View(this.userFunctions.GetDataViewModel(user));
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Policy = "UserManagesAnyCompany")]
        public async Task<IActionResult> _Manage([FromForm] DTO.User.UserModel model)
        {
            #region [SECURITY]
            if (model.UserId.HasValue)
                if (!(await CanManageUser(model.UserId.Value)))
                    return Forbid();

            if (User.IsInRole(BLL.User.ProfileNames.Biotera) && (model.MainRole.ToUpper().Equals(BLL.User.ProfileNames.Administrator.ToUpper()) || model.MainRole.ToUpper().Equals(BLL.User.ProfileNames.Master.ToUpper())))
                return Forbid();

            if (User.IsInRole(BLL.User.ProfileNames.Cliente) && (model.MainRole.ToUpper().Equals(BLL.User.ProfileNames.Administrator.ToUpper()) || model.MainRole.ToUpper().Equals(BLL.User.ProfileNames.Master.ToUpper()) || model.MainRole.ToUpper().Equals(BLL.User.ProfileNames.Biotera.ToUpper())))
                return Forbid();
            #endregion

            if (!model.UserId.HasValue) model.CreatedBy = (await userManager.GetUserAsync(User)).Id; //Atribui quem está criando o usuário.

            int userId = -1;
            try
            {
                userId = userFunctions.CreateOrUpdate(model);
            }
            catch (Exception exception)
            {
                await FillViewDataCompanies();
                ViewData["IdentityErrorCodes"] = exception.InnerException.Message.Split(';');
                return View(model);
            }

            // MainRole
            this.companyUserRoleFunctions.ClearUserRoles(userId);
            this.companyUserRoleFunctions.AddUserToRole(userId, model.MainRole);

            if (!model.UserId.HasValue)
            {
                // MainRole X CompanyRole
                if (!User.IsInRole(BLL.User.ProfileNames.Cliente) && ((model.CompanyRole ?? "").ToUpper().Equals(BLL.User.ProfileNames.BioteraAuditor) || (model.CompanyRole ?? "").ToUpper().Equals(BLL.User.ProfileNames.BioteraConsultor)))
                    return Forbid();

                // User can manage company?
                var user = await this.userManager.GetUserAsync(User);
                List<int> companyIds = new List<int>();
                if (User.IsInRole(BLL.User.ProfileNames.Biotera))
                    companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string>() { BLL.User.ProfileNames.BioteraConsultor });
                else if (User.IsInRole(BLL.User.ProfileNames.Cliente))
                    companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador });

                if (model.AddToCompanyId != null)
                {
                    foreach (var item in model.AddToCompanyId)
                    {
                        if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
                            this.companyUserRoleFunctions.AddCompanyUserRole(item, userId, model.CompanyRole);
                        else
                            if (companyIds.Any(x => x == item))
                            this.companyUserRoleFunctions.AddCompanyUserRole(item, userId, model.CompanyRole);
                    }
                }

                var userModel = userFunctions.GetDataByID(userId);


                string htmlTable = "<br/><br/><div style=\"font-size: 20px;\">Novo usuário cadastrado no sistema</div>";
                htmlTable += mailUtils.UserTable(userId);
                htmlTable += $"<br/>Para mais Informações <a href=\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Manage", "UserManagement") + "?Id=" + userId + "\">clique aqui</a>.";

                //Send Email for user creation
                await mailFunctions.SendAsync("USUÁRIO CRIADO: " + userModel.FullName + " - " + userModel.Email, htmlTable, null, null, userId);
            }
            else
            {
                if (model.Password != null)
                {
                    //Send Email for change password
                    //var _model = userFunctions.GetDataByID(model.UserId);
                    //string htmlTable = "<br/><br/><div style=\"font-size: 20px;\">Senha de usuário alterada no sistema</div>";
                    //htmlTable += mailUtils.UserTable(userId);
                    //htmlTable += "<table style='width:60%;' align='center' class='table-bottom-rounded'><tbody><tr><td style='text-align:center;'>Senha para acesso: " + model.Password + "</td></tr></tbody></table>";
                    //htmlTable += $"<br/>Para mais Informações <a href=\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Manage", "UserManagement") + "?Id=" + model.UserId + "\">clique aqui</a>.";
                    //await mailFunctions.SendAsync("ALTERAÇÃO DE SENHA: " + _model.FullName + " - " + _model.Email, htmlTable, null, null, model.UserId);
                }
            }

            return RedirectToAction("Manage", new { id = userId, saved = true });
        }

        [HttpPost]
        public async Task<IActionResult> QuickList([FromBody] string q)
        {
            return await _List(new DTO.Shared.DataTablesAjaxPostModel() { search = new DTO.Shared.Search() { value = q }, columns = new List<DTO.Shared.Column>() { new DTO.Shared.Column() { data = "FirstName" }, new DTO.Shared.Column() { data = "LastName" } } });
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> _List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            var parameters = new SqlParameterList();

            int? companyId = null;
            if (Request.Query.ContainsKey("companyId") && int.TryParse(Request.Query["companyId"], out int _companyId)) companyId = _companyId;

            if (!User.IsInRole(BLL.User.ProfileNames.Administrator) && !User.IsInRole(BLL.User.ProfileNames.Master))
            {
                var user = await userManager.GetUserAsync(User);
                if (User.IsInRole(BLL.User.ProfileNames.Cliente))
                {
                    var companiesId = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.ClienteAdministrador });
                    if (companiesId.Count == 0 && companyId.HasValue)
                        companiesId.Add(companyId.Value);

                    var usersId = this.companyUserRoleFunctions.UsersIdInCompaniesByRole(companiesId, new List<string> { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteOperador, BLL.User.ProfileNames.ClienteSupervisor });

                    parameters.AddQuery("@USER", $"UserId IN ({string.Join(",", usersId)})", "");
                }
                else if (User.IsInRole(BLL.User.ProfileNames.Biotera))
                {
                    var companiesId = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.BioteraConsultor });
                    var usersId = this.companyUserRoleFunctions.UsersIdInCompaniesByRole(companiesId, new List<string> { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteOperador, BLL.User.ProfileNames.ClienteSupervisor, BLL.User.ProfileNames.BioteraConsultor, BLL.User.ProfileNames.BioteraAuditor });

                    parameters.AddQuery("@USER", $"UserId IN ({string.Join(",", usersId)})", "");
                }
            }

            if (companyId.HasValue)
            {
                var usersInCompany = new List<int>();
                var allUsersUndeleted = userFunctions.GetDataViewModel(userFunctions.GetData(x => x.IsDeleted == false).OrderBy(x => x.UserName));
                foreach (var item in companyUserRoleFunctions.UsersInCompany(companyId.Value))
                    if (allUsersUndeleted.Exists(x => x.UserId == item.UserId))
                        usersInCompany.Add(userViewFunctions.GetDataByID(item.UserId).UserId);

                parameters.AddQuery("@USER", $"UserId IN ({string.Join(",", usersInCompany)})", "");
            }

            IEnumerable<DAL.UserView> d = this.userViewFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, parameters.GetQuery(), parameters.GetParameters()).ToList();

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d.ToList()
            });
        }

        [HttpPost]
        [Authorize(Policy = "UserManagesAnyCompany")]
        public async Task<IActionResult> RemoveUser(int? UserId)
        {
            if (!UserId.HasValue) return Json(false);

            if (UserId.HasValue)
                if (!(await CanManageUser(UserId.Value)))
                    return Forbid();

            this.userFunctions.Delete(UserId.Value);
            this.companyUserRoleFunctions.DeleteAllCompanyUserRoleByUser(UserId.Value);

            var model = userFunctions.GetDataByID(UserId);

            //await BLL.Mail.MailFunctions.SendAsync("Usuário " + model.FirstName + " " + model.LastName + " foi  excluído", "Usuário: <b>" + model.FirstName + " " + model.LastName + "</b> de e-mail: <b>" + model.Email + "</b> foi excluído.", null);

            return Json(true);
        }
    }
}