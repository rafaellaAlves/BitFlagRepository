using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using WEB.Utils;
using System.Globalization;

namespace WEB.Controllers
{
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly BLL.CertificateFunctions certificateFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.PlanFunctions planFunctions;
        private readonly BLL.PaymentWayFunctions paymentWayFunctions;
        private readonly BLL.AssistanceFunctions assistanceFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.InsurancePolicyFunctions insurancePolicyFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private readonly Insurance_HomologContext context;

        //private readonly BLL.CertificateProductTypeFunctions certificateProductTypeFunctions;

        public CertificateController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
        {
            this.context = context;
            this.certificateFunctions = new BLL.CertificateFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.planFunctions = new BLL.PlanFunctions(context);
            this.paymentWayFunctions = new BLL.PaymentWayFunctions(context);
            this.assistanceFunctions = new BLL.AssistanceFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.insurancePolicyFunctions = new BLL.InsurancePolicyFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
            
        }

        #region [SHARED]
        string NonApprovedCertificateEmailText(CertificateViewModel model)
        {
            return $"Novo certificado criado." +
                $"<br/><br/>" +
                $"Certificado de referência: <b>#{model.Reference}</b> foi denominado como <b>Não Aprovado</b>." +
                $"<br/>" +
                $"<a href =\"{HttpContext.Request.Scheme}://{ HttpContext.Request.Host + Url.Action("Manage", "Certificate")}?reference={model.Reference}\">Clique aqui</a> para ser redirecionado a página do certificado.";
        }
        #endregion

        #region [PAGES AND COMPONENTS]
        public async Task<IActionResult> Index(int certificateType)
        {
            var user = await userManager.GetUserAsync(User);
            var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

            if (!User.IsInRole("Administrator"))
            {
                if (companyUser == null)
                {
                    return RedirectToAction("NoCompany", "Account");
                }
            }

            if (certificateType == 0) certificateType = (int)CertificateTypes.Emitidos;

            return View(certificateType);
        }

        public async Task<IActionResult> CertificateIndexComponent(int certificateType)
        {
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

            return ViewComponent(typeof(ViewComponents.Certificate.CertificateIndexViewComponent), new { certificateType });
        }

        public async Task<IActionResult> Report()
        {
            var user = await userManager.GetUserAsync(User);
            

            if (!User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "Home");
              
            }

            return View();
        }

        public async Task<IActionResult> CertificateReportComponent()
        {
            var user = await userManager.GetUserAsync(User);
            if (!User.IsInRole("Administrator")) return Forbid();


            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateAgencyId).ToList();

            if (User.IsInRole("Corretor"))
            {
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    ViewData["UserRealEstateAgencyId"] = companyUser.CompanyId;
                }
                else
                {
                    return Forbid();
                }
            }
            else if (User.IsInRealEstate())
            {
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    var userRealEstateAgencyId = companyFunctions.GetDataByID(companyUser.CompanyId).ParentCompanyId;
                    ViewData["UserRealEstateAgencyId"] = userRealEstateAgencyId;
                    ViewData["UserRealEstateId"] = companyUser.CompanyId;
                }
                else
                {
                    return Forbid();
                }
            }

            return ViewComponent(typeof(ViewComponents.Certificate.CertificateReportViewComponent));
        }

        public async Task<IActionResult> Manage(string reference, int? certificateType)
        {
            ViewData["CertificateType"] = certificateType;

            int? id = null;
            if (!string.IsNullOrWhiteSpace(reference))
            {
                var certificate = certificateFunctions.GetDataByReference(reference);
                if (certificate != null) id = certificate.CertificateId;
            }

            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

            if (!User.IsInRole("Administrator"))
            {

                if (userCompany == null) return Forbid();

                if (id.HasValue)
                {
                    var certificate = certificateFunctions.GetDataByID(id);

                    if (User.IsInRole("Corretor") && certificate.RealEstateAgencyId != userCompany.CompanyId) return Forbid();
                    if (User.IsInRealEstate() && certificate.RealEstateId != userCompany.CompanyId) return Forbid();
                }
            }
            return View(id);
        }

        public async Task<IActionResult> CertificateManageComponent(int? id, int? certificateType)
        {
            ViewData["CertificateType"] = certificateType;

            Models.CertificateViewModel certificate = new Models.CertificateViewModel();
            if (id.HasValue)
                certificate = certificateFunctions.GetDataViewModel(certificateFunctions.GetDataByID(id));

            ViewData["Products"] = productFunctions.GetData(c => !c.IsDeleted).ToList();
            ViewData["_InsurancePolicy"] = insurancePolicyFunctions._GetDataViewModel(insurancePolicyFunctions.GetData(c => !c.IsDeleted));

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateAgencyId).ToList();
            ViewData["RealEstate"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == realEstateId).ToList();

            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(User);
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (userCompany != null) certificate.RealEstateAgencyId = userCompany.CompanyId;

                else return RedirectToAction("Index");
            }
            else if (User.IsInRealEstate())
            {
                var user = await userManager.GetUserAsync(User);
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
                if (userCompany != null)
                {
                    certificate.RealEstateAgencyId = companyFunctions.GetDataByID(userCompany.CompanyId).ParentCompanyId;
                    certificate.RealEstateId = userCompany.CompanyId;
                }
                else return RedirectToAction("Index");
            }

            return ViewComponent(typeof(ViewComponents.Certificate.CertificateManageViewComponent), new { model = certificate });
        }
        public async Task<IActionResult> Print(string reference)
        {

            if (string.IsNullOrWhiteSpace(reference)) return Forbid();
            var certificate = certificateFunctions.GetDataByReference(reference);
            if (certificate == null) return Forbid();

            if (certificate.IsSimulation) return Forbid();

            if (!User.IsInRole("Administrator"))
            {
                var user = await userManager.GetUserAsync(User);
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (userCompany == null) return Forbid();
                if (User.IsInRole("Corretor") && certificate.RealEstateAgencyId != userCompany.CompanyId) return Forbid();
                if (User.IsInRealEstate() && certificate.RealEstateId != userCompany.CompanyId) return Forbid();
            }

            return View(certificateFunctions.GetCertificatePrintViewModel(certificate.CertificateId));
        }

       

        public async Task<IActionResult> SavedPrint(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference)) return Forbid();
            var certificate = certificateFunctions.GetDataByReference(reference);
            if (certificate == null) return Forbid();

            if (!certificate.IsSimulation) return Forbid();

            if (!User.IsInRole("Administrator"))
            {
                var user = await userManager.GetUserAsync(User);
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (userCompany == null) return Forbid();

                if (User.IsInRole("Corretor") && certificate.RealEstateAgencyId != userCompany.CompanyId) return Forbid();
                if (User.IsInRealEstate() && certificate.RealEstateId != userCompany.CompanyId) return Forbid();
            }

            return View(certificateFunctions.GetCertificatePrintViewModel(certificate.CertificateId));
        }
        #endregion

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int certificateType, int? realEstateAgencyId, int? realEstateId, int? insurancePolicyId, string startDate, string endDate, int? motivo)
        {
            if (filter == null)
                filter = new DataTablesAjaxPostModel();

            string query = "";
            List<SqlParameter> param = new List<SqlParameter>();
            if (certificateType == (int)Utils.CertificateTypes.Emitidos)
            {
                query += "(IsDeleted = 0 AND DATEADD(month, 12, datefromparts(year(AdherenceDate), month(AdherenceDate), 1)) > @Date1)";
                param.Add(new SqlParameter("@Date1", DateTime.Now));
            }
            else if (certificateType == (int)Utils.CertificateTypes.Deletados)
            {
                query += "(IsDeleted = 1 OR DATEADD(month, 13, datefromparts(year(AdherenceDate), month(AdherenceDate), 1)) < @Date1)";
                param.Add(new SqlParameter("@Date1", DateTime.Now));
            }
            else if (certificateType == (int)Utils.CertificateTypes.Renovacao)
            {
                query += "IsDeleted = 0";

                var primeiroDiaRenovacao = "DATEADD(month, 12, VigencyDate)"; // primeiro dia de renovação => 1 ano após o inicio da vigência
                var ultimoDiaRenovacao = "DATEADD(day, 1, EOMONTH(DATEADD(month, 11, VigencyDate), 1))";// ultimo dia de renovação => ultimo dia do mês do início da renovação

                query += " AND (" + primeiroDiaRenovacao + " <= @RenovacaoDate AND " + ultimoDiaRenovacao + " >= @RenovacaoDate)";

                param.Add(new SqlParameter("@RenovacaoDate", DateTime.Now));
            }
            else if (certificateType == (int)Utils.CertificateTypes.Simulacao)
            {
                query += "IsDeleted = 0 AND IsSimulation = 1 "; //AND DATEADD(day, 8, datefromparts(year(CreatedDate), month(CreatedDate), day(CreatedDate))) > @Date2
                //param.Add(new SqlParameter("@Date2", DateTime.Now));
            }

            if (certificateType != (int)Utils.CertificateTypes.Simulacao)
            {
                query += " AND IsSimulation = 0";
            }

            var user = await userManager.GetUserAsync(User);
            var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

            if (!User.IsInRole("Administrator"))
            {
                if (companyUser == null)
                {
                    return await Task.Run<IActionResult>(() => Json(new
                    {
                        recordsTotal = 0,
                        recordsFiltered = 0,
                        data = new List<DB.Models.Certificate>()
                    }));
                }

                if (User.IsInRole("Corretor"))
                {
                    if (companyUser != null)
                    {
                        query += " AND RealEstateAgencyId = @RealEstateAgencyId";
                        param.Add(new SqlParameter("@RealEstateAgencyId", companyUser.CompanyId));
                    }
                    if (realEstateId.HasValue)
                    {
                        query += " AND RealEstateId = @RealEstateId ";
                        param.Add(new SqlParameter("@RealEstateId ", realEstateId));
                    }
                }
                else if (User.IsInRealEstate())
                {
                    if (companyUser != null)
                    {
                        query += " AND RealEstateId = @RealEstateId ";
                        param.Add(new SqlParameter("@RealEstateId ", companyUser.CompanyId));
                    }
                }
            }
            else
            {
                if (realEstateAgencyId.HasValue)
                {
                    query += " AND RealEstateAgencyId = @RealEstateAgencyId";
                    param.Add(new SqlParameter("@RealEstateAgencyId", realEstateAgencyId));
                }
                if (realEstateId.HasValue)
                {
                    query += " AND RealEstateId = @RealEstateId ";
                    param.Add(new SqlParameter("@RealEstateId ", realEstateId));
                }
            }

            if (insurancePolicyId.HasValue)
            {
                query += " AND InsurancePolicyId = @InsurancePolicyId";
                param.Add(new SqlParameter("@InsurancePolicyId", insurancePolicyId));
            }

            var _startDate = startDate.FromDatePtBR();
            if (_startDate.HasValue)
            {
                query += " AND AdherenceDate >= @AdherenceDate";
                param.Add(new SqlParameter("@AdherenceDate", _startDate));
            }

            var _endDate = endDate.FromDatePtBR();
            if (_endDate.HasValue)
            {
                var __endDate = new DateTime(_endDate.Value.Year, _endDate.Value.Month, _endDate.Value.Day, 23, 59, 59);
                query += " AND AdherenceDate <= @AdherenceDate1 ";
                param.Add(new SqlParameter("@AdherenceDate1", __endDate));
            }
            if (motivo.HasValue)
            {
                if (motivo == 1)
                    query += " AND copiedBy IS NULL ";
                else if (motivo == 2)
                    query += " AND copiedBy IS NOT NULL ";
                else if (motivo == 3)
                    query += " AND copiedBy IS NULL AND IsDeleted = 0 ";
            }

            IEnumerable<DB.Models.Certificate> d = this.certificateFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()).ToList();
            var _d = certificateFunctions.GetCertificateListViewModel(d);

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = _d
            }));
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(Models.CertificateViewModel model)
        {
            Utils.DBActionType dbActionType;
            string auditLogObs = "";
            var user = await userManager.GetUserAsync(User);

            if (string.IsNullOrWhiteSpace(model.Reference))
            {
                int maxTries = 10;
                for (int i = 0; i <= maxTries; i++)
                {
                    if (i == maxTries) throw new Exception("Reference max tries reached.");
                    var reference = Utils.ReferenceUtils.GetReference();
                    if (!certificateFunctions.ReferenceExiste(reference))
                    {
                        model.Reference = reference;
                        break;
                    }
                }


                if (model.IsSimulation.HasValue && !model.IsSimulation.Value)
                {
                    model.AdherenceDate = DateTime.Now;
                    model.AdherenceBy = user.Id;
                    auditLogObs = "Adesão";
                }

                dbActionType = Utils.DBActionType.CREATE;
                model.CreatedBy = user.Id;
            }
            else
            {
                dbActionType = Utils.DBActionType.UPDATE;

                model.ModifiedDate = DateTime.Now;
                model.ModifiedBy = user.Id;

                var certificate = certificateFunctions.GetDataByID(model.CertificateId);

                //Garante que se o certificado foi aderido nunca volte a ser simulação
                if (!certificate.IsSimulation && model.IsSimulation.Value)
                {
                    model.IsSimulation = false;
                }

                if (certificate.IsSimulation && !model.IsSimulation.Value)
                {
                    model.AdherenceDate = DateTime.Now;
                    model.AdherenceBy = user.Id;
                    auditLogObs = "Adesão";
                }

                if ((model.IsSimulation.Value || (certificate.IsSimulation && !model.IsSimulation.Value)) && !certificate.ApprovedBy.HasValue)
                {
                }
            }
            model.PlanPrice = planFunctions.GetPlanPrice(model.PlanId.Value);

            if (model.IsApproved.HasValue && model.IsApproved.Value)
            {
                if (!model.IsSimulation.Value)
                {
                    model.ApprovedBy = user.Id;
                    model.ApprovedDate = DateTime.Now;
                    model.VigencyDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                }
            }
            else if (model.IsApproved.HasValue)
            {
                await BLL.MailFunctions.SendAsync("A+Imob - Criação de certificado não aprovado.", NonApprovedCertificateEmailText(model), new List<string> { WEB.Configuration.InsuranceConfiguration.MailSenderDisplay }, null);
            }

            model.CertificateId = certificateFunctions.CreateOrUpdate(model);

            auditLogFunctions.Log("CertificateViewModel", model.CertificateId.Value, "CertificateId", dbActionType, certificateFunctions.GetDataViewModelForAuditLog(certificateFunctions.GetDataByID(model.CertificateId)), user.Id, auditLogObs);

            return Json(new BLL.Shared.ReturnResult(model.CertificateId.Value, "", false));
        }

        [HttpPost]
        [ActionName("Adherence")]
        public async Task<IActionResult> Adherence(int id)
        {
            if (!certificateFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(id, "Certificado não encontrado para exclusão", true));
            var model = certificateFunctions.GetDataViewModel(certificateFunctions.GetDataByID(id));

            if (!model.IsApproved.HasValue || (model.IsApproved.HasValue && !model.IsApproved.Value)) return Json(new BLL.Shared.ReturnResult(id, "Certificado precisa ser aprovado para ser feita a adesão.", true));

            var plan = planFunctions.GetDataByID(model.PlanId);
            if (!model.AssistanceId.HasValue && plan.CertificateId.HasValue) return Json(new BLL.Shared.ReturnResult(id, "Certificado precisa ter uma assistência associada.", true));

            var user = await userManager.GetUserAsync(User);


            model.IsSimulation = false;
            model.AdherenceDate = DateTime.Now;
            model.AdherenceBy = user.Id;
            
            if (model.IsApproved.HasValue && model.IsApproved.Value)
            {
                model.ApprovedBy = user.Id;
                model.ApprovedDate = DateTime.Now;
                model.VigencyDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }

            certificateFunctions.Update(model);

            auditLogFunctions.Log("CertificateViewModel", id, "CertificateId", Utils.DBActionType.UPDATE, certificateFunctions.GetDataViewModelForAuditLog(certificateFunctions.GetDataByID(id)), user.Id, "Adesão");

            return Json(new BLL.Shared.ReturnResult(id, "Certificado aderido com sucesso!", false));
        }

        [HttpPost]
        [ActionName("RemoveCertificate")]
        public async Task<IActionResult> RemoveCertificate(int id)
        {
            if (!certificateFunctions.Exists(id)) return Json(false);

            var user = await userManager.GetUserAsync(User);

            certificateFunctions.Delete(id, user.Id);

            auditLogFunctions.Log("CertificateViewModel", id, "CertificateId", Utils.DBActionType.DELETE, certificateFunctions.GetDataViewModelForAuditLog(certificateFunctions.GetDataByID(id)), user.Id);

            return Json(true);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Approve(int id)
        {
            if (!certificateFunctions.Exists(id)) return Forbid();

            var user = await userManager.GetUserAsync(User);
            var r = certificateFunctions.Approve(id, user.Id);

            auditLogFunctions.Log("CertificateViewModel", id, "CertificateId", Utils.DBActionType.UPDATE, certificateFunctions.GetDataViewModelForAuditLog(certificateFunctions.GetDataByID(id)), user.Id, "Aprovação");

            return Json(r);
        }

        [HttpPost]
        public async Task<IActionResult> Renew(int id)
        {
            if (!certificateFunctions.Exists(id)) return Forbid();

            var user = await userManager.GetUserAsync(User);
            var oldCert = certificateFunctions.GetDataByID(id);
            var planPrice = planFunctions.GetPlanPrice(oldCert.PlanId);

            var newCertId = certificateFunctions.Renew(id, user.Id, planPrice);

            Certificate cert;
            if (newCertId.HasValue)
            {
                auditLogFunctions.Log("CertificateViewModel", id, "CertificateId", Utils.DBActionType.DELETE, certificateFunctions.GetDataViewModelForAuditLog(certificateFunctions.GetDataByID(id)), user.Id, "Excluído para Renovação");
                auditLogFunctions.Log("CertificateViewModel", newCertId.Value, "CertificateId", Utils.DBActionType.CREATE, certificateFunctions.GetDataViewModelForAuditLog(certificateFunctions.GetDataByID(newCertId)), user.Id, "Renovação");

                cert = certificateFunctions.GetDataByID(newCertId);
                return Json(new BLL.Shared.ReturnResult(newCertId.Value, "O certificado foi renovado com sucesso, e agora possui a referência: " + cert.Reference, false));

            }
            return Json(new BLL.Shared.ReturnResult(0, "Houve um erro ao renovar o certificado.", true));
        }

        [HttpPost]
        public IActionResult GetAuditLog(int certificateId)
        {
            var auditLogItens = auditLogFunctions.GetAuditLogEntityChangesByEntityId<Models.CertificateViewModel>(certificateId);

            return Json(auditLogItens);
        }

        #region [Import/Export]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> ImportarCertificados(int type)
        {
            var file = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("Arquivo"));
            if (file == null) return Json(new { hasError = true, mensagem = "Erro ao Importar, tente tente novamente." });
            bool validArchive = Path.GetExtension(file.FileName) == ".xlsx";
            if (!validArchive) return Json(new { hasError = true, mensagem = "Arquivo com extensão diferente do aceito." });

            var linesWithError = new Dictionary<int, string>();
            var certificateReferences = new List<string>();
            int totalSaved = 0;

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            var user = await userManager.GetUserAsync(User);

            using (ExcelPackage package = new ExcelPackage(file.OpenReadStream()))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                for (int i = 2; //2
                         i <= workSheet.Dimension.End.Row;
                         i++)
                {
                    if (workSheet.Cells[i, 2].Value == null ||  //Data Criação
                        workSheet.Cells[i, 3].Value == null ||  // CNPJ/CPF Corretora
                        workSheet.Cells[i, 4].Value == null ||  // CNPJ/CPF Imobiliaria
                        workSheet.Cells[i, 5].Value == null ||  // Num. Apólice
                        workSheet.Cells[i, 6].Value == null ||  // Nome Inquilino
                        workSheet.Cells[i, 7].Value == null ||  // CPF Inquilino
                        workSheet.Cells[i, 8].Value == null ||  // Nome Beneficiário
                        workSheet.Cells[i, 9].Value == null ||  // CPF Segurado
                        workSheet.Cells[i, 10].Value == null ||  // Tipo de imóvel
                        workSheet.Cells[i, 11].Value == null || // CEP
                        workSheet.Cells[i, 12].Value == null || // Endereço
                        workSheet.Cells[i, 13].Value == null || // Numero
                        workSheet.Cells[i, 15].Value == null || // Bairro
                        workSheet.Cells[i, 16].Value == null || // Cidade
                        workSheet.Cells[i, 17].Value == null || // UF
                        workSheet.Cells[i, 18].Value == null || // Tipo de Construção
                        workSheet.Cells[i, 19].Value == null || // Tipo de Uso
                        workSheet.Cells[i, 20].Value == null || // Plano
                        workSheet.Cells[i, 22].Value == null    // Vezes de Pagamento
                        )
                    {
                        linesWithError.Add(i, "Preencha os dados de todas colunas");
                        continue;
                    }

                    var certificate = new Certificate();

                    //data de criação
                    var _createdDate = workSheet.Cells[i, 2].Value.ToString().FromDatePtBR();
                    if (!_createdDate.HasValue)
                    {
                        linesWithError.Add(i, "Formatação incorreta da data de inclusão - Correto: dd/mm/aaaa");
                        continue;
                    }

                    certificate.CreatedDate = (DateTime)_createdDate;

                    //Corretora
                    if (!companyFunctions.GetData().Any(x => x.CompanyTypeId == realEstateAgencyId && (x.Cpf == workSheet.Cells[i, 3].Value.ToString().NumbersOnly() || x.Cnpj == workSheet.Cells[i, 3].Value.ToString().NumbersOnly()) && !x.IsDeleted))
                    {
                        linesWithError.Add(i, "CNPJ/CPF da "+ WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName +" não encontrado");
                        continue;
                    }
                    certificate.RealEstateAgencyId = companyFunctions.GetData().First(x => x.CompanyTypeId == realEstateAgencyId && (x.Cpf == workSheet.Cells[i, 3].Value.ToString().NumbersOnly() || x.Cnpj == workSheet.Cells[i, 3].Value.ToString().NumbersOnly()) && !x.IsDeleted).CompanyId;

                    //Imobiliária
                    if (!companyFunctions.GetData().Any(x => x.CompanyTypeId == realEstateId && (x.Cpf == workSheet.Cells[i, 4].Value.ToString().NumbersOnly() || x.Cnpj == workSheet.Cells[i, 4].Value.ToString().NumbersOnly()) && !x.IsDeleted))
                    {
                        linesWithError.Add(i, Configuration.InsuranceConfiguration.PartnerDisplayName + ": CNPJ/CPF não encontrado");
                        continue;
                    }
                    certificate.RealEstateId = companyFunctions.GetData().First(x => x.CompanyTypeId == realEstateId && (x.Cpf == workSheet.Cells[i, 4].Value.ToString().NumbersOnly() || x.Cnpj == workSheet.Cells[i, 4].Value.ToString().NumbersOnly()) && !x.IsDeleted).CompanyId;

                    //Apólice
                    if (!insurancePolicyFunctions.GetData().Any(x => x.InsurancePolicyNumber.NumbersOnly().Contains(workSheet.Cells[i, 5].Value.ToString().NumbersOnly()) && !x.IsDeleted))
                    {
                        linesWithError.Add(i, "Número de apólice não encontrado");
                        continue;
                    }
                    var insurancePolicy = insurancePolicyFunctions.GetData().First(x => x.InsurancePolicyNumber.NumbersOnly() == workSheet.Cells[i, 5].Value.ToString().NumbersOnly() && !x.IsDeleted);
                    certificate.InsurancePolicyId = insurancePolicy.InsurancePolicyId;
                    certificate.ProductId = insurancePolicy.ProductId;

                    
                    //Plano
                    if (!planFunctions.GetData().Any(x => x.Name.ToUpper().Contains(workSheet.Cells[i, 20].Value.ToString().RemoveAccents().ToUpper()) && x.ProductId == certificate.ProductId && (!x.IsDeleted.HasValue || (x.IsDeleted.HasValue && !x.IsDeleted.Value))))
                    {
                        linesWithError.Add(i, "Plano não existente");
                        continue;
                    }
                    var plan = planFunctions.GetData().First(x => x.Name.ToUpper().Contains(workSheet.Cells[i, 20].Value.ToString().RemoveAccents().ToUpper()) && x.ProductId == certificate.ProductId && (!x.IsDeleted.HasValue || (x.IsDeleted.HasValue && !x.IsDeleted.Value)));
                    certificate.PlanId = plan.PlanId;
                    certificate.AssistanceId = plan.AssistanceId;
                    certificate.PlanPrice = planFunctions.GetPlanPrice(certificate.PlanId);

                    certificate.LocatorName = workSheet.Cells[i, 6].Value.ToString();
                    certificate.LocatorCpf = workSheet.Cells[i, 7].Value.ToString().NumbersOnly();
                    if (certificate.LocatorCpf.Length > 14)
                    {
                        linesWithError.Add(i, "CPF/CNPJ do locador com mais de 14 dígitos");
                        continue;
                    }
                    certificate.RenterName = workSheet.Cells[i, 8].Value.ToString();
                    certificate.RenterCpf = workSheet.Cells[i, 9].Value.ToString().NumbersOnly();
                    if (certificate.RenterCpf.Length > 14)
                    {
                        linesWithError.Add(i, "CPF do locatário com mais de 14 dígitos");
                        continue;
                    }
                    certificate.Cep = workSheet.Cells[i, 11].Value.ToString().NumbersOnly();
                    if (certificate.Cep.Length > 8)
                    {
                        linesWithError.Add(i, "CEP com mais de 8 dígitos");
                        continue;
                    }
                    certificate.Endereco = workSheet.Cells[i, 12].Value.ToString();
                    certificate.Numero = workSheet.Cells[i, 13].Value.ToString();
                    certificate.Complemento = workSheet.Cells[i, 14].Value != null ? workSheet.Cells[i, 14].Value.ToString() : "";
                    certificate.Bairro = workSheet.Cells[i, 15].Value.ToString();
                    certificate.Cidade = workSheet.Cells[i, 16].Value.ToString();
                    certificate.Uf = workSheet.Cells[i, 17].Value.ToString();
                    if (certificate.Uf.Length > 2)
                    {
                        linesWithError.Add(i, "UF com mais de 2 dígitos");
                        continue;
                    }
                    if (workSheet.Cells[i, 21].Value == null)
                    {
                        certificate.TaxaInquilini = 0;
                    }
                    else
                    {
                        int taxes;
                        var _taxes = workSheet.Cells[i, 21].Value.ToString();

                        if (_taxes.Contains(","))
                        {
                            _taxes = _taxes.Split(",")[0];
                        }

                        _taxes = _taxes.NumbersOnly();

                        if (string.IsNullOrWhiteSpace(_taxes))
                        {
                            taxes = 0;
                        }
                        else
                        {
                            taxes = int.Parse(_taxes);
                        }

                        certificate.TaxaInquilini = taxes > 120 ? 120 : taxes;
                    }
                    //Payment Times
                    int paymentTimes;
                    if (workSheet.Cells[i, 22].Value.ToString().ToUpper() == "MENSAL") paymentTimes = 12;
                    else
                    {
                        var _paymentTimes = workSheet.Cells[i, 22].Value.ToString().NumbersOnly();
                        if (string.IsNullOrWhiteSpace(_paymentTimes))
                        {
                            linesWithError.Add(i, "Forma de pagamento de ser um número dentre 1 a 12");
                            continue;
                        }
                        paymentTimes = int.Parse(_paymentTimes);
                        if (paymentTimes > 12) paymentTimes = 12;
                    }
                    certificate.PaymentTimes = paymentTimes;


                    if (certificate.IsApproved.Value)
                    {
                        certificate.ApprovedBy = user.Id;
                        certificate.ApprovedDate = certificate.CreatedDate;
                        certificate.VigencyDate = new DateTime(certificate.ApprovedDate.Value.Year, certificate.ApprovedDate.Value.Month, 1);
                    }

                    if (type == (int)CertificateTypes.Simulacao)
                    {
                        certificate.IsSimulation = true;
                        certificate.CreatedBy = user.Id;

                    
                    }
                    else
                    {
                        certificate.IsSimulation = false;
                        certificate.CreatedBy = user.Id;
                        //Adesão
                        certificate.AdherenceDate = certificate.CreatedDate;
                        certificate.AdherenceBy = user.Id;
                    }
                    if (type == (int)CertificateTypes.Renovacao)
                    {
                        if (!certificate.AdherenceDate.IsInTimeToRenovate())
                        {
                            linesWithError.Add(i, "Certificado não está em periodo de renovação");
                            continue;
                        }
                    }

                    //Reference
                    int maxTries = 10;
                    for (int k = 0; k <= maxTries; k++)
                    {
                        if (k == maxTries) throw new Exception("Reference max tries reached.");
                        var reference = Utils.ReferenceUtils.GetReference();
                        if (!certificateFunctions.ReferenceExiste(reference))
                        {
                            certificate.Reference = reference;
                            break;
                        }
                    }

                    certificate.BlockRenew = true;

                    this.context.Certificate.Add(certificate);
                    certificateReferences.Add(certificate.Reference);
                    totalSaved++;
                }
                this.context.SaveChanges();

                foreach (var reference in certificateReferences)
                {
                    var certificate = certificateFunctions.GetDataByReference(reference);
                    auditLogFunctions.Log("CertificateViewModel", certificate.CertificateId, "CertificateId", DBActionType.CREATE, certificateFunctions.GetDataViewModel(certificate), user.Id, "Importação");
                }

            }

            return await Task.Run(() => Json(new { temErro = false, dados = new { totalSaved, linesWithError } }));
        }

        [HttpPost]
        [ActionName("GetReport")]
        public async Task<IActionResult> GetReport(int? realEstateAgencyId, int? realEstateId, int? insurancePolicyId, string _refMonth) //DataTime;;
        {
            var refMonth = _refMonth.FromDatePtBR();
            if (!refMonth.HasValue) return Forbid();

            var user = await userManager.GetUserAsync(User);
            if (!User.IsInRole("Administrator")) return Forbid();

          
            Models.CompanyViewModel realEstateAgency = null;
            if (realEstateAgencyId.HasValue) realEstateAgency = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(realEstateAgencyId));

            var _certificates = certificateFunctions.GetCertificateExport(realEstateAgencyId, realEstateId, insurancePolicyId, refMonth.Value);
            var c = _certificates.Count;
            var byteArray = System.IO.File.ReadAllBytes(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "template", "Blank.xlsx"));
            using (var memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, (int)byteArray.Length);
                memoryStream.Position = 0;
                using (var excelPackage = new ExcelPackage(memoryStream))
                {
                    int j = 0;
                    foreach (var item in _certificates.GroupBy(x => x.Apolice))
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                        if (excelPackage.Workbook.Worksheets.Count > j)
                        {
                            worksheet = excelPackage.Workbook.Worksheets[j];
                            worksheet.Name = item.Key;
                        }
                        else
                        {
                            worksheet = excelPackage.Workbook.Worksheets.Add(item.Key);
                        }

                        worksheet.Cells[1, 1].Value = WEB.Configuration.InsuranceConfiguration.CorretoraDisplayName;

                        Color green = System.Drawing.ColorTranslator.FromHtml("#3a644e");
                        worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(green);
                        worksheet.Cells[1, 1].Style.Font.Color.SetColor(Color.White);
                        worksheet.Cells["A1:I1"].Merge = true;
                        worksheet.Cells["A1:I1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet.Cells[1, 10].Value = $"PERÍODO: do dia {refMonth.ToDatePtBR()} ao dia {refMonth.Value.AddMonths(1).ToDatePtBR()}";

                        worksheet.Cells[1, 10].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[1, 10].Style.Fill.BackgroundColor.SetColor(green);
                        worksheet.Cells[1, 10].Style.Font.Color.SetColor(Color.White);
                        worksheet.Cells["J1:Y1"].Merge = true;
                        worksheet.Cells["J1:Y1"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        worksheet.Cells[2, 1].Value = $"Data limite para inclusão: {new DateTime(refMonth.Value.Year, refMonth.Value.Month, DateTime.DaysInMonth(refMonth.Value.Year, refMonth.Value.Month)).ToDatePtBR()}";
                        worksheet.Cells["A2:D2"].Merge = true;

                        if (realEstateAgency == null)
                            worksheet.Cells[2, 5].Value = "Corretora: -";
                        else
                            worksheet.Cells[2, 5].Value = "Corretora: " + realEstateAgency.CompanyName;

                        worksheet.Cells["E2:X2"].Merge = true;
                        worksheet.Cells[2, 25].Value = "Total";

                        worksheet.Cells[3, 1].Value = "Quantidade de itens: " + item.Count();
                        worksheet.Cells["A3:D3"].Merge = true;
                        worksheet.Cells[3, 5].Value = "Apólice: " + item.Key;
                        worksheet.Cells["E3:W3"].Merge = true;
                        worksheet.Cells[3, 24].Value = "Prêmio Total:";
                        worksheet.Cells[3, 25].Value = item.Sum(x => Math.Round(x.PrecoPlanoEAssistencia, 2, MidpointRounding.AwayFromZero)).ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
                        worksheet.Cells["A2:Y3"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                        for (int k = 1; k <= 25; k++)
                        {
                            worksheet.Cells[4, k].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[4, k].Style.Fill.BackgroundColor.SetColor(green);
                            worksheet.Cells[4, k].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            worksheet.Cells[4, k].Style.Font.Color.SetColor(Color.White);
                        }

                        worksheet.Cells[4, 1].Value = "Item";
                        worksheet.Cells[4, 2].Value = "Data de Inclusão";
                        worksheet.Cells[4, 3].Value = "Imobiliária";
                        worksheet.Cells[4, 4].Value = "Nome do inquilino";
                        worksheet.Cells[4, 5].Value = "CPF do inquilino";
                        worksheet.Cells[4, 6].Value = "Nome do Proprietário";
                        worksheet.Cells[4, 7].Value = "CPF do Proprietário";
                        worksheet.Cells[4, 8].Value = "Tipo do Imóvel";
                        worksheet.Cells[4, 9].Value = "CEP";
                        worksheet.Cells[4, 10].Value = "Local de Risco";
                        worksheet.Cells[4, 11].Value = "Número";
                        worksheet.Cells[4, 12].Value = "Complemento";
                        worksheet.Cells[4, 13].Value = "Bairro";
                        worksheet.Cells[4, 14].Value = "Cidade";
                        worksheet.Cells[4, 15].Value = "UF";
                        worksheet.Cells[4, 16].Value = "Cobertura Básica";
                        worksheet.Cells[4, 17].Value = "Básica";
                        worksheet.Cells[4, 18].Value = "Dano Elétrico";
                        worksheet.Cells[4, 19].Value = "Vendal";
                        worksheet.Cells[4, 20].Value = "PPA";
                        worksheet.Cells[4, 21].Value = "Roubo";
                        worksheet.Cells[4, 22].Value = "Vidros";
                        worksheet.Cells[4, 23].Value = "RC Familiar";
                        worksheet.Cells[4, 24].Value = "Impacto de Veic.";
                        worksheet.Cells[4, 25].Value = "Preço Plano / Mês";

                        int i = 5;
                        foreach (var certificate in item.OrderBy(x => x.DataDeInclusao.FromDatePtBR()))
                        {
                            if (i % 2 == 0)
                            {
                                for (int k = 1; k <= 25; k++)
                                {
                                    Color colFromHex = ColorTranslator.FromHtml("#dddddd");
                                    worksheet.Cells[i, k].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    worksheet.Cells[i, k].Style.Fill.BackgroundColor.SetColor(colFromHex);
                                }
                            }

                            var coberturaBasica = certificate.CoberturaBasica.Split(" = ");
                            var coberturas = certificate.Coberturas.Split(" | ").ToList();

                            var danoEletricoIndex = coberturas.FindIndex(x => x.ToUpper().Contains("DANOS ELÉTRICOS"));
                            var vendavalIndex = coberturas.FindIndex(x => x.ToUpper().Contains("VENDAVAL"));
                            var pPAIndex = coberturas.FindIndex(x => x.ToUpper().Contains("PERDA PAGAMENTO DE ALUGUEL"));
                            var rouboIndex = coberturas.FindIndex(x => x.ToUpper().Contains("ROUBO"));
                            var vidroIndex = coberturas.FindIndex(x => x.ToUpper().Contains("VIDROS"));
                            var rCFamiliarIndex = coberturas.FindIndex(x => x.ToUpper().Contains("RESPONSABILIDADE CIVIL FAMILIAR"));
                            var impactoVeicIndex = coberturas.FindIndex(x => x.ToUpper().Contains("IMPACTO DE VEÍCULO"));

                            string danoEletrico = "-", vendaval = "-", pPA = "-", roubo = "-", vidro = "-", rCFamiliar = "-", impactoVeic = "-";

                            if (danoEletricoIndex != -1)
                            {
                                var _danoEletrico = coberturas[danoEletricoIndex].Split(" = ");
                                if (_danoEletrico.Length > 0) danoEletrico = _danoEletrico[1].MoneyMask();
                            }
                            if (vendavalIndex != -1)
                            {
                                var _vendaval = coberturas[vendavalIndex].Split(" = ");
                                if (_vendaval.Length > 0) vendaval = _vendaval[1].MoneyMask();
                            }
                            if (pPAIndex != -1)
                            {
                                var _pPA = coberturas[pPAIndex].Split(" = ");
                                if (_pPA.Length > 0) pPA = _pPA[1].MoneyMask();
                            }
                            if (rouboIndex != -1)
                            {
                                var _roubo = coberturas[rouboIndex].Split(" = ");
                                if (_roubo.Length > 0) roubo = _roubo[1].MoneyMask();
                            }
                            if (vidroIndex != -1)
                            {
                                var _vidro = coberturas[vidroIndex].Split(" = ");
                                if (_vidro.Length > 0) vidro = _vidro[1].MoneyMask();
                            }
                            if (rCFamiliarIndex != -1)
                            {
                                var _rCFamiliar = coberturas[rCFamiliarIndex].Split(" = ");
                                if (_rCFamiliar.Length > 0) rCFamiliar = _rCFamiliar[1].MoneyMask();
                            }
                            if (impactoVeicIndex != -1)
                            {
                                var _impactoVeic = coberturas[impactoVeicIndex].Split(" = ");
                                if (_impactoVeic.Length > 0) impactoVeic = _impactoVeic[1].MoneyMask();
                            }


                            worksheet.Cells[i, 1].Value = i - 4;
                            worksheet.Cells[i, 2].Value = certificate.DataDeInclusao;
                            worksheet.Cells[i, 3].Value = certificate.Imobiliaria;
                            worksheet.Cells[i, 4].Value = certificate.NomeInquilino;
                            worksheet.Cells[i, 5].Value = certificate.CPFInquilino.CNPJOrCPFmask();
                            worksheet.Cells[i, 6].Value = certificate.NomeProprietario;
                            worksheet.Cells[i, 7].Value = certificate.CPFProprietario.CNPJOrCPFmask();
                            worksheet.Cells[i, 8].Value = certificate.TipoDeImovel;
                            worksheet.Cells[i, 9].Value = certificate.CEP.CEPMask();
                            worksheet.Cells[i, 10].Value = certificate.LocalDeRisco;
                            worksheet.Cells[i, 11].Value = certificate.Numero;
                            worksheet.Cells[i, 12].Value = certificate.Complemento;
                            worksheet.Cells[i, 13].Value = certificate.Bairro;
                            worksheet.Cells[i, 14].Value = certificate.Cidade;
                            worksheet.Cells[i, 15].Value = certificate.UF;
                            worksheet.Cells[i, 16].Value = coberturaBasica.Length > 0 ? coberturaBasica[0] : "-";

                            worksheet.Cells[i, 17].Value = coberturaBasica.Length > 1 ? coberturaBasica[1].MoneyMask() : "-";

                            worksheet.Cells[i, 18].Value = danoEletrico;

                            worksheet.Cells[i, 19].Value = vendaval;

                            worksheet.Cells[i, 20].Value = pPA;

                            worksheet.Cells[i, 21].Value = roubo;

                            worksheet.Cells[i, 22].Value = vidro;

                            worksheet.Cells[i, 23].Value = rCFamiliar;

                            worksheet.Cells[i, 24].Value = impactoVeic;

                            worksheet.Cells[i, 25].Value = certificate.PrecoPlanoEAssistencia.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));

                            i++;
                        }
                        if (_certificates.Count > 0) i--;

                        var tabela = worksheet.Cells["A5:Y" + (i).ToString()];
                        var ultimaLinha = worksheet.Cells["A" + (i).ToString() + ":Y" + (i).ToString()];

                        tabela.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        tabela.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        ultimaLinha.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        j++;
                    }
                    return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "relatorio-certificados-" + refMonth.Value.Month + "/" + refMonth.Value.Year + ".xlsx");
                }
            }
        }
        public static double RoundUp(double input, int places)
        {
            double multiplier = Math.Pow(10, Convert.ToDouble(places));
            return Math.Ceiling(input * multiplier) / multiplier;
        }
        #endregion
    }
}