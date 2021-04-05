using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using WEB.BLL;
using WEB.Models;
using WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Globalization;


namespace WEB.Controllers
{
    [Authorize(Roles = "Administrator, Corretor, GrupoMedico")]
    public class CompanyController : Controller
    {
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly BLL.HistoricoComissaoFunctions historicoComissaoFunctions;
        private readonly BLL.CompanyAcceptTermsFunctions companyAcceptTermsFunctions;

        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private ICompositeViewEngine viewEngine;

        public CompanyController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager, ICompositeViewEngine viewEngine, CompanyAcceptTermsFunctions companyAcceptTermsFunctions)
        {
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.companyTypeFunctions = new WEB.BLL.CompanyTypeFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.historicoComissaoFunctions = new HistoricoComissaoFunctions(context);
            this.companyAcceptTermsFunctions = companyAcceptTermsFunctions;
            this.userManager = userManager;
            this.viewEngine = viewEngine;
        }

        #region [SHARED]
        string RealEstateCreationEmailText(CompanyViewModel model)
        {
            string parentCompanyData = "-";
            if (model.ParentCompanyId.HasValue)
            {
                var parent = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.ParentCompanyId));
                parentCompanyData = $"{parent.CompanyName} ({parent.CompanyDocument.CNPJOrCPFmask()})";
            }

            return $"<b> {model.CompanyName}</b> (<b>{model.CompanyDocument.CNPJOrCPFmask()}</b>) foi criada para a " + Configuration.InsuranceConfiguration.CorretoraDisplayName + $" <b>{parentCompanyData}</b>." +
                $"<br/><br/>" +
                $"<a href =\"{HttpContext.Request.Scheme}://{ HttpContext.Request.Host + Url.Action("Manage", "Company")}?id={model.CompanyId}\">Clique aqui</a> para ser redirecionado e obter mais informações.";
        }
        string NewRealEstateEmailText(CompanyViewModel model)
        {
            string parentCompanyData = "-";
            if (model.ParentCompanyId.HasValue)
            {
                var parent = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.ParentCompanyId));
                parentCompanyData = $"{parent.CompanyName} ({parent.CompanyDocument.CNPJOrCPFmask()})";
            }

            return $"<b> {model.CompanyName}</b> (<b>{model.CompanyDocument.CNPJOrCPFmask()}</b>) foi criada para a " + Configuration.InsuranceConfiguration.CorretoraDisplayName + $" <b>{parentCompanyData}</b> em {DateTime.Now.ToDatePtBR()}." +
                $"<br/><br/>" +
                $"<a href =\"{HttpContext.Request.Scheme}://{ HttpContext.Request.Host + Url.Action("Manage", "Company")}?id={model.CompanyId}\">Clique aqui</a> para ser redirecionado e obter mais informações.";
        }
        #endregion

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> Manage(int? id, int? companyTypeId, int? parentCompanyId)
        {
            if (!companyTypeId.HasValue && !id.HasValue) return Forbid();

            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;

            if (!User.IsInRole("Administrator") && (userCompany == null || companyTypeId == realEstateAgencyId)) return Forbid();

            var company = new CompanyViewModel();
            if (id.HasValue) company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(id));
            if (companyTypeId.HasValue) company.CompanyTypeId = companyTypeId.Value;
            if (parentCompanyId.HasValue) company.ParentCompanyId = parentCompanyId;

            //se a corretora da empresa for difierente da corretora do usuario
            if (!User.IsInRole("Administrator") && company.CompanyId.HasValue && (company.ParentCompanyId != userCompany.CompanyId)) return Forbid();

            // só chamar quando for escritório


            return View(company);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult CorretoraManage(int? id)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            var company = new CompanyViewModel();
            if (id.HasValue) company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(id));
            else company.CompanyTypeId = 1;

            return View("Manage", company);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> ImobiliariaManage(int? id, int? parentCompanyId)
        {
            if (!parentCompanyId.HasValue && !id.HasValue) return Forbid();

            var company = new CompanyViewModel();
            if (id.HasValue) company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(id));
            else company.CompanyTypeId = 2;

            if (parentCompanyId.HasValue) company.ParentCompanyId = parentCompanyId;

            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

            //se a corretora da empresa for difierente da corretora do usuario
            if (company.ParentCompanyId != userCompany.CompanyId) return Forbid();

            return View("Manage", company);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> CompanyManageComponent(int? id, int companyTypeId, int? parentCompanyId)
        {
            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;

            if (!User.IsInRole("Administrator") && (userCompany == null || companyTypeId == realEstateAgencyId)) return Forbid();

            Models.CompanyViewModel model = new Models.CompanyViewModel();

            if (id.HasValue)
                model = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(id));
            else model.CompanyTypeId = companyTypeId;

            if (parentCompanyId.HasValue) model.ParentCompanyId = parentCompanyId;
            if (userCompany != null) model.ParentCompanyId = userCompany.CompanyId;

            ViewData["Corretoras"] = companyFunctions.GetData(c => c.CompanyTypeId == realEstateAgencyId && !c.IsDeleted).ToList();

            return ViewComponent(typeof(ViewComponents.Company.CompanyManageViewComponent), new { model = model });
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> _Manage(Models.CompanyViewModel model, bool sendTerms)
        {
            Utils.DBActionType dbActionType;
            CompanyViewModel oldCompany = null;

            if (model.CompanyId.HasValue)
            {
                dbActionType = Utils.DBActionType.UPDATE;
                oldCompany = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.CompanyId));
            }
            else
            {
                dbActionType = Utils.DBActionType.CREATE;
            }

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            if (model.CompanyTypeId == realEstateAgencyId && !User.IsInRole("Administrator")) return Forbid();

            if (!model.CompanyId.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(model.Cnpj) && companyFunctions.ExistCNPJ(model.Cnpj, model.CompanyTypeId))
                    return Json(new BLL.Shared.ReturnResult(0, "CNPJ já utilizado", true));
            }
            model.CompanyId = companyFunctions.CreateOrUpdate(model);

            var user = await userManager.GetUserAsync(User);

            historicoComissaoFunctions.Create(new DB.Models.HistoricoComissao
            {
                CompanyId = model.CompanyId.Value,
                Agenciamento = model.Agenciamento,
                Comissao = (model.Agenciamento / 12) + (model.Vitalicio * 11) / 12,
                Vitalicio = model.Vitalicio,
                CreatedBy = user.Id
            });

            companyFunctions.UpdateComissao(model);
            //companyFunctions.UpdateComissaoEscritorio(model);

            #region [Email Send]
            if (dbActionType == Utils.DBActionType.CREATE)
            {
                // PLATAFORMA
                if (model.CompanyTypeId == realEstateAgencyId) await SendRealEstateAgencyEmail(model);

                // ESCRITORIO
                if (model.CompanyTypeId == realEstateId)
                {
                    await SendRealEstateEmail(model);
                    await SendNewRealEstateEmail(model);
                }
            }
            else if (dbActionType == Utils.DBActionType.UPDATE && model.CompanyTypeId == realEstateAgencyId && (oldCompany.Vitalicio > model.Vitalicio || oldCompany.Agenciamento > model.Agenciamento))
            {
                companyFunctions.RemoveAcceptTerm(model.CompanyId.Value);
                companyFunctions.RemoveAcceptTermFromRealEstate(model.CompanyId.Value);

                await SendRealEstateAgencyEmail(model);
            }

            if (sendTerms && model.CompanyTypeId == 2)
            {
                await SendRealEstateEmail(model);
            }
            #endregion

            auditLogFunctions.Log("CompanyViewModel", model.CompanyId.Value, "CompanyId", dbActionType, companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.CompanyId)), user.Id);

            return Json(new BLL.Shared.ReturnResult(model.CompanyId.Value, "", false));
        }

        [Authorize(Roles = "Administrator, Corretor")]
        private async Task SendRealEstateEmail(Models.CompanyViewModel model)
        {
            var token = companyFunctions.NewTermAcceptToken(model.CompanyId.Value);
            var html = await RenderPartialViewToString("AdherenceTerm", model);

            var htmlContract = await RenderPartialViewToString("ContractEscritorioToSendByEmail", model);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);
            Stream fileStream = new MemoryStream(stream.ToArray());

            System.Net.Mail.Attachment attachment1 = new System.Net.Mail.Attachment(fileStream, "Contrato - GuardMed.pdf", MediaTypeNames.Application.Octet);

            await MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Termo de Adesão para " + model.CompanyName, html + TermAdherenceEmailText(model, token), new List<string>() { model.Email }, new List<System.Net.Mail.Attachment>() { attachment1 }, true);

            await BLL.MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Nova " + Configuration.InsuranceConfiguration.PartnerDisplayName + " criada.", RealEstateCreationEmailText(model), new List<string> { WEB.Configuration.InsuranceConfiguration.MailSenderDisplay }, null, true);

            await InsertCompanyTerms(model, fileStream);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        private async Task SendRealEstateAgencyEmail(Models.CompanyViewModel model)
        {
            var token = companyFunctions.NewTermAcceptToken(model.CompanyId.Value);
            var html = await RenderPartialViewToString("AdherenceTerm", model);

            var htmlContract = await RenderPartialViewToString("ContractToSendByEmail", model);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);
            Stream fileStream = new MemoryStream(stream.ToArray());

            System.Net.Mail.Attachment attachment1 = new System.Net.Mail.Attachment(fileStream, "Contrato - GuardMed.pdf", MediaTypeNames.Application.Octet);

            await MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Termo de Adesão para " + model.CompanyName, html + TermAdherenceEmailText(model, token), new List<string>() { model.Email }, new List<System.Net.Mail.Attachment>() { attachment1 }, true);

            await BLL.MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Nova " + Configuration.InsuranceConfiguration.PartnerDisplayName + " criada.", RealEstateCreationEmailText(model), new List<string> { WEB.Configuration.InsuranceConfiguration.MailSenderDisplay }, null, true);

            await InsertCompanyTerms(model, fileStream);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        private async Task SendNewRealEstateEmail(Models.CompanyViewModel realEstate)
        {
            var realEstateAgency = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(realEstate.ParentCompanyId));

            var htmlContract = await RenderPartialViewToString("ContractToSendByEmail", realEstateAgency);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);
            Stream fileStream = new MemoryStream(stream.ToArray());

            System.Net.Mail.Attachment attachment1 = new System.Net.Mail.Attachment(fileStream, "Contrato - GuardMed.pdf", MediaTypeNames.Application.Octet);

            await MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Nova " + Configuration.InsuranceConfiguration.PartnerDisplayName + " criada.", NewRealEstateEmailText(realEstate), new List<string>() { realEstateAgency.Email }, new List<System.Net.Mail.Attachment>() { attachment1 }, true);

            await InsertCompanyTerms(realEstateAgency, fileStream);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        private async Task InsertCompanyTerms(Models.CompanyViewModel model, Stream fileStream)
        {
            var user = await userManager.GetUserAsync(User);

            var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "AcceptTermsPDFs");
            if (!Directory.Exists(fileDirectory)) Directory.CreateDirectory(fileDirectory);

            var fileName = $"{Guid.NewGuid()}.pdf";

            var file = System.IO.File.Create(Path.Combine(fileDirectory, fileName));
            fileStream.CopyTo(file);
            file.Close();

            companyFunctions.InsertCompanyTerms(new DB.Models.CompanyAcceptTerms
            {
                CompanyId = model.CompanyId.Value,
                Email = model.Email,
                SentBy = user.Id,
                FileName = fileName
            });
        }

        [Authorize(Roles = "Administrator, Corretor")]
        private string TermAdherenceEmailText(CompanyViewModel model, string token)
        {
            return $"Olá <b>{model.CompanyName}</b>," +
            "<br/><br/>" +
            "Este e-mail contêm o termo de sua adesão, leia-o com atenção e clique no link abaixo para aceitá-lo:" +
            "<br/>" +
            "<b><a style='font-size: 15px;' href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("AcceptTerm", "Company") + "?companyId=" + model.CompanyId + "&token=" + token + "\">Aceitar os Termos de Adesão.</a></b>" +
            "<br/><br/></br></br>";
        }

        [Authorize(Roles = "Administrator, Corretor")]
        private string TermAdherenceEmailLinkText(CompanyViewModel model, string token)
        {
            string text = "<br/><br/>" +
            "Clique no link abaixo para aceitar os termos de adesão:" +
            "<br/>" +
            "<a href =\"" + HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + Url.Action("AcceptTerm", "Company") + "?companyId=" + model.CompanyId + "&token=" + token + "\">Aceitar os Termos de Adesão</a>";
            return text;
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

        [Authorize(Roles = "Administrator, Corretor")]
        [ActionName("Plataforma")]
        public IActionResult Corretora()
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            var company = new CompanyViewModel();
            company.CompanyTypeId = 1;

            return View("Index", company);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        [ActionName("Escritorio")]
        public async Task<IActionResult> Imobiliaria(int? parentCompanyId)
        {
            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

            if (!User.IsInRole("Administrator") && userCompany == null)
            {
                return RedirectToAction("NoCompany", "Account");
            }
            var company = new CompanyViewModel
            {
                ParentCompanyId = parentCompanyId,
                CompanyTypeId = 2
            };

            return View("Index", company);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> Index(int? companyTypeId, int? parentCompanyId)
        {
            if (!companyTypeId.HasValue) return Forbid();

            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;

            if (!User.IsInRole("Administrator") && (userCompany == null || companyTypeId == realEstateAgencyId))
            {
                return RedirectToAction("NoCompany", "Account");
            }

            var company = new CompanyViewModel();
            company.CompanyTypeId = companyTypeId.Value;
            if (parentCompanyId.HasValue) company.ParentCompanyId = parentCompanyId;

            return View(company);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult CompanyIndexComponent(int? companyTypeId, int? parentCompanyId)
        {
            if (!companyTypeId.HasValue) return Forbid();

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            if (companyTypeId == realEstateAgencyId && !User.IsInRole("Administrator")) return Forbid();

            var company = new CompanyViewModel();
            company.CompanyTypeId = companyTypeId.Value;
            if (parentCompanyId.HasValue) company.ParentCompanyId = parentCompanyId;

            return ViewComponent(typeof(ViewComponents.Company.CompanyIndexViewComponent), new { model = company });
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int? companyTypeId, int? parentCompanyId)
        {
            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();
            var imobiliariaTypeId = companyTypeFunctions.GetData().Single(c => c.ExternalCode == "IMOBILIARIA").CompanyTypeId;

            if (companyTypeId.HasValue)
            {
                query += " AND CompanyTypeId = @CompanyTypeId";
                param.Add(new SqlParameter("@CompanyTypeId", companyTypeId));
            }

            if (!User.IsInRole("Administrator"))
            {
                var user = await userManager.GetUserAsync(User);
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (userCompany != null)
                {
                    query += " AND ParentCompanyId = @ParentCompanyId";
                    param.Add(new SqlParameter("@ParentCompanyId", userCompany.CompanyId));
                }
                else
                {
                    return await Task.Run<IActionResult>(() => Json(new
                    {
                        recordsTotal = 0,
                        recordsFiltered = 0,
                        data = new List<DB.Models.Company>()
                    }));
                }
            }
            else
            {
                if (parentCompanyId.HasValue)
                {
                    query += " AND ParentCompanyId = @ParentCompanyId";
                    param.Add(new SqlParameter("@ParentCompanyId", parentCompanyId));
                }
            }

            IEnumerable<DB.Models.Company> d = this.companyFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()).ToList();

            var r = this.companyFunctions.GetDataListViewModel(d);

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        [HttpPost]
        [ActionName("RemoveCompany")]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            if (!companyFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Empresa não encontrada para exclusão.", true));

            if (companyFunctions.IsInCertificate(id))
            {
                return Json(new BLL.Shared.ReturnResult(0, "Não é possível excluir esta empresa, pois ela está em um certificado", true));
            }
            var user = await userManager.GetUserAsync(User);

            List<int> companyIds = new List<int>();
            companyIds.Add(id);
            var companies = companyFunctions.GetData();

            if (companies.Any(x => x.ParentCompanyId == id))
            {
                companyIds.AddRange(companies.Where(x => x.ParentCompanyId == id).Select(c => c.CompanyId).ToList());
            }

            userCompanyFunctions.DeleteByCompanyIds(companyIds);
            companyFunctions.DeleteRange(companyIds);


            foreach (var compId in companyIds)
            {
                auditLogFunctions.Log("CompanyViewModel", compId, "CompanyId", Utils.DBActionType.DELETE, companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(compId)), user.Id, "Exclusão");
            }

            return Json(new BLL.Shared.ReturnResult(0, "Empresa excluída com sucesso", false));
        }

        [HttpPost]
        [ActionName("GetRealEstatesByRealEstateAgencyId")]
        public async Task<IActionResult> GetRealEstatesByRealEstateAgencyId(int id)
        {
            if (!companyFunctions.Exists(id)) return Json(null);

            var user = await userManager.GetUserAsync(User);

            if (User.IsInRole("Corretor"))
            {
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (userCompany.CompanyId != id)
                    return Json(null);
            }

            var realEstates = companyFunctions.GetRealEstatesByRealEstateAgencyId(id);
            return Json(realEstates);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> GetAcceptedRealEstatesByRealEstateAgencyId(int id)
        {
            if (!companyFunctions.Exists(id)) return Json(null);

            var user = await userManager.GetUserAsync(User);

            if (User.IsInRole("Corretor"))
            {
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();


                if (userCompany.CompanyId != id)
                {
                    return Json(null);
                }
            }

            var realEstates = companyFunctions.GetRealEstatesByRealEstateAgencyId(id).Where(x => x.TermAccepted);
            return Json(realEstates);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult AdherenceTerm()
        {
            return View();
        }

        [AllowAnonymous]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> Accept(int? companyId, string token)
        {
            if (!companyId.HasValue || string.IsNullOrWhiteSpace(token))
            {
                return RedirectToAction("Index", "Home", new { message = "Houve um erro ao aceitar os termos." });
            }

            var company = companyFunctions.GetDataByID(companyId);

            if (company.TermAccepted)
            {
                return RedirectToAction("Index", "Home", new { message = "Os termos já foram aceitos." });
            }
            if (!companyFunctions.ValidateTermAcceptToken(companyId.Value, token))
            {
                return RedirectToAction("Index", "Home", new { message = "Houve um erro ao aceitar os termos." });
            }

            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            companyFunctions.Accept(companyId.Value, ip.ToString());

            var html = await RenderPartialViewToString("Welcome", company);

            if (company.CompanyTypeId == 1)
            {


                var arquivoCaminho = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "GuardMedWelcome.pdf");
                var arquivoBytes = System.IO.File.ReadAllBytes(arquivoCaminho);
                Stream arquivoStream = new MemoryStream(arquivoBytes);
                var anexo = new System.Net.Mail.Attachment(arquivoStream, "Boas Vindas Parceiros.pdf");

                var arquivoCaminho1 = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "GuardMedCadastro.pdf");
                var arquivoBytes1 = System.IO.File.ReadAllBytes(arquivoCaminho1);
                Stream arquivoStream1 = new MemoryStream(arquivoBytes1);
                var anexo1 = new System.Net.Mail.Attachment(arquivoStream1, "GuardMed Cadastro.pdf");

                var arquivoCaminho2 = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "GuardMedVendas.pdf");
                var arquivoBytes2 = System.IO.File.ReadAllBytes(arquivoCaminho2);
                Stream arquivoStream2 = new MemoryStream(arquivoBytes2);
                var anexo2 = new System.Net.Mail.Attachment(arquivoStream2, "GuardMed Vendas.pdf");



                await MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Boas Vindas " + (company.RazaoSocial == null ? company.FirstName + " " + company.LastName : company.RazaoSocial), html, new List<string>() { company.Email }, new List<System.Net.Mail.Attachment>() { anexo, anexo1, anexo2 }, true);

            }
            if (company.CompanyTypeId == 2)
            {


                var arquivoCaminho = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "GuardMedWelcome.pdf");
                var arquivoBytes = System.IO.File.ReadAllBytes(arquivoCaminho);
                Stream arquivoStream = new MemoryStream(arquivoBytes);
                var anexo = new System.Net.Mail.Attachment(arquivoStream, "Boas Vindas Parceiros.pdf");

                var arquivoCaminho1 = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "GuardMedEscritorios.pdf");
                var arquivoBytes1 = System.IO.File.ReadAllBytes(arquivoCaminho1);
                Stream arquivoStream1 = new MemoryStream(arquivoBytes1);
                var anexo1 = new System.Net.Mail.Attachment(arquivoStream1, "GuardMed Escritorios.pdf");

                await MailFunctions.SendAsync(WEB.Configuration.InsuranceConfiguration.ClientDisplayName + " - Boas Vindas " + (company.RazaoSocial != null ? company.FirstName + " " + company.LastName : company.RazaoSocial), html, new List<string>() { company.Email }, new List<System.Net.Mail.Attachment>() { anexo, anexo1 }, true);


            }


            return RedirectToAction("Index", "Home", new { message = "Termos de adesão aceitos com sucesso." });
        }

        [AllowAnonymous]
        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult AcceptTerm(int? companyId, string token)
        {
            if (!companyId.HasValue || string.IsNullOrWhiteSpace(token))
            {
                return View(new Models.CompanyAcceptTermViewModel
                {
                    HasError = true,
                    Message = "Houve um erro ao aceitar os termos.",
                    Company = new CompanyViewModel()
                });
            }

            var company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(companyId));

            return View(new Models.CompanyAcceptTermViewModel
            {
                Company = company,
                CompanyId = companyId,
                Token = token
            });
        }

        [AllowAnonymous]
        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult Download(int? companyId, string token)
        {
            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            var company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(companyId));

            if (company.CompanyTypeId == realEstateAgencyId)
            {


                var htmlContract = RenderPartialViewToString("ContractToSendByEmail", company).Result;
                var stream = new MemoryStream();
                iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);

                return File(stream.ToArray(), MediaTypeNames.Application.Octet, "Contrato - GuardMed.pdf");
            }

            if (company.CompanyTypeId == realEstateId)
            {
                var htmlContract = RenderPartialViewToString("ContractEscritorioToSendByEmail", company).Result;
                var stream = new MemoryStream();
                iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);

                return File(stream.ToArray(), MediaTypeNames.Application.Octet, "Contrato - GuardMed.pdf");
            }

            return Forbid();


        }

        [HttpPost]
        [ActionName("GetAgenciamentoVitalicioComissao")]
        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult GetAgenciamentoVitalicioComissao(int parentId)
        {
            if (!companyFunctions.Exists(parentId)) return Json(null);

            var parent = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(parentId));

            var DadosPlataforma = new DadosPlataforma
            {
                CompanyName = parent.CompanyName,
                Agenciamento = parent.Agenciamento,
                Vitalicio = parent.Vitalicio,
                Comissao = parent.Comissao
            };

            return Json(DadosPlataforma);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public IActionResult CompanyTermLogViewComponent(int companyId)
        {
            return ViewComponent(typeof(ViewComponents.Company.CompanyTermLogViewComponent), new { companyId });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> ListTermLogs(Models.DataTablesAjaxPostModel filter, int companyId)
        {
            string query = "CompanyId = @CompanyId";
            List<SqlParameter> param = new List<SqlParameter> {
                new SqlParameter("@CompanyId", companyId)
            };

            var d = companyAcceptTermsFunctions.GetDataViewModel(companyAcceptTermsFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> GetCompanyTerm(int companyTermLogId)
        {
            var termLog = companyAcceptTermsFunctions.GetDataByID(companyTermLogId);
            if (!await ValidateUser(termLog.CompanyId)) return Forbid();

            var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "AcceptTermsPDFs", termLog.FileName);

            if (!System.IO.File.Exists(fileDirectory)) return Forbid();

            var bytes = System.IO.File.ReadAllBytes(fileDirectory);

            return File(bytes, "application/pdf");
        }

        public async Task<IActionResult> GeneratePdfPlataforma(int? id, DateTime? ContractSentDate)
        {
            try
            {
                var model = companyFunctions.GetDataByID(id);
                var companyViewModel = companyFunctions.GetDataViewModel(model);
                companyViewModel.ContractSentDate = ContractSentDate;
                var htmlContract = await RenderPartialViewToString("ContractToSendByEmail", companyViewModel);
                var stream = new MemoryStream();
                iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);
                Stream fileStream = new MemoryStream(stream.ToArray());
                return File(fileStream, "application/pdf");

            }
            catch (Exception exception)
            {
                return Content(exception.Message);
            }
        }
        public async Task<IActionResult> GeneratePdfEscritorio(int? id, DateTime? ContractSentDate)
        {
            try
            {
                var model = companyFunctions.GetDataByID(id);
                var companyViewModel = companyFunctions.GetDataViewModel(model);
                companyViewModel.ContractSentDate = ContractSentDate;
                var htmlContract = await RenderPartialViewToString("ContractEscritorioToSendByEmail", companyViewModel);
                var stream = new MemoryStream();
                iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);
                Stream fileStream = new MemoryStream(stream.ToArray());
                return File(fileStream, "application/pdf");

            }
            catch (Exception exception)
            {
                return Content(exception.Message);
            }
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<bool> ValidateUser(int companyId)
        {
            var company = companyFunctions.GetDataByID(companyId);

            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id);

            if (User.IsInRole("Administrator")) return true;

            if (userCompany.Count() == 0) return false;
            var _userCompany = companyFunctions.GetDataByID(userCompany.First().CompanyId);

            if (_userCompany.CompanyId != companyId && company.ParentCompanyId != _userCompany.CompanyId) return false;

            return true;
        }
    }
}