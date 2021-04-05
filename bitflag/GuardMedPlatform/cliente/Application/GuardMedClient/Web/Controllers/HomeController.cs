using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Web.DTO;
using Web.DTO.Plano;
using Web.DTO.Welfare;
using Web.Models;
using Web.Services.Especialidade;
using Web.Services.SeguradoProfissional;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Services.SeguradoProfissional.SeguradoProfissionalService seguradoProfissionalService;
        Services.SeguradoProfissional.SeguradoProfissionalHistoricoService seguradoProfissionalHistoricoService;
        Services.Advisor.AdvisorService advisorService;
        Services.Benefits.BenefitsService benefitsService;
        EspecialidadeService especialidadeService;

        IHostingEnvironment hostingEnvironment;
        private ICompositeViewEngine _viewEngine;

        public HomeController(Services.SeguradoProfissional.SeguradoProfissionalService seguradoProfissionalService, Services.Advisor.AdvisorService advisorService, IHostingEnvironment hostingEnvironment, ICompositeViewEngine _viewEngine, Services.Benefits.BenefitsService benefitsService, SeguradoProfissionalHistoricoService seguradoProfissionalHistoricoService, EspecialidadeService especialidadeService)
        {
            this.seguradoProfissionalService = seguradoProfissionalService;
            this.advisorService = advisorService;
            this.hostingEnvironment = hostingEnvironment;
            this._viewEngine = _viewEngine;
            this.benefitsService = benefitsService;
            this.seguradoProfissionalHistoricoService = seguradoProfissionalHistoricoService;
            this.especialidadeService = especialidadeService;
        }
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => RedirectToAction("MyAccount"));
        }

        #region [MyAccount]
        public async Task<IActionResult> MyAccount()
        {
            int nameIdentifier = await GetUserId();
            return await Task.Run(() => View(this.seguradoProfissionalService.ObterSegurado(nameIdentifier)));
        }
        public async Task<IActionResult> MyAccountUpdate(DTO.SeguradoProfissionalViewModel model)
        {
            int nameIdentifier = await GetUserId();

            model.SeguradoProfissionalId = nameIdentifier;

            await seguradoProfissionalHistoricoService.Create(model.SeguradoProfissionalId); //Salva os dados atuais do segurado no historico
            await seguradoProfissionalService.UpdateBasicData(model);

            return await Task.Run(() => RedirectToAction("MyAccount", new { dataUpdated = true }));
        }

        public async Task<IActionResult> MyAccountUpdateProfessionalData(int? Especialidade1, int? Especialidade2, int? Especialidade3, bool upgradePlan)
        {
            int seguradoProfissionalId = await GetUserId();
            var entity = seguradoProfissionalService.GetDataById(seguradoProfissionalId);
            var oldPrice = entity.PrecoTotal;
            var newPrice = await seguradoProfissionalService.GetPriceForUpdateProfessionalData(seguradoProfissionalId, Especialidade1, Especialidade2, Especialidade3, upgradePlan);

            await seguradoProfissionalHistoricoService.Create(seguradoProfissionalId); //Salva os dados atuais do segurado no historico
            seguradoProfissionalService.UpdateProfessionalData(seguradoProfissionalId, Especialidade1, Especialidade2, Especialidade3, upgradePlan, out PlanoSeguroProfissionalViewModel upgradedPlan);


            if (newPrice.HasValue && oldPrice != newPrice)
            {
                #region [ENVIAR EMAIL]

                #region [OBTER VIEWMODEL DAS ESPECIALIDADE ADICIONADAS]
                List<EspecialidadeViewModel> especialidades = new List<EspecialidadeViewModel>();
                if (Especialidade1.HasValue) especialidades.Add(especialidadeService.GetViewModelById(Especialidade1.Value));
                if (Especialidade2.HasValue) especialidades.Add(especialidadeService.GetViewModelById(Especialidade2.Value));
                if (Especialidade3.HasValue) especialidades.Add(especialidadeService.GetViewModelById(Especialidade3.Value));
                #endregion

                var html = await RenderPartialViewToString("InsuredChangePlanEmail", new DTO.SeguradoProfissional.InsuredChangePlanEmailViewModel(seguradoProfissionalService.ToViewModel(entity), oldPrice.Value, newPrice.Value, upgradedPlan, especialidades));

                LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "logoGuardMed.png"), MediaTypeNames.Image.Jpeg);
                pic.ContentId = "LogoImg";
#if DEBUG
                await Services.Mail.MailFunctions.SendAsync("Alteração de dados profissional", html, new List<string> { "yuri.santana@bitflag.systems" }, null, new List<LinkedResource> { pic }, false, false);
#else
                await Services.Mail.MailFunctions.SendAsync("Alteração de dados profissional", html, new List<string> { "guardmed@guardmed.com.br" }, null, new List<LinkedResource> { pic }, false, false);
#endif
                #endregion
            }

            return await Task.Run(() => RedirectToAction("MyAccount", new { professionalDataUpdated = true }));
        }

        public async Task<IActionResult> GetPriceForUpdateProfessionalData(int? Especialidade1, int? Especialidade2, int? Especialidade3, bool upgradePlan)
        {
            int seguradoProfissionalId = await GetUserId();

            var r = await seguradoProfissionalService.GetPriceForUpdateProfessionalData(seguradoProfissionalId, Especialidade1, Especialidade2, Especialidade3, upgradePlan);
            var entity = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

            return await Task.Run(() => Json(new
            {
                hasError = !r.HasValue,
                totalPrice = r?.ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")),
                monthlyPrice = ((r ?? 0) / 12).ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")),
                priceHasChange = entity.PrecoTotal != r
            }));
        }

        public async Task<IActionResult> OldPolicy()
        {
            int nameIdentifier = await GetUserId();

            var data = seguradoProfissionalService.GetDataById(nameIdentifier);

            var insuranceLog = await seguradoProfissionalService.GetInsuranceLog(data.SeguradoProfissionalId);

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(insuranceLog.Single(x => x.Referencia == "Retroatividade").RetroatividadeArquivo), "application/pdf", "ApoliceAnterior.pdf"));
        }
        public async Task<IActionResult> CertificatePdf()
        {
            int nameIdentifier = await GetUserId();

            var model = await seguradoProfissionalService.GetCertificatePdfViewModel(nameIdentifier);

            var html = await RenderPartialViewToString("CertificatePdf", model);
            var stream = new MemoryStream();
            iText.Html2pdf.HtmlConverter.ConvertToPdf(html, stream);

            return await Task.Run(() => File(stream.ToArray(), "application/pdf", "Certificado.pdf"));
        }
        public async Task<IActionResult> LoadInsuredHistoric(int? seguradoProfissionalHistoricoId) => await Task.Run(async () => ViewComponent(typeof(ViewComponents.SeguradoProfissional.InsuredHistoricViewComponent), new { seguradoProfissionalHistoricoId, seguradoProfissionalId = await GetUserId() }));
        #endregion

        #region [LEGAL]
        public async Task<IActionResult> Legal() => await Task.Run(() => View());
        //public async Task<IActionResult> LegalArmor() => await Task.Run(() => View());
        public async Task<IActionResult> PreventiveAdvisor() => await Task.Run(() => View());
        #endregion

        #region [Prevent]
        public async Task<IActionResult> Preventive()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> SendEmailContact(string subject, string message)
        {
            var segurado = seguradoProfissionalService.GetViewModelById(await GetUserId());
            var html = await RenderPartialViewToString("PreventiveContactEmail", new DTO.Contact.ContactEmailViewModel { Mensagem = message.Replace("\n", "<br/>"), Segurado = segurado });
            LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "logoGuardMed.png"), MediaTypeNames.Image.Jpeg)
            {
                ContentId = "LogoImg"
            };

#if DEBUG
            await Services.Mail.MailFunctions.SendAsync(subject, html, new List<string> { "yuri.santana@bitflag.systems" }, null, new List<LinkedResource> { pic }, false, false, new List<string> { segurado.Email });
#else
            await Services.Mail.MailFunctions.SendAsync(subject, html, new List<string> { "juridico@guardmed.com.br" }, null, new List<LinkedResource> { pic }, false, false, new List<string> { segurado.Email });
#endif

            return await Task.Run(() => RedirectToAction("Preventive", new { emailSended = true }));
        }
        #endregion

        #region [Advisor]
        public async Task<IActionResult> Advisor()
        {
            return await Task.Run(() => View(advisorService.ObterAdvisor("", "", "")));
        }
        [HttpPost]
        [ActionName("Advisor")]
        public async Task<IActionResult> _Advisor(string nome, string uf, string cidade)
        {
            ViewData["nome"] = nome;
            ViewData["uf"] = uf;
            ViewData["cidade"] = cidade;

            return await Task.Run(() => View(advisorService.ObterAdvisor(nome, uf, cidade)));
        }
        #endregion

        #region [Welfare]
        public async Task<IActionResult> Welfare()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> SendWelfareSolicitation(DateTime dateSolicitation, int period)
        {
            var html = await RenderPartialViewToString("WelfareEmail", new WelfareEmailViewModel(seguradoProfissionalService.GetViewModelById(await GetUserId()), period, dateSolicitation));

            LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "logoGuardMed.png"), MediaTypeNames.Image.Jpeg);
            pic.ContentId = "LogoImg";
#if DEBUG
            await Services.Mail.MailFunctions.SendAsync("Solicitação de atendimento pisicológico", html, new List<string> { "yuri.santana@bitflag.systems" }, null, new List<LinkedResource> { pic }, false, false);
#else
            await Services.Mail.MailFunctions.SendAsync("Solicitação de atendimento pisicológico", html, new List<string> { "bemestar@guardmed.com.br" }, null, new List<LinkedResource> { pic }, false, false);
#endif


            return await Task.Run(() => RedirectToAction("Welfare", new { sended = true }));
        }
        #endregion

        #region [Benefits]
        public async Task<IActionResult> Benefits()
        {
            return await Task.Run(async () => View(await benefitsService.GetViewModelAsNoTrackingAsync(x => x.IsActive)));
        }
        [HttpPost]
        [ActionName("Benefits")]
        public async Task<IActionResult> _Benefits()
        {
            return await Task.Run(async () => View(await benefitsService.GetViewModelAsNoTrackingAsync(x => x.IsActive)));
        }
        #endregion

        #region [Contact]
        public async Task<IActionResult> Contact() => await Task.Run(() => View());
        public async Task<IActionResult> ContactSendEmail(string subject, string message)
        {
            var segurado = seguradoProfissionalService.GetViewModelById(await GetUserId());
            var html = await RenderPartialViewToString("ContactEmail", new DTO.Contact.ContactEmailViewModel { Mensagem = message.Replace("\n", "<br/>"), Segurado = segurado });
            LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "logoGuardMed.png"), MediaTypeNames.Image.Jpeg)
            {
                ContentId = "LogoImg"
            };

#if DEBUG
            await Services.Mail.MailFunctions.SendAsync(subject, html, new List<string> { "lucas.araujo@bitflag.systems" }, null, new List<LinkedResource> { pic }, false, false, null, "Sinistro - GuardMed");
#else
            await Services.Mail.MailFunctions.SendAsync(subject, html, new List<string> { "juridico@guardmed.com.br" }, null, new List<LinkedResource> { pic }, false, false, new List<string> { segurado.Email }, "Sinistro - GuardMed");
#endif

            return await Task.Run(() => RedirectToAction("Contact", new { emailSended = true }));
        }
        #endregion

        public async Task<IActionResult> Download(string name)
        {
            var path = Path.Combine(hostingEnvironment.ContentRootPath, "Files", name);
            if (!System.IO.File.Exists(path))
                return await Task.Run(() => NotFound());

            var file = System.IO.File.ReadAllBytes(path);

            return await Task.Run(() => File(file, "application/octet-stream", name));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
        }

        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }

        private Task<int> GetUserId()
        {
            return Task.Run(() => int.Parse(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value));
        }
    }
}
