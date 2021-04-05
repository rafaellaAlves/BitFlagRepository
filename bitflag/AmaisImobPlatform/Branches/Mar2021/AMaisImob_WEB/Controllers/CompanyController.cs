using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AMaisImob_WEB.BLL;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AMaisImob_WEB.Controllers
{
    [Authorize(Roles = "Administrator, Corretor")]
    public class CompanyController : Controller
    {
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly UserFunctions userFunctions;
        private ICompositeViewEngine viewEngine;
        private readonly BLL.CategoryFunctions categoryFunctions;
        private readonly BLL.MailFunctions mailFunctions;

        public CompanyController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager, ICompositeViewEngine viewEngine, UserFunctions userFunctions, BLL.MailFunctions mailFunctions)
        {
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.companyTypeFunctions = new AMaisImob_WEB.BLL.CompanyTypeFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
            this.viewEngine = viewEngine;
            this.categoryFunctions = new BLL.CategoryFunctions(context);
            this.userFunctions = userFunctions;
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

            return $"A imobiliária <b>{model.CompanyName}</b> (<b>{model.CompanyDocument.CNPJOrCPFmask()}</b>) foi criada para a corretora <b>{parentCompanyData}</b>." +
                $"<br/><br/>" +
                $"<a href =\"{HttpContext.Request.Scheme}://{ HttpContext.Request.Host + Url.Action("Manage", "Company")}?id={model.CompanyId}\">Clique aqui</a> para ser redirecionado e obter mais informações sobre a imobliária.";
        }
        #endregion

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

            return View(company);
        }

        public IActionResult CorretoraManage(int? id)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            var company = new CompanyViewModel();
            if (id.HasValue) company = companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(id));
            else company.CompanyTypeId = 1;

            return View("Manage", company);
        }

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

            ViewData["Categorias"] = categoryFunctions.GetData().ToList();

            return ViewComponent(typeof(ViewComponents.Company.CompanyManageViewComponent), new { model = model });
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(Models.CompanyViewModel model, UserViewModel user)
        {
            Utils.DBActionType dbActionType;
            if (model.CompanyId.HasValue) dbActionType = Utils.DBActionType.UPDATE;
            else dbActionType = Utils.DBActionType.CREATE;

            var realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            var realEstateId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            if (model.CompanyTypeId == realEstateAgencyId && !User.IsInRole("Administrator")) return Forbid();

            if (!model.CompanyId.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(model.Cnpj) && companyFunctions.ExistCNPJ(model.Cnpj))
                    return Json(new BLL.Shared.ReturnResult(0, "CNPJ já utilizado", true));
            }

            if (!string.IsNullOrWhiteSpace(user.Email)) model.Email = user.Email;
            model.CompanyId = companyFunctions.CreateOrUpdate(model);

            if (model.CompanyTypeId == realEstateId && dbActionType == Utils.DBActionType.CREATE)
            {
                var token = companyFunctions.NewTermAcceptToken(model.CompanyId.Value);

                var html = await RenderPartialViewToString("AdherenceTerm", model);

                if (!string.IsNullOrWhiteSpace(user.Email))
                    await mailFunctions.SendAsync("A+Imob - Termo de Adesão para " + model.CompanyName, TermAdherenceEmailText(model, token) + html, new List<string>() { user.Email }, new List<System.Net.Mail.Attachment>(), true);

                await mailFunctions.SendAsync("A+Imob - Nova imobiliária criada.", RealEstateCreationEmailText(model), new List<string> { "contato@amaisimob.com.br" }, null);
            }

            var loggedUser = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("CompanyViewModel", model.CompanyId.Value, "CompanyId", dbActionType, companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.CompanyId)), loggedUser.Id);

            if (!string.IsNullOrWhiteSpace(user.Email) && (!string.IsNullOrWhiteSpace(user.Password) || user.UserId.HasValue) && !string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
            {
                var dbActionUser = user.UserId.HasValue ? DBActionType.UPDATE : DBActionType.CREATE;

                user.LastHandler = loggedUser.Id;
                user.IsActive = true;
                var userId = userFunctions.CreateOrUpdate(user);

                if (userId != 0)
                {
                    auditLogFunctions.Log("UserViewModel", userId, "UserId", dbActionUser, userFunctions.GetDataViewModel(userFunctions.GetDataByID(userId)), loggedUser.Id);

                    userFunctions.ClearUserRoles(userId);
                    await companyFunctions.TryClearUserPartner(userId);
                    userFunctions.AddUserToRole(userId, "ImobiliarioSocio");

                    userCompanyFunctions.Create(new Models.UserCompanyViewModel { CompanyId = model.CompanyId.Value, UserId = userId });

                    await companyFunctions.AddUserPartner(model.CompanyId.Value, userId);
                }
            }
            return Json(new BLL.Shared.ReturnResult(model.CompanyId.Value, "", false));
        }

        private string TermAdherenceEmailText(CompanyViewModel model, string token)
        {
            return $"Olá <b>{model.CompanyName}</b>," +
            "<br/><br/>" +
            //"Este e-mail contêm o termo de adesão para sua imobiliária, leia-o com atenção e para aceita-lo basta clicar no link ao final do e-mail." +
            "Este e-mail contêm o termo de adesão para sua imobiliária, leia-o com atenção e clique no botão abaixo para aceitá-lo:" +
            "<br/><br/>" +
            "<div style=\"width:100%; text-align: center;\">" +
            $"<a href=\"{HttpContext.Request.Scheme}://{HttpContext.Request.Host + Url.Action("AcceptTerm", "Company")}?companyId={model.CompanyId}&token={token}\" style=\" display: inline-block; font-weight: 400; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid transparent; padding: 0.375rem 0.75rem; font-size: 1rem; text-decoration: none; line-height: 1.5; border-radius: 0.25rem; background: #007500; color: white;\">&#x2713; Aceitar os Termos de Adesão</a>" +
            "</div>" +
            "<br/><hr /><br/>";
        }

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

        public IActionResult Corretora()
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            var company = new CompanyViewModel();
            company.CompanyTypeId = 1;

            return View("Index", company);
        }

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

        [AllowAnonymous]
        //[Route("[controller]/[action]?{companyReference?}")]
        public async Task<IActionResult> New(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference)) return Forbid();

            return await Task.Run(() => View(model: reference));
        }

        [AllowAnonymous]
        public async Task<IActionResult> ValidateNew(CompanyViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Cnpj) && companyFunctions.ExistCNPJ(model.Cnpj))
                return await Task.Run(() => Json(new BLL.Shared.ReturnResult(0, "CNPJ já utilizado", true)));

            return await Task.Run(() => Json(new BLL.Shared.ReturnResult(0, "", false)));
        }

        [HttpPost]
        [ActionName("New")]
        [AllowAnonymous]
        public async Task<IActionResult> _New(CompanyViewModel model, UserViewModel user, string companyReference)
        {
            model.CompanyTypeId = companyTypeFunctions.GetDataByExternalCode("IMOBILIARIA").CompanyTypeId;
            model.ParentCompanyId = (await companyFunctions.GetDataByCompanyReference(companyReference)).CompanyId;
            model.CategoryId = categoryFunctions.GetDataAsNoTracking(x => x.ExternalCode == "CLASSIC").First().CategoryId;

            if (!string.IsNullOrWhiteSpace(user.Email)) model.Email = user.Email;
            model.CompanyId = companyFunctions.CreateOrUpdate(model);

            #region [SEND ACCEPT TERM]
            var token = companyFunctions.NewTermAcceptToken(model.CompanyId.Value);
            var html = await RenderPartialViewToString("AdherenceTerm", model);

            if (!string.IsNullOrWhiteSpace(user.Email))
                await mailFunctions.SendAsync("A+Imob - Termo de Adesão para " + model.CompanyName, TermAdherenceEmailText(model, token) + html, new List<string>() { user.Email }, new List<System.Net.Mail.Attachment>(), true);

            await mailFunctions.SendAsync("A+Imob - Nova imobiliária criada.", RealEstateCreationEmailText(model), new List<string> { "contato@amaisimob.com.br" }, null);
            #endregion

            AMaisImob_DB.Models.User loggedUser = null;
            if(User.Identity.IsAuthenticated)
                await userManager.GetUserAsync(User);

            auditLogFunctions.Log("CompanyViewModel", model.CompanyId.Value, "CompanyId", DBActionType.CREATE, companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(model.CompanyId)), loggedUser == null? -1 : loggedUser.Id);

            if (!string.IsNullOrWhiteSpace(user.Email) && (!string.IsNullOrWhiteSpace(user.Password) || user.UserId.HasValue) && !string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
            {
                var dbActionUser = user.UserId.HasValue ? DBActionType.UPDATE : DBActionType.CREATE;

                user.LastHandler = loggedUser == null ? -1 : loggedUser.Id;
                user.IsActive = true;
                var userId = userFunctions.CreateOrUpdate(user);

                if (userId != 0)
                {
                    auditLogFunctions.Log("UserViewModel", userId, "UserId", dbActionUser, userFunctions.GetDataViewModel(userFunctions.GetDataByID(userId)), loggedUser == null ? -1 : loggedUser.Id);

                    userFunctions.ClearUserRoles(userId);
                    await companyFunctions.TryClearUserPartner(userId);
                    userFunctions.AddUserToRole(userId, "ImobiliarioSocio");

                    userCompanyFunctions.Create(new Models.UserCompanyViewModel { CompanyId = model.CompanyId.Value, UserId = userId });

                    await companyFunctions.AddUserPartner(model.CompanyId.Value, userId);
                }
            }
            return await Task.Run(() => RedirectToAction("New", new { newRealState = true, token, reference = companyReference, model.CompanyId }));
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
                        data = new List<AMaisImob_DB.Models.Company>()
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

            IEnumerable<AMaisImob_DB.Models.Company> d = this.companyFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()).ToList();

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
        public IActionResult GetRealEstatesByRealEstateAgencyId(int id)
        {
            if (!companyFunctions.Exists(id)) return null;

            var realEstates = companyFunctions.GetRealEstatesByRealEstateAgencyId(id);
            return Json(realEstates);
        }
        [HttpPost]
        [ActionName("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            if (!companyFunctions.Exists(id)) return null;

            var categoryId = companyFunctions.GetCategory(id);
            string categoryName = null;
            if (categoryId != null)
            {
                categoryName = categoryFunctions.GetDataByID(categoryId).Description;
            }

            return Json(new Models.CategoryViewModel
            {
                CategoryId = categoryId,
                CategoryName = categoryName
            });
        }

        public IActionResult AdherenceTerm()
        {
            return View();
        }

        [AllowAnonymous]
        [ActionName("AcceptTerm")]
        [HttpPost]
        public IActionResult _AcceptTerm(int? companyId, string token)
        {
            var company = companyFunctions.GetDataByID(companyId);
            string message = null;

            if (!companyId.HasValue || string.IsNullOrWhiteSpace(token))
            {
                message = "Houve um erro ao aceitar os termos.";
            }
            if (company.TermAccepted)
            {
                message = "Os termos desta imobiliária já foram aceitos.";
            }
            if (!companyFunctions.ValidateTermAcceptToken(companyId.Value, token))
            {
                message = "Houve um erro ao aceitar os termos.";
            }

            companyFunctions.Accept(companyId.Value, HttpContext.Connection.RemoteIpAddress.ToString());

            return View(new Models.CompanyAcceptTermViewModel
            {
                Company = companyFunctions.GetDataViewModel(company),
                CompanyId = companyId,
                Token = token,
                Message = message ?? "Termos de adesão aceitos com sucesso."
            });
        }

        [AllowAnonymous]
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

        public async Task<IActionResult> Download(int id)
        {
            var htmlContract = RenderPartialViewToString("AcceptTermClean", id).Result;
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlContract, stream);

            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "Contrato - AMAISIMOB.pdf"));

        }


    }
}