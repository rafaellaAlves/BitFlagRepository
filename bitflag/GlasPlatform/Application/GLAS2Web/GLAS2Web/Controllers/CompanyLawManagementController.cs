using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Data.SqlClient;
using GLAS2Web.Security;
using GLAS2Web.Utils;
using Microsoft.AspNetCore.Hosting;
using System.Security.Claims;

namespace GLAS2Web.Controllers
{
    public class CompanyLawManagementController : Controller
    {
        private readonly BLL.Company.CompanyFunctions company;
        private readonly BLL.Company.CompanyLawFunctions companyLaw;
        private readonly BLL.Company.CompanyLawActionFunctions companyLawAction;
        private readonly BLL.Company.CompanyLawViewFunctions CompanyLawView;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private readonly BLL.Law.LawTypeFunctions lawTypeFunctions;
        private readonly BLL.Law.LawConclusionStatusFunctions lawConclusionStatusFunctions;
        private readonly BLL.Law.LawPotentialityTypeFunctions lawPotentialityTypeFunctions;
        private readonly BLL.Company.CompanyLawActionStatusFunctions companyLawActionStatusFunctions;
        private readonly BLL.Company.CompanyLawActionFunctions companyLawActionFunctions;
        private readonly BLL.Law.LawViewFunctions lawViewFunctions;
        private readonly BLL.Company.CompanyUserFunctions companyUserFunctions;
        private readonly BLL.Company.CompanyLawUserViewFunctions companyLawUserViewFunctions;
        private readonly BLL.Mail.MailUtils mailUtils;
        private readonly BLL.Utils.SegmentoFunctions segmentoFunctions;
        private readonly BLL.Utils.EsferaFunctions esferaFunctions;
        private readonly BLL.Company.CompanyLawCommentFunctions companyLawCommentFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Company.CompanyLawVisualizationFunctions companyLawVisualizationFunctions;
        private readonly BLL.Mail.MailFunctions mailFunctions;
        private readonly BLL.Localization.TranslationFunctions translationFunctions;

        public CompanyLawManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, BLL.Company.CompanyLawVisualizationFunctions companyLawVisualizationFunctions, BLL.Mail.MailFunctions mailFunctions, BLL.Localization.TranslationFunctions translationFunctions)
        {
            this.company = new BLL.Company.CompanyFunctions(context);
            this.companyLaw = new BLL.Company.CompanyLawFunctions(context);
            this.companyLawAction = new BLL.Company.CompanyLawActionFunctions(context);
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.CompanyLawView = new BLL.Company.CompanyLawViewFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
            this.lawConclusionStatusFunctions = new BLL.Law.LawConclusionStatusFunctions(context);
            this.lawPotentialityTypeFunctions = new BLL.Law.LawPotentialityTypeFunctions(context);
            this.lawViewFunctions = new BLL.Law.LawViewFunctions(context);
            this.companyUserFunctions = new BLL.Company.CompanyUserFunctions(context);
            this.companyLawActionFunctions = new BLL.Company.CompanyLawActionFunctions(context);
            this.companyLawUserViewFunctions = new BLL.Company.CompanyLawUserViewFunctions(context);
            this.companyLawActionStatusFunctions = new BLL.Company.CompanyLawActionStatusFunctions(context);
            this.segmentoFunctions = new BLL.Utils.SegmentoFunctions(context);
            this.mailUtils = new BLL.Mail.MailUtils(context, userManager);
            this.userManager = userManager;
            this.companyLawCommentFunctions = new BLL.Company.CompanyLawCommentFunctions(context, userManager);
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.esferaFunctions = new BLL.Utils.EsferaFunctions(context);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.lawTypeFunctions = new BLL.Law.LawTypeFunctions(context);
            this.companyLawVisualizationFunctions = companyLawVisualizationFunctions;
            this.mailFunctions = mailFunctions;
            this.translationFunctions = translationFunctions;
        }

        public IActionResult Actions(int? id)
        {
            if (!companyLaw.Exists(id))
                return RedirectToAction("Index");
            else
                return View(this.companyLaw.GetDataViewModel(this.companyLaw.GetDataByID(id)));
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult CopyCompanyLaws()
        {
            ViewData["Esfera"] = esferaFunctions.GetData().ToList();
            ViewData["Segmento"] = segmentoFunctions.GetData().ToList();
            ViewData["LawApplicationType"] = lawApplicationTypeFunctions.GetData().ToList();
            ViewData["Companies"] = companyFunctions.GetCopyCompanyLawViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).OrderBy(x => x.NomeFantasia));

            return View();
        }

        #region [Actions ViewComponent]
        public IActionResult CompanyLawActionListViewComponent(int? id)
        {
            if (!companyLaw.Exists(id)) NotFound();
            return ViewComponent(typeof(ViewComponents.CompanyLawActionManagement.CompanyLawActionListViewComponent), new { companyLawId = id });
        }
        #endregion

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? companyId, string[] segmento, string[] aplicabilidade, string[] status, string[] tipo)
        {
            if (!companyId.HasValue)
                return Json(null);

            int recordsTotal = 0;
            int recordsFiltered = 0;

            string sqlText = "";

            if (segmento.Length > 0)
            {
                string _sqlText = "( LawSegmentoId = " + segmento[0];
                for (var i = 1; i < segmento.Length; i++)
                    _sqlText += " OR LawSegmentoId = " + segmento[i];
                sqlText += " AND " + _sqlText + ")";
            }

            if (aplicabilidade.Length > 0)
            {
                string _sqlText = "( CompanyLawApplicationTypeId = " + aplicabilidade[0];
                for (var i = 1; i < aplicabilidade.Length; i++)
                    _sqlText += " OR CompanyLawApplicationTypeId = " + aplicabilidade[i];
                sqlText += " AND " + _sqlText + ")";
            }

            if (status.Length > 0)
            {
                string _sqlText = "( CompanyLawConclusionStatusId = " + status[0];
                for (var i = 1; i < status.Length; i++)
                    _sqlText += " OR CompanyLawConclusionStatusId = " + status[i];
                sqlText += " AND " + _sqlText + ")";
            }

            if (tipo.Length > 0)
            {
                string _sqlText = "( LawTypeId = " + tipo[0];
                for (var i = 1; i < tipo.Length; i++)
                    _sqlText += " OR LawTypeId = " + tipo[i];
                sqlText += " AND " + _sqlText + ")";
            }

            IEnumerable<DAL.CompanyLawView> d = this.CompanyLawView.GetDataViewModel(this.CompanyLawView.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyId = @CompanyId AND CompanyLawIsDeleted = 0 AND LawIsDeleted = 0 AND (LawRevokedDate IS NULL AND LawRevokedBy IS NULL)" + sqlText, new System.Data.SqlClient.SqlParameter("@CompanyId", companyId)));

            //if(filter.order.Count > 0 && filter.columns[filter.order[0].column].data == "LawNumber")
            //{
            //    if (filter.order[0].dir == "asc") d = d.OrderBy(x => {
            //        double r;
            //        if (!double.TryParse(x.LawNumber._NumbersOnly(), out r))
            //            r = double.NegativeInfinity;

            //        return r;
            //        });
            //    else d = d.OrderByDescending(x => {
            //        double r;
            //        if (!double.TryParse(x.LawNumber._NumbersOnly(), out r))
            //            r = double.PositiveInfinity;

            //        return r;
            //    });
            //}

            foreach(var item in d)
            {
                item.CompanyLawApplicationTypeName = translationFunctions.GetTranslation(item.CompanyLawApplicationTypeName, User.FindFirstValue("CultureInfo"));
                item.CompanyLawConclusionStatusName = translationFunctions.GetTranslation(item.CompanyLawConclusionStatusName, User.FindFirstValue("CultureInfo"));
            }

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        [HttpPost]
        [ActionName("CompanyHasLaws")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult CompanyHasLaws(int companyId)
        {
            return Json(companyLaw.CompanyHasLaws(companyId));
        }

        [HttpPost]
        [ActionName("GetLaws")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult GetLaws(int originCompanyId, List<int> segmento, List<int> tipo, List<int> esfera)
        {
            var companyLaws = CompanyLawView.GetData().Where(x => x.CompanyId == originCompanyId && !x.LawIsDeleted && !x.CompanyLawIsDeleted && !x.LawRevokedDate.HasValue).ToList();

            if (segmento.Count > 0) companyLaws = companyLaws.Where(x => segmento.Contains(x.LawSegmentoId.Value)).ToList();
            if (tipo.Count > 0) companyLaws = companyLaws.Where(x => tipo.Contains(x.CompanyLawApplicationTypeId.Value)).ToList();
            if (esfera.Count > 0) companyLaws = companyLaws.Where(x => esfera.Contains(x.LawEsferaId.Value)).ToList();

            //var r = (from y in companyLaws

            //         join e in esfera on y.LawEsferaId equals e
            //         //into _e
            //         //from e in _e.DefaultIfEmpty()

            //         join s in segmento on y.LawSegmentoId equals s 
            //         //into _s
            //         //from s in _s.DefaultIfEmpty()

            //         join t in tipo on y.CompanyLawApplicationTypeId equals t 
            //         //into _t
            //         //from t in _t.DefaultIfEmpty()

            //         where !y.LawIsDeleted && !y.CompanyLawIsDeleted
            //         select new
            //         {
            //             companyLaw = y,
            //             segmento = s > 0,
            //             tipo = t > 0,
            //             esfera = e > 0
            //         });
            var r = companyLaws.Select(x => new 
            {
                companyLaw = x
            });
            var d = r.GroupBy(x => x.companyLaw.LawId).Select(y => y.First()); // remove companyLaws que possuam lei duplicadas

            var totalSegmento = d.Count(x => x.companyLaw.LawSegmentoId.HasValue && segmento.Contains(x.companyLaw.LawSegmentoId.Value));
            var totalTipo = d.Count(x => x.companyLaw.CompanyLawApplicationTypeId.HasValue && tipo.Contains(x.companyLaw.CompanyLawApplicationTypeId.Value));
            var totalEsfera = d.Count(x => x.companyLaw.LawEsferaId.HasValue && esfera.Contains(x.companyLaw.LawEsferaId.Value));

            return Json(new { companyLaws = d, totalSegmento, totalTipo, totalEsfera });
        }

        [HttpPost]
        [ActionName("CheckLaws")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult CheckLaws(List<int> companyLawIds, int destinationCompanyId)
        {
            var companyLaws = companyLaw.GetData().Where(x => companyLawIds.Contains(x.CompanyLawId)).ToList();
            var lawIds = companyLaw.GetData().Where(x => x.CompanyId == destinationCompanyId && !x.IsDeleted).Select(x => x.LawId);

            foreach (var companyLaw in companyLaws)
            {
                if (lawIds.Contains(companyLaw.LawId)) return Json(true);
            }

            return Json(false);
        }

        [HttpPost]
        [ActionName("SetLaws")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult SetLaws(List<int> companyLawIds, int destinationCompanyId, bool replaceLaws, bool EvidencesCheck, bool ResponseCheck, bool AttachmentCheck, bool StatusCheck, [FromServices] IHostingEnvironment _hostingEnvironment)
        {
            var companyLaws = companyLaw.GetData().Where(x => companyLawIds.Contains(x.CompanyLawId)).ToList();

            var totalAdded = companyLaw.Create(companyLaws, destinationCompanyId, replaceLaws, EvidencesCheck, ResponseCheck, AttachmentCheck, StatusCheck, _hostingEnvironment);

            return Json(totalAdded);
        }

        public IActionResult Manage(int? id)
        {
            ViewData["LawApplicationType"] = lawApplicationTypeFunctions.GetData();
            ViewData["LawConclusionStatus"] = lawConclusionStatusFunctions.GetData();
            ViewData["LawPotentialityType"] = lawPotentialityTypeFunctions.GetData();

            if (!companyLaw.Exists(id))
                return RedirectToAction("Index", "CompanyManagement");

            return View(this.companyLaw.GetDataViewModel(this.companyLaw.GetDataByID(id)));
        }

        #region [ManageViewComponent]
        public IActionResult CompanyLawList(int? companyId)
        {
            if (!company.Exists(companyId))
                return NotFound();

            ViewData["Status"] = lawConclusionStatusFunctions.GetData().ToList();
            ViewData["Aplicabilidade"] = lawApplicationTypeFunctions.GetData().ToList();
            ViewData["Segmento"] = segmentoFunctions.GetData().ToList();
            ViewData["Tipo"] = lawTypeFunctions.GetData().ToList();

            return ViewComponent(typeof(ViewComponents.LawManagement.CompanyLawListViewComponent), new { companyId = companyId });
        }
        public async Task<IActionResult> ManageViewComponent(int? id)
        {

            ViewData["LawApplicationType"] = lawApplicationTypeFunctions.GetData();
            ViewData["LawConclusionStatus"] = lawConclusionStatusFunctions.GetData();

            if (!companyLaw.Exists(id)) NotFound();

            var _companyLaw = companyLaw.GetDataByID(id);
            var users = userFunctions.GetData().ToList();
            var usersInCompany = new List<int>();
            var allUsersUndeleted = users.Where(x => !x.IsDeleted).ToList();

            foreach (var item in companyUserRoleFunctions.UsersInCompany(_companyLaw.CompanyId))
            {
                if (allUsersUndeleted.Exists(x => x.Id == item.UserId))
                {
                    usersInCompany.Add(item.UserId);
                }
            }
            users = users.Where(x => usersInCompany.Contains(x.Id)).ToList();
            ViewData["Responsibles"] = users;


            return ViewComponent(typeof(ViewComponents.LawManagement.CompanyLawManagementViewComponent), new { model = this.companyLaw.GetDataViewModel(this.companyLaw.GetDataByID(id)) });
        }
        [HttpPost]
        public async Task<IActionResult> ManageAjax([FromForm] DTO.Company.CompanyLawViewModel model)
        {

            int actionNotCompletedId = companyLawActionStatusFunctions.GetDataFiltered(x => x.ExternalCode == "NOTCOMPLETED").First().CompanyLawActionStatusId;
            int lawActionsUncompletedCount = companyLawActionFunctions.GetData().Where(x => x.CompanyLawActionStatusId == actionNotCompletedId && x.IsDeleted == false && x.CompanyLawId == model.CompanyLawId).Count();
            int lawConclusionId = lawConclusionStatusFunctions.GetDataFiltered(x => x.ExternalCode == "COMPLETED").First().LawConclusionStatusId;
            int lawNotApplicableId = lawConclusionStatusFunctions.GetDataFiltered(x => x.ExternalCode == "NOTAPPLICABLE").First().LawConclusionStatusId;

            int knowledgeId = lawApplicationTypeFunctions.GetData().SingleOrDefault(x => x.ExternalCode == "KNOWLEDGE").LawApplicationTypeId;
            int applicableId = lawApplicationTypeFunctions.GetData().SingleOrDefault(x => x.ExternalCode == "APPLICABLE").LawApplicationTypeId;

            if (lawActionsUncompletedCount > 0 && model.LawConclusionStatusId == lawConclusionId)
            {
                return Json(false);
            }

            if (model.LawApplicationTypeId == knowledgeId && model.LawConclusionStatusId == lawConclusionId) return Forbid();
            if (model.LawApplicationTypeId == applicableId && model.LawConclusionStatusId == lawNotApplicableId) return Forbid();

            var user = await userManager.GetUserAsync(User);

            if (!model.CompanyLawId.HasValue) return Forbid();


            bool isClienteAdministrador = companyUserRoleFunctions.CompanyUserHasRole(model.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteAdministrador }); ;
            bool isClienteSupervisor = companyUserRoleFunctions.CompanyUserHasRole(model.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteSupervisor }); ;
            bool isClienteOperador = companyUserRoleFunctions.CompanyUserHasRole(model.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteOperador }); ;

            if (isClienteOperador)
            {
                return Forbid();
            }

            var _model = companyLaw.GetDataByID(model.CompanyLawId);
            var currentCompanyLaw = companyLaw.GetDataViewModel(_model);

            if (isClienteSupervisor)
            {

                if (currentCompanyLaw.LawApplicationTypeId != model.LawApplicationTypeId || currentCompanyLaw.LawConclusionStatusId != model.LawConclusionStatusId)
                {
                    return Forbid();
                }
            }
            if (isClienteAdministrador && currentCompanyLaw.LawApplicationTypeId != model.LawApplicationTypeId)
            {
                return Forbid();
            }

            DateTime? OldRenewDate = null, OldWarningDate = null;
            int? oldStatusId = null;
            OldRenewDate = _model.RenewDate;
            OldWarningDate = _model.WarningDate;
            oldStatusId = _model.LawConclusionStatusId;
            var oldResponsibleId = _model.ResponsibleId;
            bool RenewDateHasValue = model.RenewDate != null ? true : false;
            bool WarningDateHasValue = model.WarningDate != null ? true : false;

            DateTime currentRenewDate;
            DateTime.TryParse(model.RenewDate, out currentRenewDate);
            DateTime currentWarningDate;
            DateTime.TryParse(model.WarningDate, out currentWarningDate);


            var companyModel = company.GetDataByID(model.CompanyId);
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(model.LawId));

            model.LastHandler = user.Id;
            int companyLawId = companyLaw.CreateOrUpdate(model);

            var companyLawViewModel = companyLaw.GetDataViewModel(companyLaw.GetDataByID(model.CompanyLawId));

            DAL.Identity.User compayLawResponsible = null;
            if (companyLawViewModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawViewModel.ResponsibleId);

            string htmlTable;
            var userModels = new List<DTO.User.UserModel>();
            userModels = mailUtils.GetCompanyAdministrators(model.CompanyId);
            var mailAddress = new List<string>();
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

            if (currentRenewDate != OldRenewDate && RenewDateHasValue)
            {
                if (mailAddress.Count > 0)
                {
                    htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                    htmlTable += "<br><table class='table-rounded' align='center' style='width:60%;'><tbody><tr><td style='text-align:center;'>DATA DE RENOVAÇÃO: " + model.RenewDate + "</td></tr></tbody></table>";
                    await mailFunctions.SendAsync("DATA DE RENOVAÇÃO ALTERADA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail,
                        htmlTable, mailAddress, companyModel.CompanyId);
                }
            }


            if (currentWarningDate != OldWarningDate && WarningDateHasValue)
            {
                userModels = mailUtils.GetCompanyAdministrators(model.CompanyId);
                mailAddress.Clear();

                if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
                if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

                if (mailAddress.Count > 0)
                {
                    htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                    htmlTable += "<br><table class='table-rounded' align='center' style='width:60%;'><tbody><tr><td style='text-align:center;'>DATA DE AVISO: " + model.WarningDate + "</td></tr></tbody></table>";
                    await mailFunctions.SendAsync("DATA AVISO ALTERADA: " + companyModel.NomeFantasia + " " + lawViewModel.LawInfoForEmail,
                        htmlTable, mailAddress, companyModel.CompanyId);
                }
            }


            if (model.LawConclusionStatusId == lawConclusionStatusFunctions.GetData().FirstOrDefault(x => x.ExternalCode == "COMPLETED").LawConclusionStatusId)
            {
                userModels = mailUtils.GetCompanyAdministrators(model.CompanyId);
                mailAddress.Clear();
                if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
                if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

                if (mailAddress.Count > 0)
                {
                    htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                    await mailFunctions.SendAsync("REQUISITO LEGAL CONCLUÍDO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail,
                        htmlTable, mailAddress, companyModel.CompanyId);
                }
            }
            else if (oldStatusId.HasValue && oldStatusId != model.LawConclusionStatusId)
            {
                userModels = mailUtils.GetCompanyAdministrators(model.CompanyId);
                mailAddress.Clear();
                if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
                var comments = companyLawCommentFunctions.GetData().Where(x => x.CompanyLawId == model.CompanyLawId && (companyUserRoleFunctions.GetUserRole(x.AuthorId).Id == 7 || companyUserRoleFunctions.GetUserRole(x.AuthorId).Id == 8 || companyUserRoleFunctions.GetUserRole(x.AuthorId).Id == 9));
                if (comments.Count() > 0)
                {
                    var _user = userFunctions.GetDataByID(comments.Last().AuthorId);
                    mailAddress.Add(_user.Email);
                }

                if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

                if (mailAddress.Count > 0)
                {
                    htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                    await mailFunctions.SendAsync("STATUS DE REQUISITO LEGAL ALTERADO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail,
                        htmlTable, mailAddress, companyModel.CompanyId);
                }
            }
            else if (oldResponsibleId != model.ResponsibleId)
            {
                if (model.ResponsibleId.HasValue)
                {
                    var responsible = userFunctions.GetDataByID(model.ResponsibleId);
                    await mailFunctions.SendAsync("VOCÊ SE TORNOU RESPONSÁVEL POR UM REQUISITO LEGAL - " + companyModel.NomeFantasia,
                        NewResponsibleEmailText(responsible, companyLawViewModel), mailAddress, companyModel.CompanyId, model.ResponsibleId);
                }
            }

            return Json(new { CompanyLawId = companyLawId, LawTitle = lawViewModel.Title, LawSegmentoName = lawViewModel.SegmentoName, LawOrgaoName = lawViewModel.OrgaoName, _LawNumber = lawViewModel._Number, _LawForceDate = lawViewModel.ForceDate, Saved = true });
        }
        #endregion

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage([FromForm] DTO.Company.CompanyLawViewModel model)
        {
            int companyID = companyLaw.CreateOrUpdate(model);
            var _model = company.GetDataByID(companyID);
            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(model.LawId));

            var userModels = new List<DTO.User.UserModel>();
            userModels = mailUtils.GetCompanyAdminisAndSupervisors(model.CompanyId);
            var mailAddress = new List<string>();
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);

            var user = await userManager.GetUserAsync(User);
            if (mailAddress.Count > 0)
            {
                string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, model, user.FullName);
                await mailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + _model.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, model.CompanyId);
            }

            return RedirectToAction("Manage", new { id = companyID, saved = true });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveLawActionFromCompanyLaw(int? companyLawActionId)
        {
            if (!companyLawActionId.HasValue) return Json(false);

            var user = await userManager.GetUserAsync(User);
            var companyLawActionModel = companyLawAction.GetDataByID(companyLawActionId);

            var companyLawModel = new DAL.CompanyLaw();
            if (companyLawActionModel == null) return Forbid();

            companyLawModel = companyLaw.GetDataByID(companyLawActionModel.CompanyLawId);
            var companyLawIsCompleted = companyLaw.CompanyLawIsCompleted(companyLawActionModel.CompanyLawId);

            if (companyLawIsCompleted) return Forbid();

            bool isClienteOperador = companyUserRoleFunctions.CompanyUserHasRole(companyLawModel.CompanyId, user.Id, new List<string>() { BLL.User.ProfileNames.ClienteOperador }); ;

            if (isClienteOperador)
            {
                return Forbid();
            }

            this.companyLawAction.Delete(companyLawActionId.Value);

            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(companyLawModel.LawId));
            var companyModel = company.GetDataByID(companyLawModel.CompanyId);
            var companyLawViewModel = companyLaw.GetDataViewModel(companyLawModel);
            DAL.Identity.User compayLawResponsible = null;
            if (companyLawViewModel.ResponsibleId.HasValue) compayLawResponsible = userFunctions.GetDataByID(companyLawViewModel.ResponsibleId);

            var userModels = new List<DTO.User.UserModel>();
            var mailAddress = new List<string>();
            userModels = mailUtils.GetCompanyAdministrators(companyModel.CompanyId);
            var responsible = new DTO.User.UserModel();
            responsible = mailUtils.GetResponsibleInCompanyLawAction(companyLawActionModel.CompanyLawActionId);
            if (responsible != null) userModels.Add(responsible);
            var supervisor = new DTO.User.UserModel();
            supervisor = mailUtils.GetSupervisorInCompanyLawAction(companyLawActionModel.CompanyLawActionId);
            if (supervisor != null) userModels.Add(supervisor);
            if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);
            if (compayLawResponsible != null && !string.IsNullOrWhiteSpace(compayLawResponsible.Email)) mailAddress.Add(compayLawResponsible.Email);

            if (mailAddress.Count > 0)
            {
                string htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, companyLawViewModel, user.FullName);
                htmlTable += mailUtils.CompanyLawActionTable(companyLawActionModel.CompanyLawActionId);
                await mailFunctions.SendAsync("AÇÃO EXCLUÍDA: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail + " - " + companyLawActionModel.Name, htmlTable, mailAddress, companyModel.CompanyId);
            }

            return Json(true);
        }

        [HttpPost]
        [ActionName("UpdateLastView")]
        public async Task<IActionResult> UpdateLastView(DAL.CompanyLawUserView model)
        {
            var user = await this.userManager.GetUserAsync(User);
            model.UserId = user.Id;

            int companyLawActionUserId = -1;
            companyLawActionUserId = companyLawUserViewFunctions.GetCompanyLawUserId(model.CompanyId, model.UserId);
            if (companyLawActionUserId != -1)
                model.CompanyLawUserId = companyLawActionUserId;

            companyLawUserViewFunctions.CreateOrUpdate(model);

            return Json(true);
        }

        [HttpPost]
        [ActionName("AssociateCompaniesToLaw")]
        public async Task<IActionResult> AssociateCompaniesToLaw(int lawId, int[] knowledgeCompanyIds, int[] applicableCompanyIds)
        {
            int knowledgeCount = 0;
            int applicationCount = 0;
            int knowledgecompanyLawId = -1;
            int applicablecompanyLawId = -1;
            List<int> allCompanyIds = new List<int>();
            allCompanyIds.AddRange(knowledgeCompanyIds);
            allCompanyIds.AddRange(applicableCompanyIds);

            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(lawId));

            var lawApplicationTypeId = lawApplicationTypeFunctions.GetDataFiltered(x => x.ExternalCode.ToUpper().Equals("KNOWLEDGE")).First().LawApplicationTypeId;
            var lawConclusionStatusId = lawConclusionStatusFunctions.GetDataFiltered(x => x.ExternalCode.ToUpper().Equals("NOTAPPLICABLE")).First().LawConclusionStatusId;
            var lawPotentialityTypeId = lawPotentialityTypeFunctions.GetDataFiltered(x => x.ExternalCode.ToUpper().Equals("NOTAPPLICABLE")).First().LawPotentialityTypeId;

            foreach (var knowledgeCompanyId in knowledgeCompanyIds)
            {
                if (companyLaw.LawIsInCompany(lawId, knowledgeCompanyId)) continue;
                knowledgecompanyLawId = companyLaw.Create(new DTO.Company.CompanyLawViewModel() { CompanyId = knowledgeCompanyId, LawId = lawId, LawApplicationTypeId = lawApplicationTypeId, LawPotentialityTypeId = lawViewModel.LawPotentialityTypeId ?? lawPotentialityTypeId, LawConclusionStatusId = lawConclusionStatusId });
                knowledgeCount++;


            }
            foreach (var applicableCompanyId in applicableCompanyIds)
            {
                if (companyLaw.LawIsInCompany(lawId, applicableCompanyId)) continue;
                applicablecompanyLawId = companyLaw.Create(new DTO.Company.CompanyLawViewModel() { CompanyId = applicableCompanyId, LawId = lawId, LawApplicationTypeId = lawApplicationTypeId, LawPotentialityTypeId = lawViewModel.LawPotentialityTypeId ?? lawPotentialityTypeId, LawConclusionStatusId = lawConclusionStatusId });
                applicationCount++;
            }

            var knowlegeCompanyLawModel = new DTO.Company.CompanyLawViewModel();
            var applicableCompanyLawModel = new DTO.Company.CompanyLawViewModel();

            if (knowledgecompanyLawId != -1 || applicablecompanyLawId != -1)
            {

                if (knowledgecompanyLawId != -1) knowlegeCompanyLawModel = companyLaw.GetDataViewModel(companyLaw.GetDataByID(knowledgecompanyLawId));
                if (applicablecompanyLawId != -1) applicableCompanyLawModel = companyLaw.GetDataViewModel(companyLaw.GetDataByID(applicablecompanyLawId));
                foreach (var companyId in allCompanyIds)
                {
                    var userModels = new List<DTO.User.UserModel>();
                    userModels = mailUtils.GetCompanyAdministrators(companyId);
                    var mailAddress = new List<string>();
                    if (userModels != null && userModels.Count > 0) mailAddress = mailUtils.UserModelsToMailAddress(userModels);

                    var companyModel = company.GetDataByID(companyId);

                    var user = await userManager.GetUserAsync(User);
                    string htmlTable = "";
                    if (knowledgeCompanyIds.Contains(companyId)) { htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, knowlegeCompanyLawModel, user.FullName); }
                    else if (applicableCompanyIds.Contains(companyId)) { htmlTable = mailUtils.MountHtmlLawTable(lawViewModel.LawInfoForEmail, applicableCompanyLawModel, user.FullName); }

                    await mailFunctions.SendAsync("REQUISITO LEGAL ADICIONADO: " + companyModel.NomeFantasia + " - " + lawViewModel.LawInfoForEmail, htmlTable, mailAddress, companyModel.CompanyId);
                }
            }

            return Json(new { knowlwdgeTotal = knowledgeCompanyIds.Count(), applicationTotal = applicableCompanyIds.Count(), knowledgeChanged = knowledgeCount, applicationChanged = applicationCount });
        }

        private string NewResponsibleEmailText(DAL.Identity.User resp, DTO.Company.CompanyLawViewModel companyLaw)
        {
            return $"<div style='text-align:left;'>" +
                $"Olá, <b>{resp.FirstName} {resp.LastName}</b>" +
                $"<br><br>" +
                $"Você foi escolhido como responsável para o seguinte requisito legal: " +
                $"<div style='text-align:center;'>" +
                mailUtils.MountHtmlLawTable(companyLaw.Law.LawInfoForEmail, companyLaw) +
                $"</div>" +
                $"<br><br>" +
                "Para mais informações, por favor, acesse o <a href=\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("Dashboard", "Home") + "?companyId=" + companyLaw.CompanyId + "\">GLAS</a>." +
                $"<br><br>" +
                $"Atenciosamente," +
                $"<br><br>" +
                $"Equipe Biotera." +
                $"</div>";
        }

        public async Task SetCompanyLawVisualization(int companyLawId)
        {
            var userId = (await userManager.GetUserAsync(User)).Id;
            if (await companyLawVisualizationFunctions.Exists(companyLawId, userId)) return;

            companyLawVisualizationFunctions.Create(new DAL.CompanyLawVisualization(companyLawId, userId));
        }
    }
}