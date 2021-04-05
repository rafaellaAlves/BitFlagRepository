using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using GLAS2Web.Utils;
using Microsoft.AspNetCore.Identity;

namespace GLAS2Web.Controllers
{
    public class CompanyLawActionManagementController : Controller
    {
        private readonly BLL.Company.CompanyLawActionFunctions companyLawActionFunctions;
        private readonly BLL.Company.CompanyLawActionStatusFunctions companyLawActionStatusFunctions;
        private readonly BLL.Company.CompanyLawActionTypeFunctions companyLawActionTypeFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Company.CompanyLawActionViewFunctions companyLawActionViewFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.Mail.MailFunctions mailFunctions;

        public CompanyLawActionManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Mail.MailFunctions mailFunctions)
        {
            this.companyLawActionFunctions = new BLL.Company.CompanyLawActionFunctions(context);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.companyLawActionStatusFunctions = new BLL.Company.CompanyLawActionStatusFunctions(context);
            this.companyLawActionTypeFunctions = new BLL.Company.CompanyLawActionTypeFunctions(context);
            this.companyLawActionViewFunctions = new BLL.Company.CompanyLawActionViewFunctions(context);
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userManager = userManager;
            this.mailFunctions = mailFunctions;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? companyLawId)
        {
            if (!companyLawId.HasValue)
                return Json(null);

            int recordsTotal = 0;
            int recordsFiltered = 0;
            //var d = this.companyLawActionFunctions.GetDataViewModel(this.companyLawActionFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyLawId = @CompanyLawId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawId", companyLawId)));//x => x.CompanyLawId == companyLawId && !x.IsDeleted));
            var d = this.companyLawActionViewFunctions.GetDataViewModel(this.companyLawActionViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyLawId = @CompanyLawId AND CompanyLawActionIsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawId", companyLawId)));

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        public IActionResult New(int? companyLawId)
        {
            if (!companyLawId.HasValue) return NotFound();
            if (!companyLawFunctions.Exists(companyLawId.Value)) return NotFound();

            int companyLawActionId = companyLawActionFunctions.Create(new DTO.Company.CompanyLawActionViewModel() { Name = "Nova Ação", CompanyLawId = companyLawId.Value, RegistrationDate = DateTime.Now.ToBrazilianDateFormat(), TargetDate = DateTime.Now.ToBrazilianDateFormat(), CompanyLawActionStatusId = companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTCOMPLETED").CompanyLawActionStatusId, CompanyLawActionTypeId = companyLawActionTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "CORRECTIVE").CompanyLawActionTypeId });

            return RedirectToAction("Manage", new { id = companyLawActionId });
        }

        [ActionName("New")]
        [HttpPost]
        public async Task<IActionResult> _New(int? companyLawId)
        {
            if (!companyLawId.HasValue) return Json(new { id = -1, saved = false });
            if (!companyLawFunctions.Exists(companyLawId.Value)) return Json(new { id = -1, saved = false });

            var user = await userManager.GetUserAsync(User);
            var companyLawModel = companyLawFunctions.GetDataByID(companyLawId);
            var companyLawIsCompleted = companyLawFunctions.CompanyLawIsCompleted(companyLawId.Value);

            bool isClienteOperador = companyUserRoleFunctions.CompanyUserHasRole(companyLawModel.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteOperador }); ;

            if (isClienteOperador || companyLawIsCompleted)
            {
                return Forbid();
            }

            int companyLawActionId = companyLawActionFunctions.Create(new DTO.Company.CompanyLawActionViewModel() { Name = "Nova Ação", CompanyLawId = companyLawId.Value, RegistrationDate = DateTime.Now.ToBrazilianDateFormat(), TargetDate = DateTime.Now.ToBrazilianDateFormat(), CompanyLawActionStatusId = companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTCOMPLETED").CompanyLawActionStatusId, CompanyLawActionTypeId = companyLawActionTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "CORRECTIVE").CompanyLawActionTypeId });

            var responsible = mailUtils.GetResponsibleInCompanyLawAction(companyLawActionId);
            var supervisor = mailUtils.GetSupervisorInCompanyLawAction(companyLawActionId);

            var companyLaw = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(companyLawId));
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLaw.LawId));
            var companyModel = companyFunctions.GetDataByID(companyLaw.CompanyId);
            DAL.Identity.User compayLawResponsible = null;
            if (companyLaw.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLaw.ResponsibleId);

            var mailAddress = new List<string>();
            var AdministratorModels = new List<DTO.User.UserModel>();
            AdministratorModels = mailUtils.GetCompanyAdministrators(companyLaw.CompanyId);
            if (responsible != null) AdministratorModels.Add(responsible);
            if (supervisor != null) AdministratorModels.Add(supervisor);
            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

            if (AdministratorModels != null && AdministratorModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(AdministratorModels);


            if (mailAddress.Count > 0)
            {
                string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLaw, user.FullName);
                htmlTable += mailUtils.CompanyLawActionTable(companyLawActionId);
                await mailFunctions.SendAsync("AÇÃO ADICIONADA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyLaw.CompanyId, null);
            }

            return Json(new { CompanyLawAction = companyLawActionFunctions.GetDataViewModel(companyLawActionFunctions.GetDataByID(companyLawActionId)), saved = true });
        }

        public IActionResult Manage(int? id)
        {
            if (!companyLawActionFunctions.Exists(id))
                return NotFound();

            ViewData["CompanyLawActionStatus"] = this.companyLawActionStatusFunctions.GetData();
            ViewData["CompanyLawActionType"] = this.companyLawActionTypeFunctions.GetData();

            return View(this.companyLawActionFunctions.GetDataViewModel(this.companyLawActionFunctions.GetDataByID(id)));
        }

        #region [ManageViewComponent]
        public IActionResult ManageViewComponent(int? id)
        {
            if (!companyLawActionFunctions.Exists(id)) NotFound();

            ViewData["CompanyLawActionStatus"] = this.companyLawActionStatusFunctions.GetData();
            ViewData["CompanyLawActionType"] = this.companyLawActionTypeFunctions.GetData();

            return ViewComponent(typeof(ViewComponents.CompanyLawActionManagement.CompanyLawActionManageViewComponent), new { model = this.companyLawActionFunctions.GetDataViewModel(this.companyLawActionFunctions.GetDataByID(id)) });
        }

        public IActionResult _ManageViewComponent(int companyLawId)
        {

            ViewData["CompanyLawActionStatus"] = this.companyLawActionStatusFunctions.GetData();
            ViewData["CompanyLawActionType"] = this.companyLawActionTypeFunctions.GetData();
            var companyLaw = companyLawFunctions.GetDataByID(companyLawId);
            DAL.Identity.User responsible = null;
            if (companyLaw.ResponsibleId.HasValue)
            {
                responsible = userFunctions.GetDataByID(companyLaw.ResponsibleId);
                if (responsible.IsDeleted) responsible = null;
            }

            var companyLawActionModel = new DTO.Company.CompanyLawViewModel();
            companyLawActionModel.CompanyLawId = companyLawId;
            return ViewComponent(typeof(ViewComponents.CompanyLawActionManagement.CompanyLawActionManageViewComponent), new DTO.Company.CompanyLawActionViewModel() { Name = "Nova Ação", CompanyLawId = companyLawId, ResponsibleId = responsible != null? (int?)responsible.Id : null, ResponsibleName = responsible == null? "" : $"{responsible.FirstName} {responsible.LastName}", RegistrationDate = DateTime.Now.ToBrazilianDateFormat(), TargetDate = DateTime.Now.ToBrazilianDateFormat(), CompanyLawActionStatusId = companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "NOTCOMPLETED").CompanyLawActionStatusId, CompanyLawActionTypeId = companyLawActionTypeFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "CORRECTIVE").CompanyLawActionTypeId });
        }

        [HttpPost]
        public async Task<IActionResult> ManageAjax([FromForm] DTO.Company.CompanyLawActionViewModel model)
        {
            bool newAction = !model.CompanyLawActionId.HasValue;
            var companyLawModel = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(model.CompanyLawId));

            var user = await userManager.GetUserAsync(User);
            bool isClienteSupervisor = companyUserRoleFunctions.CompanyUserHasRole(companyLawModel.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteSupervisor }); ;
            bool isClienteOperador = companyUserRoleFunctions.CompanyUserHasRole(companyLawModel.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteOperador }); ;

            var companyLawIsCompleted = companyLawFunctions.CompanyLawIsCompleted(model.CompanyLawId);
            if (companyLawIsCompleted) return Forbid();

            if (!newAction)
            {
                var currentCompanyLawAction = companyLawActionFunctions.GetDataViewModel(companyLawActionFunctions.GetDataByID(model.CompanyLawActionId));

                #region Check User

                if (isClienteOperador)
                {
                    if (model.CompanyLawActionStatusId != currentCompanyLawAction.CompanyLawActionStatusId || model.ResponsibleId != currentCompanyLawAction.ResponsibleId || model.SupervisorId != currentCompanyLawAction.SupervisorId)

                        return Forbid();
                }

                if (model.RegistrationDate != currentCompanyLawAction.RegistrationDate)
                {
                    return Forbid();
                }
                #endregion
            }
            else
            {
                if (isClienteOperador)
                {
                    if (model.CompanyLawActionStatusId != null || model.ResponsibleId != null || model.SupervisorId != null)

                        return Forbid();
                }
            }
            DateTime? RenewDate = null, WarningDate = null;
            bool alreadyConluded = false;

            var companyModel = companyFunctions.GetDataByID(companyLawModel.CompanyId);
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));

            var userModels = new List<DTO.User.UserModel>();
            userModels = mailUtils.GetCompanyAdministrators(companyLawModel.CompanyId);


            var responsible = new DTO.User.UserModel();
            var supervisor = new DTO.User.UserModel();
            var mailAddress = new List<string>();
            if (!newAction)
            {
                var _model = companyLawActionFunctions.GetDataByID(model.CompanyLawActionId);
                RenewDate = _model.RenewDate;
                WarningDate = _model.WarningDate;
                alreadyConluded = _model.CompanyLawActionStatusId == companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "COMPLETED").CompanyLawActionStatusId ? true : false;
                responsible = mailUtils.GetResponsibleInCompanyLawAction(model.CompanyLawActionId.Value);
                if (responsible != null) userModels.Add(responsible);
                supervisor = mailUtils.GetSupervisorInCompanyLawAction(model.CompanyLawActionId.Value);
                if (supervisor != null) userModels.Add(supervisor);

                DAL.Identity.User compayLawResponsible = null;
                if (companyLawModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawModel.ResponsibleId);

                if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
                if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

                DateTime currentRenewDate;
                DateTime.TryParse(model.RenewDate, out currentRenewDate);

                if (currentRenewDate != RenewDate && model.RenewDate != null && mailAddress.Count > 0)
                {
                    string htmlTable = "<table  class='table-top-rounded' style='width:60%;' align='center'><tbody><tr><td style='text-align:center;'>" + lawViewModel.LawInfoForEmail + "</td></tr></tbody></table><table class='table-bottom-rounded' style='width:60%; margin-top: 5px;' align='center' ><tbody><tr><td style='text-align:center;'>" + lawViewModel.Title + "</td></tr></tbody></table>";
                    htmlTable += mailUtils.CompanyLawActionTable(model.CompanyLawActionId.Value);
                    htmlTable += "<br><table style='width:60%;' class='table-rounded' align='center'><tbody><tr><td style='text-align:center;'>DATA DE RENOVAÇÃO: " + model.RenewDate + "</td></tr></tbody></table>";
                    await mailFunctions.SendAsync("AÇÃO DATA RENOVAÇÃO ALTERADA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail + " - " + model.Name, htmlTable, mailAddress, companyModel.CompanyId);
                }

                DateTime currentWarningDate;
                DateTime.TryParse(model.WarningDate, out currentWarningDate);

                if (currentWarningDate != WarningDate && model.WarningDate != null && mailAddress.Count > 0)
                {
                    string htmlTable = "<br><table style='width:60%;' align='center' class='table-top-rounded'><tbody><tr><td style='text-align:center;'>" + lawViewModel.LawInfoForEmail + "</td></tr></tbody></table><table style='width:60%; margin-top: 5px;' align='center' class='table-bottom-rounded'><tbody><tr><td style='text-align:center;'>" + lawViewModel.Title + "</td></tr></tbody></table>";
                    htmlTable += mailUtils.CompanyLawActionTable(model.CompanyLawActionId.Value);
                    htmlTable += "<br><table class='table-rounded' style='width:60%;' align='center'><tbody><tr><td style='text-align:center;'>DATA DE AVISO: " + model.WarningDate + "</td></tr></tbody></table>";
                    await mailFunctions.SendAsync("AÇÃO DATA AVISO ALTERADA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail + " - " + model.Name, htmlTable, mailAddress, companyModel.CompanyId);
                }
            }

            int companyLawActionId = companyLawActionFunctions.CreateOrUpdate(model);
            var companyLawActionModel = companyLawActionFunctions.GetDataByID(companyLawActionId);
            responsible = mailUtils.GetResponsibleInCompanyLawAction(companyLawActionId);
            supervisor = mailUtils.GetSupervisorInCompanyLawAction(companyLawActionId);

            //if (newAction)
            //{
            //    if (responsible != null) userModels.Add(responsible);
            //    if (supervisor != null) userModels.Add(supervisor);
            //    if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
            //}

            if (model.CompanyLawActionStatusId == companyLawActionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "COMPLETED").CompanyLawActionStatusId && !alreadyConluded)
            {
                mailAddress.Clear();
                DAL.Identity.User compayLawResponsible = null;
                if (companyLawModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawModel.ResponsibleId);

                var AdministratorModels = new List<DTO.User.UserModel>();
                AdministratorModels = mailUtils.GetCompanyAdministrators(companyLawModel.CompanyId);
                if (AdministratorModels != null && AdministratorModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(AdministratorModels);
                if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

                if (mailAddress.Count > 0)
                {
                    string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawModel, user.FullName);
                    htmlTable += mailUtils.CompanyLawActionTable(companyLawActionId);
                    await mailFunctions.SendAsync("AÇÃO CONCLUÍDA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail + " - " + companyLawActionModel.Name, htmlTable, mailAddress, companyModel.CompanyId);
                }
            }

            if (newAction)
            {
                mailAddress.Clear();
                DAL.Identity.User compayLawResponsible = null;
                if (companyLawModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawModel.ResponsibleId);

                var AdministratorModels = new List<DTO.User.UserModel>();
                AdministratorModels = mailUtils.GetCompanyAdministrators(companyLawModel.CompanyId);
                if (responsible != null) AdministratorModels.Add(responsible);
                if (supervisor != null) AdministratorModels.Add(supervisor);

                //var responsible = mailUtils.GetResponsibleInCompanyLawAction(companyLawActionModel.CompanyLawActionId);
                //var supervisor = mailUtils.GetSupervisorInCompanyLawAction(companyLawActionModel.CompanyLawActionId);

                if (AdministratorModels != null && AdministratorModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(AdministratorModels);
                if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

                if (mailAddress.Count > 0)
                {
                    string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawModel, user.FullName);
                    htmlTable += mailUtils.CompanyLawActionTable(companyLawActionId);
                    await mailFunctions.SendAsync("AÇÃO ADICIONADA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyModel.CompanyId);
                    return Json(new { CompanyLawAction = companyLawActionFunctions.GetDataViewModel(companyLawActionModel), saved = true, _new = true });
                }
            }

            return Json(new { CompanyLawAction = companyLawActionFunctions.GetDataViewModel(companyLawActionModel), saved = true, _new = false });
        }
        #endregion

        [HttpPost]
        [ActionName("Manage")]
        public IActionResult _Manage([FromForm] DTO.Company.CompanyLawActionViewModel model)
        {
            int companyLawActionId = companyLawActionFunctions.CreateOrUpdate(model);
            return RedirectToAction("Manage", new { id = companyLawActionId, saved = true });
        }
    }
}