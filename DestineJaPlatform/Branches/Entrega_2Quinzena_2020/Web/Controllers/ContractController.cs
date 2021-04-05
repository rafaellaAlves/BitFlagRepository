using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using AspNetIdentityDbContext;
using DTO.Client;
using DTO.Contract;
using DTO.Shared;
using DTO.Utils;
using iText.StyledXmlParser.Node;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Services.Account;
using Services.Client;
using Services.Contract;
using Services.Demand;
using Services.Email;
using Services.Route;
using Services.Shared;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ContractController : Shared.BaseCRUDController<Contract, ContractViewModel, int>
    {
        private readonly ContractListServices contractListServices;
        private readonly ContractResidueServices contractResidueServices;
        private readonly ContractServices contractServices;
        private readonly ContractClientCollectionAddressService contractClientCollectionAddressService;
        private readonly RouteClientServices routeClientServices;
        private readonly string ContractFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "Contract");
        private readonly ContractSituationServices contractSituationServices;
        private readonly ContractStatusServices contractStatusServices;
        private readonly DemandResidueFamilyServices demandResidueFamilyServices;
        private readonly ClientServices clientServices;
        private readonly EmailServices emailServices;
        private readonly ICompositeViewEngine viewEngine;
        private readonly IConfiguration configuration;

        public ContractController(ContractServices service, UserManager<User> userManager, ContractListServices contractListServices, ContractResidueServices contractResidueServices, ContractClientCollectionAddressService contractClientCollectionAddressService, ContractSituationServices contractSituationServices, RouteClientServices routeClientServices, ContractStatusServices contractStatusServices, DemandResidueFamilyServices demandResidueFamilyServices, ICompositeViewEngine viewEngine, ClientServices clientServices, EmailServices emailServices, IConfiguration configuration) : base(service, userManager)
        {
            this.contractListServices = contractListServices;
            this.contractResidueServices = contractResidueServices;
            this.contractServices = service;
            this.contractClientCollectionAddressService = contractClientCollectionAddressService;
            this.contractSituationServices = contractSituationServices;
            this.routeClientServices = routeClientServices;
            this.contractStatusServices = contractStatusServices;
            this.demandResidueFamilyServices = demandResidueFamilyServices;
            this.viewEngine = viewEngine;
            this.clientServices = clientServices;
            this.emailServices = emailServices;
            this.configuration = configuration;
        }

        #region [PAGES]
        public async Task<IActionResult> Index(bool goToServices = false) => await Task.Run(() => goToServices ? (IActionResult)RedirectToAction("Service") : View());
        public async Task<IActionResult> Proposal() => await Task.Run(() => View("Index"));
        public async Task<IActionResult> Service() => await Task.Run(() => RedirectToAction("Index", "Service"));

        public async Task<IActionResult> Manage(int? id) => await Task.Run(async () => View(new EntityViewMode<ContractManageParametersViewModel>(ViewMode.Editable, new ContractManageParametersViewModel(id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new ContractViewModel()))));
        public async Task<IActionResult> View(int? id) => await Task.Run(async () => View("Manage", new EntityViewMode<ContractManageParametersViewModel>(ViewMode.NonEditable, new ContractManageParametersViewModel(id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new ContractViewModel()))));
        public async Task<IActionResult> Print(int id) => await Task.Run(async () => View(await contractServices.GetContractPrintViewModel(id)));
        public async Task<IActionResult> ListPrint(List<string> models, string search, string renewStatus, string contractSituation) => await Task.Run(() => View(new ContractListPrintViewModel { Items = models.Select(x => Newtonsoft.Json.JsonConvert.DeserializeObject<ContractListViewModel>(x)).ToList(), ContractSituation = contractSituation, RenewStatus = renewStatus, Search = search }));

        //public async Task<IActionResult> SignedContractEmail() => await Task.Run(() => View());
        //public async Task<IActionResult> CloseContractEmail() => await Task.Run(() => View());
        //public async Task<IActionResult> SuspendContractEmail() => await Task.Run(() => View());
        //public async Task<IActionResult> RenewContractEmail()
        //{
        //    var entity = await service.GetDataByIdAsync(122);

        //    var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);
        //    var oldContractClientAddress = await contractClientCollectionAddressService.GetFirstDataAsync(x => x.ContractId == entity.RenewFrom.Value);

        //    var model = new DTO.Contract.RenewContractEmailViewModel
        //    {
        //        NewContract = service.ToViewModel(entity),
        //        OldContract = await service.GetViewModelByIdAsync(entity.RenewFrom.Value),
        //        NextVisitDate = await contractServices.GetClientCollectionAddressNextDateToDemand(oldContractClientAddress.ClientCollectionAddressId)
        //    };

        //    return await Task.Run(() => View(model));
        //}

        //public async Task<IActionResult> ContractChangesEmail(int id) => await Task.Run(async () => View(await contractServices.GetContractChangesEmailViewModel(id, new List<int> { 43, 44 })));
        public async Task<IActionResult> Renew(int? id)
        {
            if (id.HasValue && await contractServices.Renewed(id.Value))
            {
                TempData["ErrorMessage"] = $"O certificado \"{(await service.GetDataByIdAsync(id.Value)).Code}\" já foi renovado.";
                return await Task.Run(() => RedirectToAction("Index", new { error = true }));
            }

            return await Task.Run(async () => View("Manage", new EntityViewMode<ContractManageParametersViewModel>(ViewMode.Editable, new ContractManageParametersViewModel(id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new ContractViewModel(), true))));
        }

        [AllowAnonymous]
        public async Task<IActionResult> AcceptTerm(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return await Task.Run(() => View((ContractViewModel)null));

            var entity = await contractServices.GetDataByAcceptTermToken(token);

            if (entity != null)
            {
                if (entity.TermAccepted) return await Task.Run(() => RedirectToAction("AcceptTerm", new { token = "", accepted = true, acceptedBy = entity.ContactName }));
                if (DateTime.Compare(entity.AcceptTermEmailSendedDate.Value.AddDays(7), DateTime.Now) < 0) return await Task.Run(() => View("AcceptTerm", null));
            }

            return await Task.Run(() => View(entity == null ? null : contractServices.ToViewModel(entity)));
        }
        #endregion

        #region [XHR]
        [RequireRouteValues(new string[] { "contractSituationId", "clientId" })]

        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int? contractSituationId, int? clientId, bool onlyProposal = false)
        {
            ListParameters.AddParameter("IsDeleted", false);
            if (contractSituationId.HasValue) ListParameters.AddParameter("ContractSituationId", contractSituationId);
            if (clientId.HasValue) ListParameters.AddParameter("ClientId", clientId);

            if (onlyProposal) {
                List<int> status = new List<int>();
                status.Add((await contractStatusServices.GetDataByExternalCode("CONTRATOCRIADO")).ContractStatusId);
                status.Add((await contractStatusServices.GetDataByExternalCode("CONTRATOENVIADO")).ContractStatusId);

                ListParameters.AddQuery("Status", $"ContractStatusId IN ({string.Join(", ", status)})", null);
            }
            else
            {
                List<int> status = new List<int>();
                status.Add((await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO")).ContractStatusId);

                ListParameters.AddQuery("Status", $"ContractStatusId IN ({string.Join(", ", status)})", null);
            }

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => contractListServices.ToViewModel(contractListServices.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters)));
        }

        public async Task<IActionResult> _ManageForm(ContractViewModel model, List<ContractResidueViewModel> contractResidues, List<int> clientCollectionAddressId, [FromServices] ClientContactServices clientContactServices)
        {
            if (!model.ContractId.HasValue)//Criação
            {
                model.Code = await contractServices.GetNewCode(model.ClientId.Value, model.StartContract.Value);
                model.ContractStatusId = (await contractStatusServices.GetDataByExternalCode("CONTRATOCRIADO")).ContractStatusId;

                if (model.ContractSituationId == (await contractSituationServices.GetDataByExternalCodeAsync("SEMCONTRATO"))?.ContractSituationId)
                {
                    model.ContractSituationId = (await contractSituationServices.GetDataByExternalCodeAsync("ADIMPLENTE"))?.ContractSituationId ?? model.ContractSituationId;
                }
            }

            if (model.ContractId.HasValue && await contractServices.Changed(model.ContractId.Value, model))//Caso haja alguma modificação nos dados a confirmação do contrato será resetada
            {
                await contractServices.ResetConfirm(model.ContractId.Value);
            }

            var r = (JsonResult)await base.ManageAjax(model);
            var value = (dynamic)r.Value;
            var id = (int)value.id;

            contractResidues = contractResidues.Where(x => x != null).ToList();
            await SaveContractResidues(contractResidues, id);
            await SaveContractAddress(clientCollectionAddressId, id);

            var entity = await service.GetDataByIdAsync(id);

            if (!entity.TermAccepted)//Enquanto os termos não foram aceitos é possivel alterar o contato principal
            {
                if (model.ContractId.HasValue) await contractServices.UpdateMainContact(model);

                await clientContactServices.RemoveMainContract(entity.ClientId);

                model.ClientId = entity.ClientId;
                if (!clientContactServices.Exist(model, out ClientContactViewModel contact))
                {
                    await clientContactServices.CreateAsync(contact);
                }
                else
                {
                    var clientContact = contact.CopyToEntity<ClientContact>();
                    await clientContactServices.UpdateAsync(clientContact);
                }
            }

            if (model.ContractSituationId == (await contractSituationServices.GetDataByExternalCodeAsync("SUSPENSO"))?.ContractSituationId) //envia o e-mail de suspensão
            {
                await SendSuspendContractEmail(entity.ContractId);
            }

            if (entity.CreationConfirmedBy.HasValue)
                return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
            else
                return await Task.Run(() => RedirectToAction("Print", new { id, success = true, creation = true }));
        }

        public async Task<IActionResult> CreationConfirm(int id, bool sendEmail = true)
        {
            var userId = (await GetUser()).Id;

            await contractServices.CreationConfirm(id, userId);

            if (sendEmail)
            {
                var contract = await service.GetDataByIdAsync(id);

#if DEBUG
                await SendContractEmail(id, "", "", "");
#else
                await SendContractEmail(id, contract.ContactEmail, "", "");
#endif

                return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
            }
            else
            {
                return await Task.Run(() => RedirectToAction("Index"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Renew(ContractViewModel model, List<ContractResidueViewModel> contractResidues, List<int> clientCollectionAddressId)
        {
            if (await contractServices.Renewed(model.ContractId.Value))
            {
                TempData["ErrorMessage"] = $"O certificado \"{(await service.GetDataByIdAsync(model.ContractId.Value)).Code}\" já foi renovado.";
                return await Task.Run(() => RedirectToAction("Index", new { error = true }));
            }

            var id = await contractServices.Renew(model);

            await SaveContractResidues(contractResidues, id);
            await SaveContractAddress(clientCollectionAddressId, id);

            await SendRenewContractEmail(id);

            return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
        }

        private async Task SaveContractResidues(List<ContractResidueViewModel> contractResidues, int contractId)
        {
            if (await contractResidueServices.AnyDifferenceBetweenContractResidues(contractId, contractResidues))//Caso haja alguma modificação nos residuos a confirmação do contrato será resetada
            {
                await contractServices.ResetConfirm(contractId);
            }

            var newContractResidues = await contractResidueServices.GetNewContracResidues(contractId, contractResidues);
            var newContractResidueFamilies = newContractResidues.Select(x => x.ResidueFamilyId).Distinct().ToList();
            //var newContractResidueIds = newContractResidues.Select(x => x.ResidueId).Distinct().ToList();

            await contractResidueServices.DeleteDefinitilyByContractId(contractId);

            if (contractResidues != null)
            {
                contractResidues.ForEach(x => x.ContractId = contractId);
                await contractResidueServices.CreateRangeAsync(contractResidues);
            }

            await routeClientServices.ContractNewFamilies(contractId, newContractResidueFamilies);
            await demandResidueFamilyServices.ContractNewFamilies(contractId, newContractResidueFamilies);


            //if (newContractResidueIds.Count > 0 && await contractServices.ContractIsSigned(contractId))
            //{
            //    var emailModel = await contractServices.GetContractChangesEmailViewModel(contractId, newContractResidueIds);
            //    var htmlEmail = await RenderPartialViewToString("ContractChangesEmail", emailModel, viewEngine);
            //    Services.Email.EmailServices.Send($"Alteração de Contrato \"{emailModel.Contract.Code}\"", htmlEmail, new List<string> { emailModel.Contract.ContactEmail });
            //}
        }

        private async Task SaveContractAddress(List<int> addressesId, int contractId)
        {
            await contractClientCollectionAddressService.DeleteDefinitivelyByContractId(contractId);
            await contractClientCollectionAddressService.CreateRangeAsync(addressesId.Select(x => new ContractClientCollectionAddress(contractId, x)));
        }

        public async Task<IActionResult> UploadContractFile(int contractId)
        {
            if (!Directory.Exists(ContractFilePath)) Directory.CreateDirectory(ContractFilePath);

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

            if (contractServices.TryGetContractFile(contractId, out Contract entity)) //Deleting old file
            {
                System.IO.File.Delete(Path.Combine(ContractFilePath, entity.FileGuidName));
            }

            try
            {
                var guidName = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(ContractFilePath, guidName);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                await contractServices.UpdateContractFile(contractId, guidName, archive.FileName, archive.ContentType);

                return await Task.Run(() => Json(new { hasError = false, fileName = archive.FileName, message = "Arquivo importado com sucesso!" }));
            }
            catch
            {
                return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao importar o arquivo." }));
            }
        }

        public async Task<IActionResult> GetContractFile(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(ContractFilePath, entity.FileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.FileName}\" não foi encontrado pra download.";
                return await Task.Run(() => RedirectToAction("Index", new { id = entity.ContractId, error = true }));
            }

            Response.ContentType = entity.FileMimeType;
            HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + path);
            await Response.Body.WriteAsync(System.IO.File.ReadAllBytes(path));
            await Response.Body.FlushAsync();
            Response.Body.Close();
            await Response.CompleteAsync();

            return await Task.Run(() => View());
        }

        public async Task<IActionResult> DownloadContractFile(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(ContractFilePath, entity.FileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.FileName}\" não foi encontrado pra download.";
                return await Task.Run(() => RedirectToAction("Manage", new { id = entity.ContractId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.FileMimeType, entity.FileName));
        }

        public async Task<IActionResult> RemoveContractFile(int contractId)
        {
            if (contractServices.TryGetContractFile(contractId, out Contract entity))
                System.IO.File.Delete(Path.Combine(ContractFilePath, entity.FileGuidName));

            await contractServices.UpdateContractFile(contractId, null, null, null);

            return await Task.Run(() => Json(new { success = true, message = "Arquivo removido com sucesso!" }));
        }

        public async Task<IActionResult> SendContractEmail(int contractId, string to, string replyTo, string bcc)
        {
            if (!configuration.GetValue<bool>("Emails:SendContractEmail"))
                return await Task.Run(() => Json(new { success = false, message = "O envio de e-mail está desabilitado." }));

            await contractServices.GetAndSetEmailTokenAsync(contractId);
            await contractServices.SetTermAcceptEmailSendedDate(contractId);
            var entity = await service.GetDataByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);

            #region [Get Email Body]
            var model = await contractServices.GetContractPrintViewModel(contractId);
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

            LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg) { ContentId = "Logo" };
            LinkedResource assin1 = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "Assinaturas", "Assin_Ruan.jpg"), MediaTypeNames.Image.Jpeg) { ContentId = "Assin_Ruan" };
            LinkedResource assin2 = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "Assinaturas", "Assin_Monique.jpg"), MediaTypeNames.Image.Jpeg) { ContentId = "Assin_Monique" };

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
                $"Destine Já - Termo de Aceite: Contrato \"{entity.Code}\" - {client.Name}",
                "<div style=\"margin-bottom: 3em;\">Esse documento é uma proposta e caso seja aceita, se transformará em um contrato.</div><br/>" + htmlEmail,
                _to,
                _replyTo,
                _bcc,
                new List<System.Net.Mail.Attachment> { new System.Net.Mail.Attachment(new MemoryStream(stream.ToArray()), $"Contrato \"{entity.Code}\".pdf", MediaTypeNames.Application.Octet) },
                new List<System.Net.Mail.LinkedResource> { pic, assin1, assin2 },
                false);

            if (r) await contractServices.SetTermAcceptEmailSended(contractId);

            return await Task.Run(() => Json(new { success = r, message = (r ? "E-mail enviado com sucesso!" : "Houve um erro inesperado ao enviar o e-mail, confira os dados informados e tente novamente.") }));
        }

        [AllowAnonymous]
        public async Task<IActionResult> AcceptTermValidate(int contractId, string fullName, string cpf) => await Task.Run(async () =>
        {
            var r = await contractServices.ValidateAcceptTerm(contractId, fullName, cpf);
            return Json(new { success = r, message = (r ? "" : "Você não tem permissão para aceitar este contrato, verifique os dados informados e tente novamente.") });
        });

        [ActionName("AcceptTerm")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> _AcceptTerm(int contractId, string fullName, string cpf)
        {
            var entity = await service.GetDataByIdAsync(contractId);
            if (!await contractServices.ValidateAcceptTerm(contractId, fullName, cpf))
            {
                return await Task.Run(() => RedirectToAction("AcceptTerm", new { token = entity.AcceptTermToken, unvalidated = true }));
            }

            await contractServices.AcceptTerm(contractId);

            await SendSignedContractEmail(contractId);

            return await Task.Run(() => RedirectToAction("AcceptTerm", new { token = "", accepted = true }));
        }

        public async Task<IActionResult> GetRemainingCollections(int contractId)
        {
            return await Task.Run(async () => Json(await contractServices.GetRemainingCollections(contractId)));
        }

        public async Task<IActionResult> CloseSave(int contractId, string closedReason)
        {
            await contractServices.Close(contractId, closedReason);

            await SendCloseContractEmail(contractId);

            return await Task.Run(() => RedirectToAction("Index", new { success = true }));
        }

        public async Task<IActionResult> CompliantSave(int contractId, bool goToList)
        {
            await contractServices.Compliant(contractId);

            if (goToList)
                return await Task.Run(() => RedirectToAction("Index", new { success = true }));

            return await Task.Run(() => RedirectToAction("Print", new { id = contractId, success = true }));
        }

        public async Task<IActionResult> DefaultingSave(int contractId, bool goToList)
        {
            await contractServices.Defaulting(contractId);

            await SendDefaultingContractEmail(contractId);

            if (goToList)
                return await Task.Run(() => RedirectToAction("Index", new { success = true }));

            return await Task.Run(() => RedirectToAction("Print", new { id = contractId, success = true }));
        }

        public async Task SignContract(int contractId)
        {
            var user = await userManager.GetUserAsync(User);

            await contractServices.SignContract(contractId, user.Id);
        }

        #region [Email]
        private async Task SendSignedContractEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendSignedContractEmail"))
                return;

            var model = await service.GetViewModelByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(model.ClientId.Value);

            #region [CLIENT EMAIL]
            var html_Client = await RenderPartialViewToString("SignedContractEmail", null, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, seja bem-vindo(a) à Destine Já.", html_Client, null);
#else
            emailServices.Send($"{client.Name}, seja bem-vindo à(a) Destine Já.", html_Client, new List<string> { model.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("SignedContract_AdminEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"Contrato Assinado - Contrato \"{model.Code}\" - {client.Name}.", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"Contrato Assinado - Contrato \"{model.Code}\" - {client.Name}.", html_Admin, new List<string> { "comercial@destineja.com.br",  "financeiro@destineja.com.br" });
#endif
            #endregion
        }

        private async Task SendCloseContractEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendClosedContractEmail"))
                return;

            var entity = await service.GetDataByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);

            #region [CLIENT EMAIL]
            var html_Client = await RenderPartialViewToString("CloseContractEmail", null, viewEngine);
#if DEBUG
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi encerrado", html_Client, null);
#else
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi encerrado", html_Client, new List<string> { entity.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("CloseContract_AdminEmail", service.ToViewModel(entity), viewEngine);

#if DEBUG
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi encerrado", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi encerrado", html_Admin, new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" });
#endif
            #endregion

        }

        private async Task SendSuspendContractEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendSuspendedContractEmail"))
                return;

            var entity = await service.GetDataByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);


            #region [CLIENT EMAIL]
            var html_Client = await RenderPartialViewToString("SuspendContractEmail", null, viewEngine);
#if DEBUG
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi suspenso", html_Client, null);
#else
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi suspenso", html_Client, new List<string> { entity.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("SuspendContract_AdminEmail", service.ToViewModel(entity), viewEngine);

#if DEBUG
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi suspenso", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"O Contrato \"{entity.Code}\" - {client.Name}, foi suspenso", html_Admin, new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" });
#endif
            #endregion
        }

        private async Task SendDefaultingContractEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendDefaultingContractEmail"))
                return;

            var entity = await service.GetDataByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);

            #region [CLIENT EMAIL]
            var html_Client = await RenderPartialViewToString("DefaultingContractEmail", null, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, Seu cadastro está inadimplente.", html_Client, null);
#else
            emailServices.Send($"{client.Name}, Seu cadastro está inadimplente.", html_Client, new List<string> { entity.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("DefaultingContract_AdminEmail", service.ToViewModel(entity), viewEngine);

#if DEBUG
            emailServices.Send($"{client.Name}, está inadimplente.", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"{client.Name}, está inadimplente.", html_Admin, new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" });
#endif
            #endregion


        }

        private async Task SendRenewContractEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendRenewContractEmail"))
                return;

            var entity = await service.GetDataByIdAsync(contractId);

            if (!entity.RenewFrom.HasValue) return;

            var client = await clientServices.GetViewModelByIdAsync(entity.ClientId);
            var oldContractClientAddress = await contractClientCollectionAddressService.GetFirstDataAsync(x => x.ContractId == contractId);

            var nextVisitDate = await contractServices.GetClientCollectionAddressNextDateToDemand(oldContractClientAddress.ClientCollectionAddressId);

            if (!nextVisitDate.HasValue)
                nextVisitDate = await contractServices.GetNextDemandVisitedDateByContractId(contractId);

            var model = new DTO.Contract.RenewContractEmailViewModel
            {
                NewContract = service.ToViewModel(entity),
                OldContract = await service.GetViewModelByIdAsync(entity.RenewFrom.Value),
                NextVisitDate = nextVisitDate
            };

            var html = await RenderPartialViewToString("RenewContractEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, seu contrato foi renovado automaticamente.", html, null);
#else
            emailServices.Send($"{client.Name}, seu contrato foi renovado automaticamente", html, new List<string> { entity.ContactEmail });
#endif
        }
        #endregion

        #endregion
    }
}
