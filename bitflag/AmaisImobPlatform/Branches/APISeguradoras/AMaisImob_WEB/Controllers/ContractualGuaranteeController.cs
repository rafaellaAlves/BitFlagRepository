using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AMaisImob_WEB.Utils;
using System.Data.SqlClient;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Authorization;
using AMaisImob_DB.Models;
using Microsoft.AspNetCore.Internal;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using AMaisImob_WEB.Models;
using iText.Layout.Renderer;
using System.Transactions;
using Newtonsoft.Json;

namespace AMaisImob_WEB.Controllers
{
    [Authorize]
    public class ContractualGuaranteeController : Controller
    {
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.CertificateContractualFunctions certificateContractualFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.UserFunctions userFunctions;
        private readonly BLL.GuarantorProductFunctions guarantorProductFunctions;
        private readonly BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions;
        private readonly BLL.GuarantorFunctions guarantorFunctions;
        private readonly BLL.StatusTypeFunctions statusTypeFunctions;
        private readonly BLL.CertificateContractualMemberFunctions certificateContractualMemberFunctions;
        private readonly BLL.CertificateContractualListViewFunctions certificateContractualListViewFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.ResidenceTypeFunctions residenceTypeFunctions;
        private readonly BLL.CertificateContractualQuoteFunctions certificateContractualQuoteFunctions;
        private readonly BLL.CertificateContractualPolicyFileFunctions certificateContractualPolicyFileFunctions;
        private readonly BLL.CertificateContractualPendencyFileFunctions certificateContractualPendencyFileFunctions;
        private readonly BLL.CertificateContractualInstallmentFunctions certificateContractualInstallmentFunctions;
        private readonly BLL.CertificateContractualPaymentTypeFunctions certificateContractualPaymentTypeFunctions;
        private readonly BLL.MailFunctions mailFunctions;
        private readonly BLL.GuarantorIntegration.Pottencial.PottencialSeguros pottencialSeguros;
        private readonly IConfiguration configuration;

        private ICompositeViewEngine viewEngine;
        private readonly string certificateContractualPendencyPath = Path.Combine(Directory.GetCurrentDirectory(), "Archives", "CertificateContractual", "Pendency");
        private readonly string certificateContractualRefusedPath = Path.Combine(Directory.GetCurrentDirectory(), "Archives", "CertificateContractual", "Refused");
        private readonly string certificateContractualApprovedPath = Path.Combine(Directory.GetCurrentDirectory(), "Archives", "CertificateContractual", "Approved");
        private readonly string certificateContractualPolicyPath = Path.Combine(Directory.GetCurrentDirectory(), "Archives", "CertificateContractual", "Policy");
        private readonly string certificateContractualContractPath = Path.Combine(Directory.GetCurrentDirectory(), "Archives", "CertificateContractual", "Contract");

        public ContractualGuaranteeController(AMaisImob_DB.Models.AMaisImob_HomologContext context, BLL.CertificateContractualMemberFunctions certificateContractualMemberFunctions, BLL.CertificateContractualFunctions certificateContractualFunctions, UserManager<AMaisImob_DB.Models.User> userManager, ICompositeViewEngine viewEngine, BLL.ResidenceTypeFunctions residenceTypeFunctions, BLL.CertificateContractualQuoteFunctions certificateContractualQuoteFunctions, BLL.CertificateContractualPolicyFileFunctions certificateContractualApolicyFileFunctions, BLL.CertificateContractualPendencyFileFunctions certificateContractualPendencyFileFunctions, IConfiguration configuration, BLL.CertificateContractualInstallmentFunctions certificateContractualInstallmentFunctions, BLL.CertificateContractualPaymentTypeFunctions certificateContractualPaymentTypeFunctions, BLL.MailFunctions mailFunctions)
        {
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.certificateContractualFunctions = certificateContractualFunctions;
            this.userFunctions = new BLL.UserFunctions(context, userManager);
            this.userManager = userManager;
            this.guarantorProductFunctions = new BLL.GuarantorProductFunctions(context);
            this.categoryGuarantorProductTaxFunctions = new BLL.CategoryGuarantorProductTaxFunctions(context);
            this.guarantorFunctions = new BLL.GuarantorFunctions(context);
            this.certificateContractualMemberFunctions = certificateContractualMemberFunctions;
            this.statusTypeFunctions = new BLL.StatusTypeFunctions(context);
            this.certificateContractualListViewFunctions = new BLL.CertificateContractualListViewFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.viewEngine = viewEngine;
            this.residenceTypeFunctions = residenceTypeFunctions;
            this.certificateContractualQuoteFunctions = certificateContractualQuoteFunctions;
            this.certificateContractualPolicyFileFunctions = certificateContractualApolicyFileFunctions;
            this.configuration = configuration;
            this.certificateContractualPendencyFileFunctions = certificateContractualPendencyFileFunctions;
            this.certificateContractualInstallmentFunctions = certificateContractualInstallmentFunctions;
            this.certificateContractualPaymentTypeFunctions = certificateContractualPaymentTypeFunctions;
            this.mailFunctions = mailFunctions;
            this.pottencialSeguros = pottencialSeguros;
        }

        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }

        private async Task SendNewContractualGuaranteeAnalyseEmail(int id)
        {
            ViewData["EmailReceiver"] = configuration.GetValue<string>("ContractualGuaranteeAnalyse:Name");
            var entity = certificateContractualFunctions.GetDataByID(id);
            var html = await RenderPartialViewToString("NewContractualGuaranteeAnalyseEmail", entity);

            await mailFunctions.SendAsync("Uma garantia contratual entrou para análise - AmaisImob", html, new List<string> { configuration.GetValue<string>("ContractualGuaranteeAnalyse:Email") }, null);
        }

        #region [PAGES]
        public async Task<IActionResult> Index(int statusId, string reference, string message, int companyId)
        {
            if (!string.IsNullOrWhiteSpace(message))
                ViewData["AcceptRealEstateMessage"] = message;



            //COMBO PARA SELECIONAR ID CORRETO DE CORRETOR OU IMOBILIARIA

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateAgencyId).ToList();
            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    ViewData["UserRealEstateAgencyId"] = companyUser.CompanyId;
                }
            }
            else if (User.IsInRealEstate())
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    var userRealEstateAgencyId = companyFunctions.GetDataByID(companyUser.CompanyId).ParentCompanyId;
                    ViewData["UserRealEstateAgencyId"] = userRealEstateAgencyId;
                }
            }

            if (!string.IsNullOrWhiteSpace(reference) && Request.Query.ContainsKey("saved"))
            {
                TempData["SavedMessage"] = $"Os dados foram salvos com sucesso para a referencia #<b>{reference}</b>";
            }

            return await Task.Run(() => View(statusId));
        }
        public async Task<IActionResult> New(int? realEstateAgencyId, int? realEstateId) => await Task.Run(() => RedirectToAction("Index", new { statusId = 1, realEstateId, realEstateAgencyId }));
        public async Task<IActionResult> Active(int? realEstateAgencyId, int? realEstateId) => await Task.Run(() => RedirectToAction("Index", new { statusId = 2, realEstateId, realEstateAgencyId }));
        public async Task<IActionResult> Inactive(int? realEstateAgencyId, int? realEstateId) => await Task.Run(() => RedirectToAction("Index", new { statusId = 3, realEstateId, realEstateAgencyId }));
        //public async Task<IActionResult> ApprovedOrReprovedEmail(int id) => await Task.Run(() => View(certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id))));
        //public async Task<IActionResult> DevolutionEmail(int id) => await Task.Run(() => View(certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id))));
        public async Task<IActionResult> Manage(int? id)
        {
            if (!id.HasValue) return await Task.Run(() => View(id));

            var entity = certificateContractualFunctions.GetDataByID(id);

            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser == null) return await Task.Run(() => Forbid());
                if (companyUser.CompanyId != entity.RealEstateAgencyId) return await Task.Run(() => Forbid());

                return await Task.Run(() => View(id));
            }
            else if (User.IsInRealEstate() || User.IsInRole("ImobiliariaVendas"))
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser == null) return await Task.Run(() => Forbid());
                if (companyUser.CompanyId != entity.RealEstateId) return await Task.Run(() => Forbid());

                return await Task.Run(() => View(id));
            }

            return await Task.Run(() => View(id));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            return await Task.Run(() => RedirectToAction("Manage", new { id, editable = true }));
        }
        public async Task<IActionResult> AnalyzeCertificate(int id)
        {

            var model = new Models.ContractualContractualCertificateViewModel();
            model.CertificateContractual = certificateContractualListViewFunctions.GetDataViewModel(certificateContractualListViewFunctions.GetDataByID(id));
            model.CategoryGuarantorProductTaxIds = new List<int> { model.CertificateContractual.CategoryGuarantorProductTaxId.Value };
            model.Print = true;

            ViewData["OnlyReadable"] = true;

            return await Task.Run(() => View(model));
        }
        public async Task<IActionResult> PriceQuoteCertificate(int id, List<int> categoryGuarantorProductTaxIds)
        {
            var model = new Models.ContractualContractualCertificateViewModel();
            model.CertificateContractual = certificateContractualListViewFunctions.GetDataViewModel(certificateContractualListViewFunctions.GetDataByID(id));
            model.CategoryGuarantorProductTaxIds = categoryGuarantorProductTaxIds;
            model.Print = true;

            ViewData["OnlyReadable"] = true;

            return await Task.Run(() => View(model));
        }
        #endregion

        #region [COMPONENTS]
        public async Task<IActionResult> ContractualGuaranteeIndexComponent(int statusId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.ContractualGuarantee.ContractualGuaranteeIndexViewComponent), new { statusId }));
        public async Task<IActionResult> ContractualGuaranteeManageComponent(int? id)
        {
            Models.CertificateContractualViewModel model = new Models.CertificateContractualViewModel();
            if (id.HasValue)
                model = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            ViewData["Corretoras"] = companyFunctions.GetData(x => x.CompanyTypeId == 1 && !x.IsDeleted).ToList();
            ViewData["GuarantorProduct"] = guarantorProductFunctions.GetData().ToList();
            ViewData["Guarantor"] = guarantorFunctions.GetData().ToList();

            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(User);

                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    ViewData["UserRealEstateAgencyId"] = companyUser.CompanyId;
                }
            }
            else if (User.IsInRealEstate() || User.IsInRole("ImobiliariaVendas"))
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    var userRealEstate = companyFunctions.GetDataByID(companyUser.CompanyId);
                    ViewData["UserRealEstateAgencyId"] = userRealEstate.ParentCompanyId;
                    ViewData["UserRealEstateId"] = userRealEstate.CompanyId;
                }
            }


            return ViewComponent(typeof(ViewComponents.ContractualGuarantee.ContractualGuaranteeManageViewComponent), new { model = model });
        }
        public async Task<IActionResult> LoadCategoryGuarantorProductTaxItems(int? categoryId, string price, int? residenceTypeId, int? guarantorProductId, int? categoryGuarantorProductTaxId, string rentAndChargesPrice)
        {
            if (categoryGuarantorProductTaxId.HasValue)
            {
                return await Task.Run(() => ViewComponent(typeof(ViewComponents.CategoryGuarantorProductTax.CategoryGuarantorProductTaxItemsViewComponent), new { ids = new List<int> { categoryGuarantorProductTaxId.Value }, price }));
            }

            var ids = await certificateContractualQuoteFunctions.GetAvailableCategoryGuarantorProductTaxIds(categoryId, residenceTypeId, guarantorProductId, price.FromDecimalPtBR(), rentAndChargesPrice.FromDecimalPtBR());

            return await Task.Run(() => ViewComponent(typeof(ViewComponents.CategoryGuarantorProductTax.CategoryGuarantorProductTaxItemsViewComponent), new { ids, price }));
        }
        public async Task<IActionResult> CategoryGuarantorProctTaxItemsTable(int certificateContractualId)
        {
            return await Task.Run(() => ViewComponent(typeof(ViewComponents.CategoryGuarantorProductTax.CategoryGuarantorProctTaxItemsTableViewComponent), new { certificateContractualId }));
        }
        public async Task<IActionResult> LoadCertificateContractualPolicyFileListViewComponent(int certificateContractualId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.ContractualGuarantee.File.CertificateContractualPolicyFileListViewComponent), new { certificateContractualId }));
        public async Task<IActionResult> LoadCertificateContractualPendencyFileListViewComponent(int certificateContractualId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.ContractualGuarantee.File.CertificateContractualPendencyFileListViewComponent), new { certificateContractualId }));
        public async Task<IActionResult> LoadCertificateContractualInstallmentViewComponent(int certificateContractualId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.CertificateContractualInstallment.CertificateContractualInstallmentViewComponent), new { certificateContractualId }));
        #endregion

        #region [XHR]

        private void GetListFilter(int statusId, int userId, string search, int? realEstateAgencyId, int? realEstateId, bool priceQuoteStatus, bool approvedStatus, bool refusedStatus, bool analyzeStatus, bool pendencyStatus, bool waitingEmissionStatus, bool issuedStatus, bool endOfTermStatus, bool cancelStatus, ref string query, ref List<SqlParameter> parameters)
        {
            var cotacaoId = statusTypeFunctions.GetByExternalCode("COTACAO").StatusTypeId;
            var aprovadoId = statusTypeFunctions.GetByExternalCode("APROVADO").StatusTypeId;
            var recusadoId = statusTypeFunctions.GetByExternalCode("RECUSADO").StatusTypeId;
            var analiseId = statusTypeFunctions.GetByExternalCode("ANALISE").StatusTypeId;
            var pendenciaId = statusTypeFunctions.GetByExternalCode("PENDENCIA").StatusTypeId;
            var aguardandoEmissaoId = statusTypeFunctions.GetByExternalCode("AGUARDANDOEMISSAO").StatusTypeId;
            var contratadoId = statusTypeFunctions.GetByExternalCode("CONTRATADO").StatusTypeId;

            List<int> statusTypeIds = new List<int>();

            switch (statusId)
            {
                case (int)ContractualGuaranteeTypes.New:
                    if (priceQuoteStatus) statusTypeIds.Add(cotacaoId);
                    if (approvedStatus) statusTypeIds.Add(aprovadoId);
                    if (refusedStatus) statusTypeIds.Add(recusadoId);
                    if (analyzeStatus) statusTypeIds.Add(analiseId);
                    if (pendencyStatus) statusTypeIds.Add(pendenciaId);

                    query += $"IsDeleted = 0 AND OutOfVigency = 0{(statusTypeIds.Count > 0 ? $" AND StatusTypeId IN ({string.Join(",", statusTypeIds)})" : "AND StatusTypeId = 0")}";

                    break;
                case (int)ContractualGuaranteeTypes.Active:

                    //query += $"IsDeleted = 0 AND OutOfVigency = 0 AND StatusTypeId IN ({string.Join(",", statusTypeFunctions.GetByExternalCode("AGUARDANDOEMISSAO", "CONTRATADO").Select(x => x.StatusTypeId))})";

                    if (waitingEmissionStatus) statusTypeIds.Add(aguardandoEmissaoId);
                    if (issuedStatus) statusTypeIds.Add(contratadoId);

                    query += $"IsDeleted = 0 AND OutOfVigency = 0{(statusTypeIds.Count > 0 ? $" AND StatusTypeId IN ({string.Join(",", statusTypeIds)})" : "AND StatusTypeId = 0")}";

                    break;
                case (int)ContractualGuaranteeTypes.Inactive:

                    if (!cancelStatus && !endOfTermStatus)
                    {
                        query += $"(IsDeleted = 0 and OutOfVigency = 1) AND StatusTypeId = 0";
                        break;
                    }

                    if (!cancelStatus && endOfTermStatus)
                        query += $"(IsDeleted = 0 and OutOfVigency = 1) AND StatusTypeId = @StatusTypeId";

                    else if (!endOfTermStatus && cancelStatus)
                        query += $"(IsDeleted = 1) AND StatusTypeId = @StatusTypeId";

                    else if (endOfTermStatus && cancelStatus)
                        query += $"(IsDeleted = 1 OR OutOfVigency = 1) AND StatusTypeId = @StatusTypeId";

                    // retorna condição inexistente 
                    else
                        query += $"(IsDeleted = null and OutOfVigency = 1) AND StatusTypeId = @StatusTypeId";

                    parameters.Add(new SqlParameter("StatusTypeId", statusTypeFunctions.GetByExternalCode("CONTRATADO").StatusTypeId));
                    break;


                    
            }

            if (realEstateAgencyId.HasValue && (User.IsInRole("Corretor") || User.IsInRole("Administrator")))//Filtro vindo da tela home
            {
                if (User.IsInRole("Corretor"))
                {
                    var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                    if (realEstateAgencyId == companyUser.CompanyId) // verifica se o corretor tem acesso a imobiliria informada
                    {
                        query += $" AND RealEstateAgencyId = @RealEstateAgencyId";
                        parameters.Add(new SqlParameter("RealEstateAgencyId", realEstateAgencyId));
                    }
                }
                else
                {
                    query += $" AND RealEstateAgencyId = @RealEstateAgencyId";
                    parameters.Add(new SqlParameter("RealEstateAgencyId", realEstateAgencyId));
                }
            }

            if (realEstateId.HasValue && (User.IsInRole("Corretor") || User.IsInRole("Administrator")))//Filtro vindo da tela home
            {
                if (User.IsInRole("Corretor"))
                {
                    var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();
                    var realState = companyFunctions.GetDataByID(realEstateId);

                    if (realState.ParentCompanyId == companyUser.CompanyId) // verifica se o corretor tem acesso a imobiliria informada
                    {
                        query += $" AND RealEstateId = @RealEstateId";
                        parameters.Add(new SqlParameter("RealEstateId", realEstateId));
                    }
                }
                else
                {
                    query += $" AND RealEstateId = @RealEstateId";
                    parameters.Add(new SqlParameter("RealEstateId", realEstateId));
                }
            }

            if (User.IsInRole("ImobiliariaVendas"))
            {
                query += " AND CreatedBy = @CreatedBy";
                parameters.Add(new SqlParameter("CreatedBy", userId));
            }
            else if (User.IsInRealEstate())
            {
                var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                query += " AND RealEstateId = @RealEstateId";
                parameters.Add(new SqlParameter("RealEstateId", companyUser.CompanyId));
            }
            else if (!realEstateAgencyId.HasValue && User.IsInRole("Corretor"))
            {
                var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                query += " AND RealEstateAgencyId = @RealEstateAgencyId";
                parameters.Add(new SqlParameter("RealEstateAgencyId", companyUser.CompanyId));
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                query += " AND (Reference LIKE '%' + @Search + '%' OR ClientFullName LIKE '%' + @Search + '%' OR CPFCNPJ LIKE '%' + @Search + '%' OR GuarantorName LIKE '%' + @Search + '%' OR GuarantorProductName LIKE '%' + @Search + '%' OR Aluguel LIKE '%' + @Search + '%' OR PaymentWayName LIKE '%' + @Search + '%' OR TotalPrice LIKE '%' + @Search + '%' OR PaymentTypeName LIKE '%' + @Search + '%' )";
                parameters.Add(new SqlParameter("@Search", search));
            }

        }
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int? statusId, string search, int? realEstateAgencyId, int? realEstateId, bool priceQuoteStatusId, bool approvedStatusId, bool refusedStatusId, bool analyzeStatusId, bool pendencyStatusId, bool waitingEmissionStatusId, bool issuedStatusId, bool renewStatusId, bool endOfTermStatusId, bool cancelStatusId, bool notRenewedStatus)
        {
            var query = "";
            var parameters = new List<SqlParameter>();
            var user = await userManager.GetUserAsync(User);

            GetListFilter((int)statusId, user.Id, search, realEstateAgencyId, realEstateId, priceQuoteStatusId, approvedStatusId, refusedStatusId, analyzeStatusId, pendencyStatusId, waitingEmissionStatusId, issuedStatusId, endOfTermStatusId, cancelStatusId, ref query, ref parameters);

            var d = this.certificateContractualListViewFunctions.GetDataViewModel(this.certificateContractualListViewFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, parameters.ToArray()));


            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }
        [HttpPost]
        public async Task<IActionResult> GetTotalPriceFromList(Models.DataTablesAjaxPostModel filter, int statusId, string search, int? realEstateAgencyId, int? realEstateId, bool priceQuoteStatusId, bool approvedStatusId, bool refusedStatusId, bool analyzeStatusId, bool pendencyStatusId, bool waitingEmissionStatusId, bool issuedStatusId, bool renewStatusId, bool endOfTermStatusId, bool cancelStatusId, bool notRenewedStatus)
        {
            var query = "";
            var parameters = new List<SqlParameter>();
            var user = await userManager.GetUserAsync(User);

            GetListFilter(statusId, user.Id, search, realEstateAgencyId, realEstateId, priceQuoteStatusId, approvedStatusId, refusedStatusId, analyzeStatusId, pendencyStatusId, waitingEmissionStatusId, issuedStatusId, endOfTermStatusId, cancelStatusId, ref query, ref parameters);

            var d = this.certificateContractualListViewFunctions.GetTotalGetTotalPriceFromList(filter, query, parameters.ToArray());

            return await Task.Run<IActionResult>(() => Json(new { value = d, formatedValue = d.ToPtBR() }));
        }

        [HttpPost]
        public async Task<IActionResult> GetStatusFromList(Models.DataTablesAjaxPostModel filter, int statusId, string search, int? realEstateAgencyId, int? realEstateId, bool priceQuoteStatusId, bool approvedStatusId, bool refusedStatusId, bool analyzeStatusId, bool pendencyStatusId, bool waitingEmissionStatusId, bool issuedStatusId, bool renewStatusId, bool endOfTermStatusId, bool cancelStatusId, bool notRenewedStatus)
        {
            var query = "";
            var parameters = new List<SqlParameter>();
            var user = await userManager.GetUserAsync(User);

            GetListFilter(statusId, user.Id, search, realEstateAgencyId, realEstateId, priceQuoteStatusId, approvedStatusId, refusedStatusId, analyzeStatusId, pendencyStatusId, waitingEmissionStatusId, issuedStatusId, endOfTermStatusId, cancelStatusId, ref query, ref parameters);

            var d = this.certificateContractualListViewFunctions.GetDataViewModel(this.certificateContractualListViewFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, parameters.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }


        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(Models.CertificateContractualViewModel model, List<Models.CertificateContractualMemberViewModel> members, bool changeBasicValues)
        {
            try
            {
                // var _user = await userManager.GetUserAsync(User);
                var cotacaoStatusId = statusTypeFunctions.GetByExternalCode("COTACAO").StatusTypeId;
                var analiseStatusId = statusTypeFunctions.GetByExternalCode("ANALISE").StatusTypeId;

                if (changeBasicValues)
                {
                    model.CertificateContractualId = null;
                    model.StatusTypeId = cotacaoStatusId;
                    model.CategoryGuarantorProductTaxId = null;
                }

                Utils.DBActionType dbActionType = model.CertificateContractualId != null ? Utils.DBActionType.UPDATE : Utils.DBActionType.CREATE;

                if (dbActionType == DBActionType.CREATE)
                {
                    model.CreatedBy = (await userManager.GetUserAsync(User)).Id;
                    try
                    {
                        model.GuarantorProductId = guarantorProductFunctions.GetDataByExternalCode("BASICO").GuarantorProductId;
                    }
                    catch { }
                }

                if (!model.CertificateContractualId.HasValue)
                {
                    model.Reference = Utils.ReferenceUtils.GetReference();

                    #region [Atribuindo Status]
                    if (!model.CategoryGuarantorProductTaxId.HasValue && !model.CertificateContractualId.HasValue)
                    {
                        model.StatusTypeId = cotacaoStatusId;
                    }
                    #endregion
                }

                if (model.CategoryGuarantorProductTaxId.HasValue && model.StatusTypeId == cotacaoStatusId)
                {
                    model.StatusTypeId = analiseStatusId;
                    model.PriceQuote = (categoryGuarantorProductTaxFunctions.GetDataByID(model.CategoryGuarantorProductTaxId).TaxaMes * model.Aluguel / 100d);

                    await SendNewContractualGuaranteeAnalyseEmail(model.CertificateContractualId.Value);
                }

                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var certificateContractualId = certificateContractualFunctions.CreateOrUpdate(model);

                    certificateContractualMemberFunctions.DeleteByCertificateContractualId(certificateContractualId);
                    members.ForEach(x => x.CertificateContractualId = certificateContractualId);
                    certificateContractualMemberFunctions.CreateRange(members);

                    if (dbActionType == DBActionType.CREATE)
                    {
                        var realState = companyFunctions.GetDataByID(model.RealEstateId);

                        //Salva as cotações disponiveis no momento
                        var ids = await certificateContractualQuoteFunctions.GetAvailableCategoryGuarantorProductTaxIds(realState.CategoryId, model.ResidenceTypeId, model.GuarantorProductId);

                        certificateContractualQuoteFunctions.CreateRange(ids.Select(x => new CertificateContractualQuote
                        {
                            CertificateContractualId = certificateContractualId,
                            CategoryGuarantorProductTaxId = x
                        }));
                    }

                    transactionScope.Complete();

                    return Json(
                        new
                        {
                            hasError = false,
                            id = certificateContractualId,
                            reference = model.Reference,
                            requestAnalyse = model.StatusTypeId == analiseStatusId,
                            creation = dbActionType == DBActionType.CREATE,
                            //statusId = (model.StatusTypeId == contractedStatusId ? (int)Utils.ContractualGuaranteeTypes.Active : (int)Utils.ContractualGuaranteeTypes.New),
                        });
                }


            }
            catch (Exception ex)
            {
                return Json(new { hasError = true });
            }

        }
        public async Task<IActionResult> RemoveContractualGuarantee(int id)
        {
            certificateContractualFunctions.Delete(id);

            return await Task.Run<IActionResult>(() => Json(new
            {
                hasError = false,
                message = "Garantia Contratual removida com sucesso!"
            }));
        }
        public async Task<IActionResult> CloneContractualGuarantee(int id)
        {
            var userId = (await userManager.GetUserAsync(User)).Id;
            var clone = await certificateContractualFunctions.Clone(id, userId);

            return await Task.Run<IActionResult>(() => RedirectToAction("Manage", new { id = clone.CertificateContractualId, cloned = true }));
        }
        public IActionResult GetPrice(Models.CertificateContractualViewModel model)
        {
            if (model.CertificateContractualId == null) return Forbid();


            var x = categoryGuarantorProductTaxFunctions.GetTaxas(model.CategoryId.Value);


            return Json(x);
        }
        public async Task<IActionResult> SaveStatus(int certId, int? statusId, int? paymentWayId, DateTime? vigenceEndDate, string devolutionReason, string pendencyDescription)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            var certificadoContratual = certificateContractualFunctions.GetDataByID(certId);

            string returnMessage = "Um novo status foi atríbuido para o certificado.";

            if (statusId.HasValue)
            {
                var approvedStatusId = statusTypeFunctions.GetByExternalCode("APROVADO").StatusTypeId;
                var refusedStatusId = statusTypeFunctions.GetByExternalCode("RECUSADO").StatusTypeId;
                var contractedStatusId = statusTypeFunctions.GetByExternalCode("CONTRATADO").StatusTypeId;
                var waitingEmissionId = statusTypeFunctions.GetByExternalCode("AGUARDANDOEMISSAO").StatusTypeId;
                var devolutionStatusId = statusTypeFunctions.GetByExternalCode("DEVOLUCAO").StatusTypeId;
                var pendencyStatusId = statusTypeFunctions.GetByExternalCode("PENDENCIA").StatusTypeId;

                dynamic r = null;
                if (approvedStatusId == statusId) r = await _InsertApprovedFile(certId);
                if (refusedStatusId == statusId) r = await _InsertRefusedFile(certId);
                if (contractedStatusId == statusId) r = await _InsertPolicyFile(certId);
                if (waitingEmissionId == statusId) r = await _InsertContractFile(certId);

                if (r != null && r.hasError == true) return await Task.Run(() => Json(r));

                certificateContractualFunctions.SetStatus(certId, statusId.Value);

                if (approvedStatusId == statusId || refusedStatusId == statusId) //No caso de aprovação ou recusa é enviado um e-mail
                {
                    var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certId));
                    certificate.StatusTypeId = statusId.Value;
                    var html = await RenderPartialViewToString("ApprovedOrReprovedEmail", certificate);
                    var emailToSend = new List<string>();

                    if (certificate.CreatedBy.HasValue)
                    {
                        var createdBy = userFunctions.GetDataByID(certificate.CreatedBy);
                        emailToSend.Add(createdBy.Email);
                    }

                    emailToSend.AddRange((await userCompanyFunctions.GetRealEstateAdministratorUser(certificate.RealEstateId.Value)).Select(x => x.Email));
                    emailToSend.AddRange((await userCompanyFunctions.GetUsersByCompanyId(certificate.RealEstateId.Value)).Select(x => x.Email));

                    var categoryGuarantorProductTax = categoryGuarantorProductTaxFunctions.GetDataByID(certificate.CategoryGuarantorProductTaxId);
                    var guarantor = guarantorFunctions.GetDataByID(categoryGuarantorProductTax.GuarantorId);

                    await mailFunctions.SendAsync($"PROCESSO {certificate.Reference} – {certificate.ClientFullName} – {(approvedStatusId == statusId ? "APROVADO" : "RECUSADO")} - {guarantor.RazaoSocial}", html, null, null, false, null, emailToSend.Distinct());
                }

                if (statusId == devolutionStatusId)
                {
                    await certificateContractualFunctions.Devolution(certId, devolutionReason);

                    await SendDevolutionEmail(certId);//No caso de Devolução é enviado um e-mail

                    var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certId));

                    if (!string.IsNullOrWhiteSpace(certificate.ContractFileGUID))
                    {
                        certificate.ContractFileGUID = null;
                        certificate.ContractFileMimeType = null;
                        certificate.ContractFileGUID = null;

                        await certificateContractualFunctions.UpdateContractFile(certificate);

                        var path = Path.Combine(certificateContractualContractPath, certificate.ContractFileGUID);
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                    }

                }
                if (statusId == pendencyStatusId)
                {
                    await certificateContractualFunctions.SetPendency(certId, pendencyDescription);

                    //await SendPendencyEmail(certId);//No caso de status de "Pendência" é enviado um e-mail
                }
                if (statusId == waitingEmissionId)
                {
                    await SendContractFileEmail(certId);//No caso de status de "Aguardando Emissão" é enviado um e-mail
                }

                if (statusId == contractedStatusId)
                {
                    await certificateContractualFunctions.Contract(certId, paymentWayId, vigenceEndDate);

                    await SendPolicyFileEmail(certId, (int)r.id);//No caso de status de "Apólice" é enviado um e-mail
                }

                if (statusId == approvedStatusId) returnMessage = "O status foi definido como Aprovado e um e-mail foi enviado aos envolvidos.";
                else if (statusId == refusedStatusId) returnMessage = "O status foi definido como Reprovado e um e-mail foi enviado aos envolvidos.";
                else if (statusId == devolutionStatusId) returnMessage = "O status foi definido como Devolução e um e-mail foi enviado aos envolvidos.";
                else if (statusId == waitingEmissionId) returnMessage = "O status foi definido como Aguardando Emissão e um e-mail foi enviado.";
                else if (statusId == contractedStatusId) returnMessage = "O status foi definido como Emitido e um e-mail foi enviado aos envolvidos.";
                //else if (statusId == pendencyStatusId) returnMessage = "O status foi definido como Pendente e um e-mail foi enviado aos envolvidos solicitando os documentos informados.";
            }

            return Json(new { hasError = false, message = returnMessage });
        }
        public async Task SendDevolutionEmail(int certId)
        {
            var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certId));

            var html = await RenderPartialViewToString("DevolutionEmail", certificate);
            var emailToSend = await GetAllEmailFromCertificate(certId);

            var categoryGuarantorProductTax = categoryGuarantorProductTaxFunctions.GetDataByID(certificate.CategoryGuarantorProductTaxId);
            var guarantor = guarantorFunctions.GetDataByID(categoryGuarantorProductTax.GuarantorId);

            await mailFunctions.SendAsync($"DEVOLUÇÃO {certificate.Reference} – {certificate.ClientFullName} - {guarantor.RazaoSocial}", html, null, null, false, null, emailToSend.Distinct());
        }
        public async Task SendPendencyEmail(int certId, string pendencyDescription = null)
        {
            await certificateContractualFunctions.SetPendency(certId, pendencyDescription);
            certificateContractualFunctions.SetStatus(certId, statusTypeFunctions.GetByExternalCode("PENDENCIA").StatusTypeId);

            var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certId));

            var html = await RenderPartialViewToString("PendencyEmail", certificate);
            var emailToSend = await GetAllEmailFromCertificate(certId, false);

            var categoryGuarantorProductTax = categoryGuarantorProductTaxFunctions.GetDataByID(certificate.CategoryGuarantorProductTaxId);
            var guarantor = guarantorFunctions.GetDataByID(categoryGuarantorProductTax.GuarantorId);

            await mailFunctions.SendAsync($"PENDÊNCIA {certificate.Reference} – {certificate.ClientFullName} - {guarantor.RazaoSocial}", html, null, null, false, null, emailToSend.Distinct());
        }
        public async Task SendContractFileEmail(int certId)
        {
            var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certId));

            var html = await RenderPartialViewToString("ContractSendedEmail", certificate);
            var emailToSend = new List<string> { configuration.GetValue<string>("ContractualGuaranteeContract:Email") };

            var categoryGuarantorProductTax = categoryGuarantorProductTaxFunctions.GetDataByID(certificate.CategoryGuarantorProductTaxId);
            var guarantor = guarantorFunctions.GetDataByID(categoryGuarantorProductTax.GuarantorId);

            var path = Path.Combine(certificateContractualContractPath, certificate.ContractFileGUID);

            await mailFunctions.SendAsync($"CONTRATO {certificate.Reference} – {certificate.ClientFullName} - {guarantor.RazaoSocial}", html, emailToSend.Distinct(), new List<System.Net.Mail.Attachment> { new System.Net.Mail.Attachment(new MemoryStream(System.IO.File.ReadAllBytes(path)), $"{certificate.ContractFileName}{System.IO.Path.GetExtension(certificate.ContractFileGUID)}", certificate.ContractFileMimeType) });
        }
        public async Task SendPolicyFileEmail(int certId, int fileId)
        {
            var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(certId));
            var file = certificateContractualPolicyFileFunctions.GetDataByID(fileId);

            var html = await RenderPartialViewToString("PolicySendedEmail", certificate);
            var emailToSend = await GetAllEmailFromCertificate(certId);

            var categoryGuarantorProductTax = categoryGuarantorProductTaxFunctions.GetDataByID(certificate.CategoryGuarantorProductTaxId);
            var guarantor = guarantorFunctions.GetDataByID(categoryGuarantorProductTax.GuarantorId);

            var path = Path.Combine(certificateContractualPolicyPath, file.FileGUID);

            await mailFunctions.SendAsync($"APÓLICE {certificate.Reference} – {certificate.ClientFullName} - {guarantor.RazaoSocial}", html, null, new List<System.Net.Mail.Attachment> { new System.Net.Mail.Attachment(new MemoryStream(System.IO.File.ReadAllBytes(path)), $"{file.FileName}{System.IO.Path.GetExtension(file.FileGUID)}", file.FileMimeType) }, false, null, emailToSend.Distinct());
        }
        public async Task SendPendencyFilesEmail(int id)
        {
            var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            var html = await RenderPartialViewToString("PendencyFilesEmail", certificate);

            var files = new List<System.Net.Mail.Attachment>();

            foreach (var item in certificateContractualPendencyFileFunctions.GetDataAsNoTracking(x => x.CertificateContractualId == id))
            {
                var path = Path.Combine(certificateContractualPendencyPath, item.FileGUID);
                if (!System.IO.File.Exists(path)) continue;

                files.Add(new System.Net.Mail.Attachment(new MemoryStream(System.IO.File.ReadAllBytes(path)), $"{item.FileName}", item.FileMimeType));
            }

            await mailFunctions.SendAsync($"ARQUIVOS DE PENDÊNCIA {certificate.Reference} – {certificate.ClientFullName}", html, new List<string>() { configuration.GetValue<string>("ContractualGuaranteeContract:Email") }, files);

            certificateContractualFunctions.SetStatus(id, statusTypeFunctions.GetByExternalCode("ANALISE").StatusTypeId);
        }
        public async Task<IActionResult> UpdateVigenceDate(int id, DateTime vigenceDate, DateTime vigenceEndDate)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            await certificateContractualFunctions.UpdateVigenceDate(id, vigenceDate, vigenceEndDate);
            return Json(new { hasError = false, message = "Dados salvos com sucesso!" });
        }
        public async Task<IActionResult> UpdateInstallmentPrice(int id, string price)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            await certificateContractualFunctions.UpdateInstallmentPrice(id, price.FromDoublePtBR());
            return Json(new { hasError = false, message = "Dados salvos com sucesso!" });
        }
        public async Task<IActionResult> UpdateInstallmentCount(int id, int installmentCount)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            await certificateContractualFunctions.UpdateInstallmentCount(id, installmentCount);
            return Json(new { hasError = false, message = "Dados salvos com sucesso!" });
        }
        public async Task<IActionResult> UpdatePaymentWay(int id, int paymentWayId)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            await certificateContractualFunctions.UpdatePaymentWay(id, paymentWayId);
            return Json(new { hasError = false, message = "Forma de pagamento atualizado." });
        }
        public async Task SaveGuarantorProductId(int certificateContractualId, int guarantorProductId)
        {
            var entity = certificateContractualFunctions.GetDataByID(certificateContractualId);

            var realState = companyFunctions.GetDataByID(entity.RealEstateId);

            //Salva as cotações disponiveis no momento
            var ids = await certificateContractualQuoteFunctions.GetAvailableCategoryGuarantorProductTaxIds(realState.CategoryId, entity.ResidenceTypeId, guarantorProductId);
            certificateContractualQuoteFunctions.DeleteByCertificateContractualId(certificateContractualId);
            certificateContractualQuoteFunctions.CreateRange(ids.Select(x => new CertificateContractualQuote
            {
                CertificateContractualId = certificateContractualId,
                CategoryGuarantorProductTaxId = x
            }));

            await certificateContractualFunctions.SaveGuarantorProductId(certificateContractualId, guarantorProductId);
        }

        #region [FILES]
        public async Task<IActionResult> DownloadPriceQuoteCertificate(int id, List<int> categoryGuarantorProductTaxIds)
        {
            var model = new Models.ContractualContractualCertificateViewModel();
            model.CertificateContractual = certificateContractualListViewFunctions.GetDataViewModel(certificateContractualListViewFunctions.GetDataByID(id));
            model.CategoryGuarantorProductTaxIds = categoryGuarantorProductTaxIds;

            ViewData["OnlyReadable"] = true;

            var html = await RenderPartialViewToString("PriceQuoteCertificate", model);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(html, stream);

            return File(stream.ToArray(), "application/pdf", $"Certificado_Cotacao_{model.CertificateContractual.Reference}.pdf");
        }
        public async Task<IActionResult> DownloadAnalyzeCertificate(int id)
        {
            var model = new Models.ContractualContractualCertificateViewModel();
            model.CertificateContractual = certificateContractualListViewFunctions.GetDataViewModel(certificateContractualListViewFunctions.GetDataByID(id));
            model.CategoryGuarantorProductTaxIds = new List<int> { model.CertificateContractual.CategoryGuarantorProductTaxId.Value };

            ViewData["OnlyReadable"] = true;

            var html = await RenderPartialViewToString("AnalyzeCertificate", model);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(html, stream);

            return File(stream.ToArray(), "application/pdf", $"Certificado_Ficha de Análise_{model.CertificateContractual.Reference}.pdf");
        }

        public async Task<IActionResult> InsertRefusedFile([FromForm] int id)
        {
            if (!User.IsInRole("Administrator")) return await Task.Run(() => Forbid());

            var r = await _InsertRefusedFile(id);

            return await Task.Run(() => Json(r));
        }
        public async Task<IActionResult> InsertApprovedFile([FromForm] int id)
        {
            if (!User.IsInRole("Administrator")) return await Task.Run(() => Forbid());

            var r = await _InsertApprovedFile(id);

            return await Task.Run(() => Json(r));
        }

        public async Task<IActionResult> InsertPolicyFile([FromForm] int id, string name)
        {
            if (!User.IsInRole("Administrator")) return await Task.Run(() => Forbid());
            var r = await _InsertPolicyFile(id, name);

            //if (r != null && r.hasError == false)
            //{
            //    var certificate = certificateContractualFunctions.GetDataByID(id);
            //    if (certificate.StatusTypeId == statusTypeFunctions.GetByExternalCode("CONTRATADO").StatusTypeId)
            //        certificateContractualFunctions.SetStatus(id, statusTypeFunctions.GetByExternalCode("EMITIDO").StatusTypeId);
            //}

            return await Task.Run(() => Json(r));
        }

        public async Task<IActionResult> InsertPendencyFile([FromForm] int id, string name)
        {
            var r = await _InsertPendencyFile(id, name);

            return await Task.Run(() => Json(r));
        }
        public async Task<IActionResult> InsertContractFile([FromForm] int id)
        {
            var r = await _InsertContractFile(id);

            if (r != null && r.hasError == false)
            {
                await SendContractFileEmail(id);

                var certificate = certificateContractualFunctions.GetDataByID(id);
                if (certificate.StatusTypeId == statusTypeFunctions.GetByExternalCode("APROVADO").StatusTypeId)
                    certificateContractualFunctions.SetStatus(id, statusTypeFunctions.GetByExternalCode("AGUARDANDOEMISSAO").StatusTypeId);
            }

            return await Task.Run(() => Json(r));
        }

        public async Task<dynamic> _InsertRefusedFile(int id)
        {
            if (!Directory.Exists(certificateContractualRefusedPath)) Directory.CreateDirectory(certificateContractualRefusedPath);

            var model = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." });

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." });
                }
                if (archive.FileName != "")
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo inválido." });
                }
            }
            #endregion

            try
            {
                model.RefusedFileGUID = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(certificateContractualRefusedPath, model.RefusedFileGUID);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                model.RefusedFileName = archive.FileName;
                model.RefusedFileMimeType = archive.ContentType;

                await certificateContractualFunctions.UpdateRefusedFile(model);

                return await Task.Run(() => new { hasError = false });
            }
            catch { return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." }); }
        }
        public async Task<dynamic> _InsertApprovedFile(int id)
        {
            if (!Directory.Exists(certificateContractualApprovedPath)) Directory.CreateDirectory(certificateContractualApprovedPath);

            var model = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." });

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." });
                }
                if (archive.FileName != "")
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo inválido." });
                }
            }
            #endregion

            try
            {
                model.ApprovedFileGUID = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(certificateContractualApprovedPath, model.ApprovedFileGUID);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                model.ApprovedFileName = archive.FileName;
                model.ApprovedFileMimeType = archive.ContentType;

                await certificateContractualFunctions.UpdateApprovedFile(model);

                return await Task.Run(() => new { hasError = false });
            }
            catch { return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." }); }

        }
        public async Task<dynamic> _InsertPolicyFile(int id, string name = null)
        {
            if (!Directory.Exists(certificateContractualPolicyPath)) Directory.CreateDirectory(certificateContractualPolicyPath);

            var model = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." });

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." });
                }
                if (archive.FileName != "")
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo inválido." });
                }
            }
            #endregion

            try
            {
                var fileExtension = Path.GetExtension(archive.FileName);

                var policyFile = new CertificateContractualApolicyFile
                {
                    FileGUID = $"{Guid.NewGuid()}{fileExtension}",
                    CertificateContractualId = model.CertificateContractualId.Value
                };

                var filePath = Path.Combine(certificateContractualPolicyPath, policyFile.FileGUID);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                policyFile.FileName = !string.IsNullOrWhiteSpace(name) ? $"{name}{fileExtension}" : archive.FileName;
                policyFile.FileMimeType = archive.ContentType;

                policyFile.CertificateContractualApolicyFileId = certificateContractualPolicyFileFunctions.Create(policyFile);
                //await certificateContractualFunctions.UpdatePolicyFile(policyFile);

                return await Task.Run(() => new { hasError = false, id = policyFile.CertificateContractualApolicyFileId });
            }
            catch (Exception ex) { return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." }); }
        }
        public async Task<dynamic> _InsertPendencyFile(int id, string name = null)
        {
            if (!Directory.Exists(certificateContractualPendencyPath)) Directory.CreateDirectory(certificateContractualPendencyPath);

            var model = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." });

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." });
                }
                if (archive.FileName != "")
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo inválido." });
                }
            }
            #endregion

            try
            {
                var fileExtension = Path.GetExtension(archive.FileName);

                var pendencyFile = new CertificateContractualPendencyFile
                {
                    FileGUID = $"{Guid.NewGuid()}{fileExtension}",
                    CertificateContractualId = model.CertificateContractualId.Value
                };

                var filePath = Path.Combine(certificateContractualPendencyPath, pendencyFile.FileGUID);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                pendencyFile.FileName = !string.IsNullOrWhiteSpace(name) ? $"{name}{fileExtension}" : archive.FileName;
                pendencyFile.FileMimeType = archive.ContentType;

                certificateContractualPendencyFileFunctions.Create(pendencyFile);

                return await Task.Run(() => new { hasError = false });
            }
            catch { return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." }); }
        }
        public async Task<dynamic> _InsertContractFile(int id)
        {
            if (!Directory.Exists(certificateContractualContractPath)) Directory.CreateDirectory(certificateContractualContractPath);

            var model = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));

            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." });

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." });
                }
                if (archive.FileName != "")
                {
                    return await Task.Run(() => new { hasError = true, message = "Arquivo inválido." });
                }
            }
            #endregion

            try
            {
                model.ContractFileGUID = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(certificateContractualContractPath, model.ContractFileGUID);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                model.ContractFileName = archive.FileName;
                model.ContractFileMimeType = archive.ContentType;

                await certificateContractualFunctions.UpdateContractFile(model);

                return await Task.Run(() => new { hasError = false });
            }
            catch { return await Task.Run(() => new { hasError = true, message = "Houve um erro ao importar o arquivo." }); }
        }

        public async Task<IActionResult> DownloadApprovedFile(int id)
        {
            var entity = certificateContractualFunctions.GetDataByID(id);
            var path = Path.Combine(certificateContractualApprovedPath, entity.ApprovedFileGUID);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.ApprovedFileMimeType, entity.ApprovedFileName));
        }
        public async Task<IActionResult> DownloadRefusedFile(int id)
        {
            var entity = certificateContractualFunctions.GetDataByID(id);
            var path = Path.Combine(certificateContractualRefusedPath, entity.RefusedFileGUID);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.RefusedFileMimeType, entity.RefusedFileName));
        }
        public async Task<IActionResult> DownloadPolicyFile(int id)
        {
            //var entity = certificateContractualFunctions.GetDataByID(id);
            //var path = Path.Combine(certificateContractualPolicyPath, entity.PolicyFileGUID);

            //return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.PolicyFileMimeType, entity.PolicyFileName));

            var entity = certificateContractualPolicyFileFunctions.GetDataByID(id);
            var path = Path.Combine(certificateContractualPolicyPath, entity.FileGUID);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.FileMimeType, entity.FileName));
        }
        public async Task<IActionResult> DownloadPendencyFile(int id)
        {
            var entity = certificateContractualPendencyFileFunctions.GetDataByID(id);
            var path = Path.Combine(certificateContractualPendencyPath, entity.FileGUID);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.FileMimeType, entity.FileName));
        }

        public async Task<IActionResult> DownloadContractFile(int id)
        {
            var entity = certificateContractualFunctions.GetDataByID(id);
            var path = Path.Combine(certificateContractualContractPath, entity.ContractFileGUID);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.ContractFileMimeType, entity.ContractFileName));
        }

        public void RemovePolicyFile(int id)
        {
            var policyFile = certificateContractualPolicyFileFunctions.GetDataByID(id);

            var filePath = Path.Combine(certificateContractualPolicyPath, policyFile.FileGUID);

            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

            certificateContractualPolicyFileFunctions.Delete(id);
        }
        public void RemovePendencyFile(int id)
        {
            var pendencyFile = certificateContractualPendencyFileFunctions.GetDataByID(id);

            var filePath = Path.Combine(certificateContractualPendencyPath, pendencyFile.FileGUID);

            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);

            certificateContractualPendencyFileFunctions.Delete(id);
        }
        #endregion

        #region [CERTIFICATECONTRACTUALINSTALLMENT]
        public async Task<IActionResult> SaveCertificateContractualInstallment(int certificateContractualId, int paymentTypeId, int paymentTimes, string price, string date, List<CertificateContractualInstallmentViewModel> installments)
        {
            var user = await userManager.GetUserAsync(User);

            var base_date = date.FromDatePtBR();
            var d_price = price.FromDoublePtBR();
            var d_date = base_date;

            var monthlyTypeId = (await certificateContractualPaymentTypeFunctions.GetDataByExternalCode("MONTHLY")).CertificateContractualPaymentTypeId;
            if (paymentTypeId == monthlyTypeId) //No caso mensal apenas salva os dados e não gera as parcelas
            {
                await certificateContractualFunctions.UpdateInstallment(certificateContractualId, paymentTypeId, d_price.Value, base_date, paymentTimes);
                certificateContractualInstallmentFunctions.DeleteByCertificateContractual(certificateContractualId, new List<int>());

                return await Task.Run(() => Json(new { hasError = false, message = "Dados salvos com sucesso!" }));
            }

            if (!d_price.HasValue) return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao converter o Preço." }));
            if (!d_date.HasValue) return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao converter a Data." }));

            foreach (var item in installments.OrderBy(x => x.Order))
            {
                item.CertificateContractualId = certificateContractualId;
                item.Price = d_price;
                item.Date = d_date;

                if (!item.CertificateContractualInstallmentId.HasValue)
                {
                    item.CreatedBy = user.Id;
                }

                d_date = d_date.Value.AddMonths(1);
            }

            certificateContractualInstallmentFunctions.DeleteByCertificateContractual(certificateContractualId, installments.Where(x => x.CertificateContractualInstallmentId.HasValue).Select(x => x.CertificateContractualInstallmentId.Value));
            await certificateContractualInstallmentFunctions.CreateOrUpdateRange(installments);

            await certificateContractualFunctions.UpdateInstallment(certificateContractualId, paymentTypeId, d_price.Value, base_date.Value, paymentTimes);

            return await Task.Run(() => Json(new { hasError = false, message = "Dados salvos com sucesso!" }));
        }
        public async Task UpdateCertificateContractualInstallmentPaid(int certificateContractualInstallmentId, bool paid) => await certificateContractualInstallmentFunctions.UpdateCertificateContractualInstallmentPaid(certificateContractualInstallmentId, paid);
        #endregion

        #endregion

        #region [SHARED]
        private async Task<List<string>> GetAllEmailFromCertificate(int id, bool includeRealStateSellers = true)
        {
            var certificate = certificateContractualFunctions.GetDataViewModel(certificateContractualFunctions.GetDataByID(id));
            var emailToSend = new List<string>();

            if (certificate.CreatedBy.HasValue)
            {
                var createdBy = userFunctions.GetDataViewModel(userFunctions.GetDataByID(certificate.CreatedBy));
                if (includeRealStateSellers || (!includeRealStateSellers && createdBy.Role != "Imobiliária - Vendas")) emailToSend.Add(createdBy.Email);
            }

            emailToSend.AddRange((await userCompanyFunctions.GetRealEstateAdministratorUser(certificate.RealEstateId.Value)).Select(x => x.Email));
            emailToSend.AddRange((includeRealStateSellers ? await userCompanyFunctions.GetUsersByCompanyId(certificate.RealEstateId.Value) : userCompanyFunctions.GetUsersByCompanyIdWithoutRealStateSellers(certificate.RealEstateId.Value)).Select(x => x.Email));

            return emailToSend;
        }
        #endregion
    }
}