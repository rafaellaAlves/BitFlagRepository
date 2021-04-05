using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GLAS2Web.Controllers
{
    [Authorize]
    public class ReportController : AlanJuden.MvcReportViewer.ReportController
    {
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.User.UserFunctions userFunctions;
        private readonly BLL.Company.CompanyFunctions companyFunctions;
        private readonly BLL.Law.LawTypeFunctions lawTypeFunctions;
        private readonly BLL.Utils.OrgaoFunctions orgaoFunctions;
        private readonly BLL.Utils.SegmentoFunctions segmentoFunctions;
        private readonly BLL.Utils.EsferaFunctions esferaFunctions;
        private readonly BLL.Law.LawApplicationTypeFunctions lawApplicationTypeFunctions;
        private readonly BLL.Law.LawConclusionStatusFunctions lawConclusionStatusFunctions;
        private readonly BLL.Company.CompanyLawActionStatusFunctions companyLawActionStatusFunctions;
        private readonly BLL.Company.CompanyLawActionTypeFunctions companyLawActionTypeFunctions;
        private readonly IConfiguration configuration;

        private readonly UserManager<DAL.Identity.User> userManager;

        public ReportController(IHttpContextAccessor httpContextAccessor, DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager, IConfiguration configuration)
        {
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.userFunctions = new BLL.User.UserFunctions(context, userManager);
            this.companyFunctions = new BLL.Company.CompanyFunctions(context);
            this.lawTypeFunctions = new BLL.Law.LawTypeFunctions(context);
            this.orgaoFunctions = new BLL.Utils.OrgaoFunctions(context);
            this.segmentoFunctions = new BLL.Utils.SegmentoFunctions(context);
            this.esferaFunctions = new BLL.Utils.EsferaFunctions(context);
            this.lawApplicationTypeFunctions = new BLL.Law.LawApplicationTypeFunctions(context);
            this.lawConclusionStatusFunctions = new BLL.Law.LawConclusionStatusFunctions(context);
            this.companyLawActionStatusFunctions = new BLL.Company.CompanyLawActionStatusFunctions(context);
            this.companyLawActionTypeFunctions = new BLL.Company.CompanyLawActionTypeFunctions(context);
            this.userManager = userManager;
            this.configuration = configuration;
        }

        protected override ICredentials NetworkCredentials
        {
            get { return new System.Net.NetworkCredential(configuration["SQLServerReportingServices:UserName"], configuration["SQLServerReportingServices:Password"], configuration["SQLServerReportingServices:Domain"]); }
        }

        protected override string ReportServerUrl
        {
            get { return configuration["SQLServerReportingServices:ServiceUrl"]; }
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue) return NotFound();

            var model = this.GetReportViewerModel(Request);

            switch (id.Value)
            {
                case 1:
                    model.ReportPath = "/GLAS2/REQUISITOS_LEGAIS";
                    model.Title = "Requisitos Legais";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "EsferaId", "CompanyLawPotentialityTypeExternalCode", "CompanyLawApplicationTypeExternalCode", "CompanyLawConclusionStatusExternalCode", "LawForceDate", "CompanyLawRenewDate", "HasCompanyLawAction", "CompanyLawResponsibleId" };
                    break;
                case 2:
                    model.ReportPath = "/GLAS2/ACOES";
                    model.Title = "Ações";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "CompanyLawActionResponsibleId", "CompanyLawActionSupervisorId", "CompanyLawActionRegistrationDate", "CompanyLawActionRenewDate", "CompanyLawActionTargetDate" };
                    break;
                case 3:
                    model.ReportPath = "/GLAS2/PLANO_DE_ACAO_DO_REQUISITO_LEGAL";
                    model.Title = "Plano de Ação do Requisito Legal";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "CompanyLawActionResponsibleId", "CompanyLawActionSupervisorId", "CompanyLawActionRegistrationDate", "CompanyLawActionRenewDate", "CompanyLawActionTargetDate" };
                    break;
                case 4:
                    model.ReportPath = "/GLAS2/DADOS_ESTATISTICOS";
                    model.Title = "Dados Estatísticos";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "CompanyLawApplicationTypeExternalCode" };
                    break;
                case 5:
                    model.ReportPath = "/GLAS2/ORGAOS_GERENCIADOS";
                    model.Title = "Órgãos Gerenciados";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "CompanyLawApplicationTypeExternalCode", "OrgaoId" };
                    break;
                case 6:
                    model.ReportPath = "/GLAS2/CONTABILIDADE_SOCIOAMBIENTAL";
                    model.Title = "Contabilidade Socioambiental";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "LawForceDate", "CompanyLawRenewDate", "CompanyLawActionRegistrationDate", "CompanyLawActionRenewDate", "CompanyLawActionTargetDate" };
                    break;
                case 7:
                    model.ReportPath = "/GLAS2/SUPERVISOR_PLANO_DE_ACAO_DO_REQUISITO_LEGAL";
                    model.Title = "Estatísticas do Usuário - Supervisor";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "CompanyLawActionResponsibleId", "CompanyLawActionSupervisorId", "CompanyLawActionRegistrationDate", "CompanyLawActionRenewDate", "CompanyLawActionTargetDate" };
                    break;
                case 8:
                    model.ReportPath = "/GLAS2/RESPONSAVEL_PLANO_DE_ACAO_DO_REQUISITO_LEGAL";
                    model.Title = "Estatísticas do Usuário - Responsável";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "CompanyLawResponsibleId", "CompanyLawActionResponsibleId", "CompanyLawActionSupervisorId", "CompanyLawActionRegistrationDate", "CompanyLawActionRenewDate", "CompanyLawActionTargetDate" };
                    break;
                case 9:
                    model.ReportPath = "/GLAS2/INFORMACAO_CONSOLIDADA";
                    model.Title = "Informação Consolidada";
                    model.Filters = new List<string>() { "CompanyId", "CompanyLawCreatedDate", "SegmentoId" };
                    break;
                case 10:
                    model.ReportPath = "/GLAS2/PENDENCIAS_ANALISE";
                    model.Title = "Requisitos Legais";
                    model.Filters = new List<string>() { "CompanyId", "SegmentoId", "EsferaId", "CompanyLawApplicationTypeExternalCode", "LawForceDate" };
                    break;
            }

            await LoadFilters();

            return View(model);
        }

        private async Task LoadFilters()
        {
            var user = await userManager.GetUserAsync(User);

            #region [Companies]
            IEnumerable<int> companyIds = new List<int>();
            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
            {
                ViewData["Companies"] = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false));
                companyIds = ((List<DTO.Company.CompanyViewModel>)ViewData["Companies"]).Select(x => x.CompanyId.Value);
            }
            else if (User.IsInRole(BLL.User.ProfileNames.Biotera))
            {
                companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.BioteraConsultor });
                ViewData["Companies"] = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).Where(x => companyIds.Any(y => y.Equals(x.CompanyId))));
            }
            else if (User.IsInRole(BLL.User.ProfileNames.Cliente))
            {
                companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(user.Id, new List<string> { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor, BLL.User.ProfileNames.ClienteOperador });
                ViewData["Companies"] = this.companyFunctions.GetDataViewModel(this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).Where(x => companyIds.Any(y => y.Equals(x.CompanyId))));
            }
            #endregion

            #region [LawTypes]
            ViewData["LawTypes"] = lawTypeFunctions.GetDataViewModel(lawTypeFunctions.GetData());
            #endregion

            #region [Orgaos]
            ViewData["Orgaos"] = orgaoFunctions.GetData().ToList();
            #endregion

            #region [Segmentos]
            ViewData["Segmentos"] = segmentoFunctions.GetData().ToList();
            #endregion

            #region [Esferas]
            ViewData["Esferas"] = esferaFunctions.GetData().ToList();
            #endregion

            #region [LawApplicationTypes]
            ViewData["LawApplicationTypes"] = lawApplicationTypeFunctions.GetData().ToList();
            #endregion

            #region [LawConclusionStatus]
            ViewData["LawConclusionStatus"] = lawConclusionStatusFunctions.GetData().ToList();
            #endregion

            #region [CompanyLawActionStatus]
            ViewData["CompanyLawActionStatus"] = companyLawActionStatusFunctions.GetData().ToList();
            #endregion

            #region [CompanyLawActionType]
            ViewData["CompanyLawActionType"] = companyLawActionTypeFunctions.GetData().ToList();
            #endregion
        }

        public IActionResult GetSupervisors(List<int> companyIds)
        {
            return Json(this.companyFunctions.GetSupervisorsByCompanyIds(companyIds).Select(x => new { x.Id, x.FirstName, x.LastName }));
        }

        public IActionResult GetResponsibles(List<int> companyIds)
        {
            return Json(this.companyFunctions.GetResponsiblesByCompanyIds(companyIds).Select(x => new { x.Id, x.FirstName, x.LastName }));
        }

        protected override void SetControlledParameters()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var simpleParameter = new AlanJuden.MvcReportViewer.NetCore.SimpleParameter() { Name = "CompanyId" };
            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
            {
                simpleParameter.Values = this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).Select(x => x.CompanyId.ToString()).ToList();
            }
            else
            {
                IEnumerable<int> companyIds = new List<int>();
                if (User.IsInRole(BLL.User.ProfileNames.Biotera))
                {
                    companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(userId, new List<string> { BLL.User.ProfileNames.BioteraConsultor, BLL.User.ProfileNames.BioteraAuditor });
                }
                else if (User.IsInRole(BLL.User.ProfileNames.Cliente))
                {
                    companyIds = this.companyUserRoleFunctions.UserCompaniesIdByRole(userId, new List<string> { BLL.User.ProfileNames.ClienteAdministrador, BLL.User.ProfileNames.ClienteSupervisor, BLL.User.ProfileNames.ClienteOperador });
                }
                simpleParameter.Values = this.companyFunctions.GetData(x => x.IsActive == true && x.IsDeleted == false).Where(x => companyIds.Any(y => y.Equals(x.CompanyId))).Select(x => x.CompanyId.ToString()).ToList();
            }
            this.ControlledParameters.Add(simpleParameter);
        }
    }
}