using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Service;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Service;
using DTO.Shared;
using Web.Utils;
using Services.Client;
using DTO.Client;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using DTO.Utils;
using Services.Email;
using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ServiceController : Shared.BaseCRUDController<Service, ServiceViewModel, int>
    {
        private readonly ServiceListServices serviceListServices;
        private readonly ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices;
        private readonly ServiceClientCollectionAddressServices serviceClientCollectionAddressServices;
        private readonly ServiceServices serviceServices;
        private readonly ClientContactServices clientContactServices;
        private readonly ServiceSituationServices serviceSituationServices;
        private readonly ServiceStatusServices serviceStatusServices;
        private readonly ClientServices clientServices;
        private readonly EmailServices emailServices;
        private readonly ICompositeViewEngine viewEngine;
        private readonly IConfiguration configuration;

        private readonly string ServiceOrderPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "ServiceOrder");

        public ServiceController(ServiceServices service, UserManager<User> userManager, ServiceListServices serviceListServices, ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices, ServiceClientCollectionAddressServices serviceClientCollectionAddressServices, ClientContactServices clientContactServices, ServiceSituationServices serviceSituationServices, ServiceStatusServices serviceStatusServices, ClientServices clientServices, ICompositeViewEngine viewEngine, EmailServices emailServices, IConfiguration configuration) : base(service, userManager)
        {
            this.serviceListServices = serviceListServices;
            this.serviceResidueFamilyPriceServices = serviceResidueFamilyPriceServices;
            this.serviceClientCollectionAddressServices = serviceClientCollectionAddressServices;
            this.serviceServices = service;
            this.clientContactServices = clientContactServices;
            this.serviceSituationServices = serviceSituationServices;
            this.serviceStatusServices = serviceStatusServices;
            this.clientServices = clientServices;
            this.viewEngine = viewEngine;
            this.emailServices = emailServices;
            this.configuration = configuration;
        }

        #region [PAGES]
        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> Manage(int? id) => await Task.Run(async () => View(new EntityViewMode<ServiceViewModel>(ViewMode.Editable, id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new ServiceViewModel())));
        public async Task<IActionResult> View(int? id) => await Task.Run(async () => View("Manage", new EntityViewMode<ServiceViewModel>(ViewMode.NonEditable, id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new ServiceViewModel())));
        public async Task<IActionResult> Print(int id) => await Task.Run(async () => View(await serviceServices.GetServicePrintViewModel(id)));
        public async Task<IActionResult> SignedServiceEmail() => await Task.Run(() => View());
        [AllowAnonymous]
        public async Task<IActionResult> AcceptTerm(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return await Task.Run(() => View((ServiceViewModel)null));

            var entity = await serviceServices.GetDataByAcceptTermToken(token);

            if (entity != null)
            {
                if (entity.TermAccepted) return await Task.Run(() => RedirectToAction("AcceptTerm", new { token = "", accepted = true, acceptedBy = entity.ContactName }));
                if (DateTime.Compare(entity.AcceptTermEmailSendedDate.Value.AddDays(7), DateTime.Now) < 0) return await Task.Run(() => View("AcceptTerm", null));
            }

            return await Task.Run(() => View(entity == null ? null : serviceServices.ToViewModel(entity)));
        }
        #endregion

        #region [XHR]

        [RequireRouteValues(new string[] { "serviceStatusId", "clientId" })]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int? serviceStatusId, int? clientId)
        {
            ListParameters.AddParameter("IsDeleted", false);
            //ListParameters.AddParameter("IsActive", true);

            if (serviceStatusId.HasValue) ListParameters.AddParameter("ServiceStatusId", serviceStatusId);
            if (clientId.HasValue) ListParameters.AddParameter("ClientId", clientId);

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => serviceListServices.ToViewModel(serviceListServices.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters)));
        }

        public async Task<IActionResult> _ManageForm(ServiceViewModel model, List<ServiceResidueFamilyPriceViewModel> serviceResidueFamilies, List<int> clientCollectionAddressId)
        {
            if (!model.ServiceId.HasValue)//Criação
            {
                model.Code = await serviceServices.GetNewCode(model.ClientId.Value);
                model.ServiceSituationId = (await serviceSituationServices.GetDataByExternalCode("ADIMPLENTE")).ServiceSituationId;
                model.ServiceStatusId = (await serviceStatusServices.GetDataByExternalCode("SOLICITACAOCRIADA")).ServiceStatusId;
                model.IsActive = true;
            }

            //if (model.ServiceId.HasValue)
            //{
            //    model.TotalPrice = (await service.GetDataByIdAsync(model.ServiceId.Value)).FreightPrice + serviceResidueFamilies.Sum(x => x.Price.Value);
            //}
            //else
            //{
            //    model.TotalPrice = model.FreightPrice.Value + serviceResidueFamilies.Sum(x => x.Price.Value);
            //}

            var r = (JsonResult)await base.ManageAjax(model);
            var value = (dynamic)r.Value;
            var id = (int)value.id;

            await SaveContractResidues(serviceResidueFamilies, id);
            await SaveContractAddress(clientCollectionAddressId, id);

            var entity = await service.GetDataByIdAsync(id);
            if (!entity.TermAccepted)//Enquanto os termos não foram aceitos é possivel alterar o contato principal
            {
                if (model.ServiceId.HasValue) await serviceServices.UpdateMainContact(model);

                await clientContactServices.RemoveMainContract(entity.ClientId);
                model.ClientId = entity.ClientId;

                if (!clientContactServices.Exist(model, out ClientContactViewModel contact))//Dentro do Metodo "Exist" ocorre uma atualização caso o contato principal seja o mesmo que veio da tela
                {
                    await clientContactServices.CreateAsync(contact);
                }
                else
                {
                    var clientContact = contact.CopyToEntity<ClientContact>();
                    await clientContactServices.UpdateAsync(clientContact);
                }
            }

            if (entity.CreationConfirmedBy.HasValue)
                return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
            else
                return await Task.Run(() => RedirectToAction("Print", new { id, success = true, creation = true }));
        }

        private async Task SaveContractResidues(List<ServiceResidueFamilyPriceViewModel> serviceResidueFamilies, int serviceId)
        {
            await serviceResidueFamilyPriceServices.DeleteDefinitilyByServiceId(serviceId);
            serviceResidueFamilies.ForEach(x => x.ServiceId = serviceId);
            await serviceResidueFamilyPriceServices.CreateRangeAsync(serviceResidueFamilies);
        }

        private async Task SaveContractAddress(List<int> addressesId, int serviceId)
        {
            await serviceClientCollectionAddressServices.DeleteDefinitivelyByServiceId(serviceId);
            await serviceClientCollectionAddressServices.CreateRangeAsync(addressesId.Select(x => new ServiceClientCollectionAddress(serviceId, x)));
        }

        public async Task<IActionResult> Cancel(int id) => await Task.Run(async () => Json(await serviceServices.Cancel(id)));

        public async Task<IActionResult> SendServiceEmail(int serviceId, string to, string replyTo, string bcc)
        {
            if (!configuration.GetValue<bool>("Emails:SendServiceEmail"))
                return await Task.Run(() => Json(new { success = false, message = "O envio de e-mail está desabilitado." }));

            await serviceServices.GetAndSetEmailTokenAsync(serviceId);
            await serviceServices.SetTermAcceptEmailSendedDate(serviceId);
            var entity = await service.GetDataByIdAsync(serviceId);
            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);

            #region [Get Email Body]
            var model = await serviceServices.GetServicePrintViewModel(serviceId);
            model.UsingForEmail = true;
            var htmlEmail = await RenderPartialViewToString("Print", model, viewEngine);
            #endregion

            #region [Get Email PDF]
            model.UsingForEmail = false;
            model.UsingForPdf = true;
            var stream = new MemoryStream();
            var htmlPdf = await RenderPartialViewToString("Print", model, viewEngine);
            iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlPdf, stream);
            #endregion

            LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg)
            {
                ContentId = "Logo"
            };

            #region [Adjust on Recipients]
            var _to = new List<string>();
            if (to != null) _to = to.Split(";").Select(x => x.Trim()).ToList();
            while (_to.Contains("")) _to.Remove(""); //caso o usuário insira ";" desnecessário

            var _replyTo = new List<string>();
            if (replyTo != null) _replyTo = replyTo.Split(";").Select(x => x.Trim()).ToList();
            while (_replyTo.Contains("")) _replyTo.Remove("");//caso o usuário insira ";" desnecessário

            var _bcc = new List<string>();
            if (bcc != null) _bcc = bcc.Split(";").Select(x => x.Trim()).ToList();
            while (_bcc.Contains("")) _bcc.Remove(""); //caso o usuário insira ";" desnecessário
            #endregion

            var r = emailServices.Send(
                $"Destine Já - Ordem de Serviço \"{entity.Code}\" - {client.Name}",
                htmlEmail,
                _to,
                _replyTo,
                _bcc,
                new List<System.Net.Mail.Attachment> { new System.Net.Mail.Attachment(new MemoryStream(stream.ToArray()), $"Ordem de Serviço \"{entity.Code}\".pdf", MediaTypeNames.Application.Octet) },
                new List<System.Net.Mail.LinkedResource> { pic },
                false);

            if (r) await serviceServices.SetTermAcceptEmailSended(serviceId);

            return await Task.Run(() => Json(new { success = r, message = (r ? "E-mail enviado com sucesso!" : "Houve um erro inesperado ao enviar o e-mail, confira os dados informados e tente novamente.") }));
        }

        [AllowAnonymous]
        public async Task<IActionResult> AcceptTermValidate(int serviceId, string fullName, string cpf) => await Task.Run(async () =>
        {
            var r = await serviceServices.ValidateAcceptTerm(serviceId, fullName, cpf);
            return Json(new { success = r, message = (r ? "" : "Você não tem permissão para aceitar este serviço, verifique os dados informados e tente novamente.") });
        });

        [ActionName("AcceptTerm")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> _AcceptTerm(int serviceId, string fullName, string cpf)
        {
            var entity = await service.GetDataByIdAsync(serviceId);
            if (!await serviceServices.ValidateAcceptTerm(serviceId, fullName, cpf))
            {
                return await Task.Run(() => RedirectToAction("AcceptTerm", new { token = entity.AcceptTermToken, unvalidated = true }));
            }

            await serviceServices.AcceptTerm(serviceId);

            if (configuration.GetValue<bool>("Emails:SendServiceSignedEmail"))
                await SendServiceSignedEmail(entity);

            return await Task.Run(() => RedirectToAction("AcceptTerm", new { token = "", accepted = true }));
        }

        async Task SendServiceSignedEmail(Service entity)
        {
            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);

            #region [CLIENT EMAIL]
            var html_Client = await RenderPartialViewToString("SignedServiceEmail", null, viewEngine);

#if DEBUG
            emailServices.Send($"{client.Name}, seja bem-vindo(a) à Destine Já.", html_Client, null);
#else
            emailServices.Send($"{client.Name}, seja bem-vindo(a) à Destine Já.", html_Client, new List<string> { entity.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("SignedService_AdminEmail", service.ToViewModel(entity), viewEngine);
#if DEBUG
            emailServices.Send($"O.S Assinada - O.S \"{entity.Code}\" - {client.Name}", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"O.S Assinada - O.S \"{entity.Code}\" - {client.Name}", html_Admin, new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" });
#endif
            #endregion
        }

        public async Task<IActionResult> UploadServiceOrder(int serviceId)
        {
            if (!Directory.Exists(ServiceOrderPath)) Directory.CreateDirectory(ServiceOrderPath);

            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return await Task.Run(() => Json(new { hasError = true, message = "Nenhum arquivo recebido pelo servidor." }));

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return await Task.Run(() => Json(new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." }));
                }
                if (archive.FileName != "")
                {
                    return await Task.Run(() => Json(new { hasError = true, message = "Arquivo inválido." }));
                }
            }
            #endregion

            if (serviceServices.TryGetServiceOrderFile(serviceId, out Service entity)) //Deleting old file
            {
                System.IO.File.Delete(Path.Combine(ServiceOrderPath, entity.ServiceOrderFileGuidName));
            }

            try
            {
                var guidName = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(ServiceOrderPath, guidName);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                var fileName = archive.FileName;
                var mimeType = archive.ContentType;
                await serviceServices.UpdateServiceOrderFile(serviceId, guidName, fileName, mimeType);

                return await Task.Run(() => Json(new { hasError = false, fileName, message = "Arquivo importado com sucesso!" }));
            }
            catch
            {
                return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao importar o arquivo." }));
            }
        }

        public async Task<IActionResult> GetServiceOrder(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(ServiceOrderPath, entity.ServiceOrderFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.ServiceOrderFileName}\" não foi encontrado pra download.";
                return await Task.Run(() => RedirectToAction("Manage", "Service", new { id = entity.ServiceId, error = true }));
            }

            Response.ContentType = entity.ServiceOrderMimeType;
            HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + path);
            await Response.Body.WriteAsync(System.IO.File.ReadAllBytes(path));
            await Response.Body.FlushAsync();
            Response.Body.Close();
            await Response.CompleteAsync();

            return await Task.Run(() => View());
        }
        public async Task<IActionResult> DownloadServiceOrder(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(ServiceOrderPath, entity.ServiceOrderFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.ServiceOrderFileName}\" não foi encontrado pra download.";
                return await Task.Run(() => RedirectToAction("Manage", "Service", new { id = entity.ServiceId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.ServiceOrderMimeType, entity.ServiceOrderFileName));
        }

        public async Task<IActionResult> RemoveServiceOrder(int serviceId)
        {

            if (serviceServices.TryGetServiceOrderFile(serviceId, out Service entity)) //Deleting old file
                System.IO.File.Delete(Path.Combine(ServiceOrderPath, entity.ServiceOrderFileGuidName));

            await serviceServices.UpdateServiceOrderFile(serviceId, null, null, null);

            return await Task.Run(() => Json(new { success = true, message = "Arquivo removido com sucesso!" }));
        }

        public async Task<IActionResult> GetLastDemandClientServiceInfo(int clientId) => await Task.Run(async () => Json(await serviceServices.GetLastDemandClientServiceInfo(clientId)));

        public async Task<IActionResult> CreationConfirm(int id)
        {
            var userId = (await GetUser()).Id;

            await serviceServices.CreationConfirm(id, userId);

            var entity = await service.GetDataByIdAsync(id);

#if DEBUG
            await SendServiceEmail(id, "", "", "");
#else
            await SendServiceEmail(id, entity.ContactEmail, "", "");
#endif

            return await Task.Run(() => RedirectToAction("Manage", new { id, success = true })); //, creation = true
        }
        #endregion

        #region [COMPONENT]
        public async Task<IActionResult> LoadServiceHistoricComponent(int clientId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Service.ServiceHistoricViewComponent), new { clientId, loadFromController = true }));
        #endregion
    }
}