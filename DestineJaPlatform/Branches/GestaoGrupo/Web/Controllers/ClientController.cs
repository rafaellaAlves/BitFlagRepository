using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using AspNetIdentityDbContext;
using DTO.Client;
using DTO.Client.Report;
using DTO.Shared;
using DTO.Utils;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Services.Account;
using Services.Client;
using Services.Contract;
using Services.Demand;
using Services.Email;
using Services.Service;
using Web.Utils;
using System.Diagnostics;
using System.Threading;

namespace Web.Controllers
{
    [Authorize]
    public class ClientController : Shared.BaseCRUDController<Client, ClientViewModel, int>
    {
        private readonly ClientCollectionAddressServices clientCollectionAddressServices;
        private readonly ClientContactListServices clientContactListServices;
        private readonly ClientContactServices clientContactServices;
        private readonly ContractServices contractServices;
        private readonly ServiceServices serviceServices;
        private readonly ClientUserServices clientUserServices;
        private readonly ClientServices clientServices;
        private readonly DemandClientServices demandClientServices;
        private readonly ClientCollectionRequestServices clientCollectionRequestServices;
        private readonly ClientReportServices clientReportServices;
        private readonly UserService userService;
        private readonly EmailServices emailServices;
        private readonly ICompositeViewEngine viewEngine;
        private readonly IConfiguration configuration;

        private readonly string clientCollectionRequestPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "ClientCollectionRequest");

        public ClientController(ClientServices clientServices, UserManager<User> userManager, ClientCollectionAddressServices clientCollectionAddressServices, ContractServices contractServices, ClientContactListServices clientContactListServices, ServiceServices serviceServices, ClientContactServices clientContactServices, ClientUserServices clientUserServices, DemandClientServices demandClientServices, ClientCollectionRequestServices clientCollectionRequestServices, UserService userService, ClientReportServices clientReportServices, ICompositeViewEngine viewEngine, EmailServices emailServices, IConfiguration configuration) : base(clientServices, userManager)
        {
            this.clientCollectionAddressServices = clientCollectionAddressServices;
            this.contractServices = contractServices;
            this.clientContactListServices = clientContactListServices;
            this.serviceServices = serviceServices;
            this.clientContactServices = clientContactServices;
            this.clientUserServices = clientUserServices;
            this.clientServices = clientServices;
            this.demandClientServices = demandClientServices;
            this.clientCollectionRequestServices = clientCollectionRequestServices;
            this.userService = userService;
            this.clientReportServices = clientReportServices;
            this.viewEngine = viewEngine;
            this.emailServices = emailServices;
            this.configuration = configuration;
        }

        #region [PAGES]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Manage(int? id) => await Task.Run(() => View(id));
        public async Task<IActionResult> ReportDownload() => await Task.Run(async () => View(await clientServices.GetViewModelByIdAsync(await clientServices.GetClientIdByLoggedUser(HttpContext))));
        public async Task<IActionResult> CollectionRequest() => await Task.Run(async () => View(await clientServices.GetViewModelByIdAsync(await clientServices.GetClientIdByLoggedUser(HttpContext))));
        public async Task<IActionResult> CollectionRequestSuccess() => await Task.Run(() => View());
        public async Task<IActionResult> CollectionRequest_AdministratorEmail(int collectionRequestId)
        {
            var collectionRequest = await clientCollectionRequestServices.GetViewModelByIdAsync(collectionRequestId);

            return await Task.Run(async () => View(new CollectionRequestEmailViewModel(await service.GetViewModelByIdAsync(collectionRequest.ClientId), await userService.GetUser(collectionRequest.CreatedBy), (AddressBaseViewModel)clientCollectionAddressServices.ToViewModel(await clientCollectionAddressServices.GetFirstDataAsync(x => x.Main && x.ClientId == collectionRequest.ClientId)), collectionRequest)));
        }
        public async Task<IActionResult> CollectionRequest_ClientEmail(int collectionRequestId)
        {
            var collectionRequest = await clientCollectionRequestServices.GetViewModelByIdAsync(collectionRequestId);

            return await Task.Run(async () => View(new CollectionRequestEmailViewModel(await service.GetViewModelByIdAsync(collectionRequest.ClientId), await userService.GetUser(collectionRequest.CreatedBy), (AddressBaseViewModel)clientCollectionAddressServices.ToViewModel(await clientCollectionAddressServices.GetFirstDataAsync(x => x.Main && x.ClientId == collectionRequest.ClientId)), collectionRequest)));
        }

        #region [Print]
        public async Task<IActionResult> ReportPGRSPrint(List<FilterViewModel> filters, string startDate, string endDate, int? unitOfMeasurementId, bool outOfList = false)
        {
            var model = new PrintListViewModel<ClientReportPGRSViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>()
            };

            if (outOfList)//quando esse pagina é chamada de fora da pagina de listagem
                model.Items = await clientReportServices.GetClientReportPGRSViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), null, null, null);
            else
                model.Items = await clientReportServices.GetClientReportPGRSViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable(), unitOfMeasurementId);

            return await Task.Run(() => View("~/Views/Client/Print/ReportPGRSPrint.cshtml", model));
        }
        #endregion

        #endregion

        #region [XHR]


        //Process p = Process.Start();
        //Console.WriteLine("Launched");
        //p.WaitForExit();
        //p.Close();
        //Console.WriteLine("Exited");
        //Console.ReadKey();
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task<IActionResult> ManageForm(ClientViewModel model)
        {
            
            var r = (JsonResult)(await base.ManageAjax(model));
            var value = (dynamic)r.Value;                       
            var id = (int)value.id;
            if (!model.ClientId.HasValue && !string.IsNullOrWhiteSpace(model.CEP))
            {
                              
                var clientCollectionAddress = model.CopyToEntity<ClientCollectionAddressViewModel>();               
                clientCollectionAddress.ClientId = id;
                clientCollectionAddress.Main = true;
                await clientCollectionAddressServices.CreateAsync(clientCollectionAddress);
               
            }
           

            return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
            
            
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> ValidateClient(ClientViewModel model)
        {
            var r = await clientServices.ExistClient(model);

            return await Task.Run(() => Json(new { hasError = r, message = r ? $"O CPF/CNPJ informado já está cadastrado." : "" }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return await base.List(filter);
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetDataByIdForContract(int id, DateTime? date)
        {
            if (await contractServices.ExistContractWithClient(id, date))
            {
                var contractThisYear = await contractServices.dbSet.FirstOrDefaultAsync(x => x.ClientId == id && !x.IsDeleted && x.StartContract.Year == (date.HasValue ? date.Value.Year : DateTime.Now.Year));

                if (contractThisYear != null)
                    return await Task.Run(() => Json(new { success = false, data = contractThisYear.ContractId, message = "Já existe um contrato para este cliente, deseja visualizar os dados do contrato?", url = $"{Url.Action("Manage", "Contract")}?id={contractThisYear.ContractId}" }));
            }

            var data = await clientServices.GetClientForNewContractViewModel(id);

            return await Task.Run(() => Json(new { success = true, data }));
        }

        public async Task<bool> ExistContractWithClient(int clientId, DateTime? date, int? contractId = null) => await contractServices.ExistContractWithClient(clientId, date, contractId);

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetDataByClientId(int id) => await Task.Run(async () => Json(new { success = true, data = await clientServices.GetClientForNewContractViewModel(id) }));

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> _Delete(int id)
        {
            if (await contractServices.UsingClient(id) || await serviceServices.UsingClient(id))
                return await Task.Run(() => Json(new { hasError = true, message = "Este gerador já possui contrato ou serviço realizado com a destine já. Não é possível exclui-lo. Deseja fazer alguma alteração no cadastro?" }));

            await base.Delete(id);

            return await Task.Run(() => Json(new { hasError = false }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> DisattachClientUser(int clientId, int userId)
        {
            var r = await clientUserServices.TryDelete(clientId, userId);

            return await Task.Run(() => Json(new { hasError = !r, message = r ? "Usuário desvinculado com sucesso!" : "Houve um erro ao desvincular o usuário" }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> AttachClientUser(int clientId, List<int> userIds)
        {
            await clientUserServices.Create(clientId, userIds);

            return await Task.Run(() => Json(new { hasError = false, message = "Usuário vinculado com sucesso!" }));
        }

        [ActionName("CollectionRequest")]
        [HttpPost]
        public async Task<IActionResult> _CollectionRequest(ClientCollectionRequestViewModel model, AddressBaseViewModel addressModel)
        {
            if (!Directory.Exists(clientCollectionRequestPath)) Directory.CreateDirectory(clientCollectionRequestPath);

            if (Request.Form.Files.Count > 0)
            {
                var r = SaveClientCollectionRequestFile(ref model);

                if (r.hasError == true) return await Task.Run(() => Json(new { success = false, message = r.message }));
            }
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
            var userId = (await userManager.GetUserAsync(User)).Id;

            model.ClientId = clientId;
            model.CreatedBy = userId;

            model.ClientCollectionRequestId = await clientCollectionRequestServices.CreateAsync(model);

            var clientViewModel = await service.GetViewModelByIdAsync(clientId);

            if (string.IsNullOrWhiteSpace(clientViewModel.CEP)) //caso o gerador não tenha endereço
            {
                clientViewModel.CEP = addressModel.CEP;
                clientViewModel.Address = addressModel.Address;
                clientViewModel.State = addressModel.State;
                clientViewModel.Number = addressModel.Number;
                clientViewModel.Neighborhood = addressModel.Neighborhood;
                clientViewModel.Complement = addressModel.Complement;
                clientViewModel.City = addressModel.City;

                await service.UpdateAsync(clientViewModel);
            }

            if (!await clientCollectionAddressServices.dbSet.AnyAsync(x => x.CEP == addressModel.CEP && x.ClientId == clientId)) // caso o endereço informado não esteja salvo na lista de endereços
            {
                await clientCollectionAddressServices.RemoveMainAddressFromClient(clientId);

                await clientCollectionAddressServices.CreateAsync(new ClientCollectionAddressViewModel
                {
                    CEP = addressModel.CEP,
                    Address = addressModel.Address,
                    State = addressModel.State,
                    Number = addressModel.Number,
                    Neighborhood = addressModel.Neighborhood,
                    Complement = addressModel.Complement,
                    City = addressModel.City,
                    ClientId = clientId,
                    Main = true
                });
            }

            if (configuration.GetValue<bool>("Emails:SendCollectionRequestEmail"))
            {
                var emailModel = new CollectionRequestEmailViewModel(clientViewModel, await userService.GetUser(userId), addressModel, model);
                var html_ClientEmail = await RenderPartialViewToString("CollectionRequest_ClientEmail", emailModel, viewEngine);
                var html_AdministratorEmail = await RenderPartialViewToString("CollectionRequest_AdministratorEmail", emailModel, viewEngine);

                LinkedResource pic = new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg) { ContentId = "Logo" };
                var attachments = new List<System.Net.Mail.Attachment>();
                if (!string.IsNullOrWhiteSpace(model.GuidName))
                {
                    var path = Path.Combine(clientCollectionRequestPath, model.GuidName);

                    attachments.Add(new Attachment(new MemoryStream(System.IO.File.ReadAllBytes(path)), $"Residuo{System.IO.Path.GetExtension(model.GuidName)}", model.MimeType));
                }

#if DEBUG
                emailServices.Send($"Destine Já - {emailModel.User.FirstName} {emailModel.User.LastName}, sua coleta #{emailModel.CollectionRequest.ClientCollectionRequestId} foi solicitada com sucesso.", html_ClientEmail, new List<string>() { "sarah.reggiani@bitflag.systems" }, null, null, null, new List<LinkedResource> { pic }, false); //envio para cliente
                                                                                                                                                                                                                                                                                                                                                    //emailModel.User.Email
                emailServices.Send($"Destine Já - Coleta de Resíduos - Nova Solicitação {emailModel.Client.Name}.", html_AdministratorEmail, new List<string>() { "sarah.reggiani@bitflag.systems" }, null, null, attachments, new List<LinkedResource> { pic }, false); //envio para administrador
#else
            emailServices.Send($"Destine Já - {emailModel.User.FirstName} {emailModel.User.LastName}, sua coleta #{emailModel.CollectionRequest.ClientCollectionRequestId} foi solicitada com sucesso.", html_ClientEmail, new List<string>() { "desenvolvimento@destineja.com.br" }, null, null, null, new List<LinkedResource> { pic }, false); //envio para cliente
            emailServices.Send($"Destine Já - Coleta de Resíduos - Nova Solicitação {emailModel.Client.Name}.", html_AdministratorEmail, new List<string>() { "desenvolvimento@destineja.com.br" }, null, null, attachments, new List<LinkedResource> { pic }, false); //envio para administrador
#endif
            }
            return await Task.Run(() => Json(new { success = true }));
        }

        private dynamic SaveClientCollectionRequestFile(ref ClientCollectionRequestViewModel model)
        {
            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return new { hasError = true, message = "Houve um erro ao importar o arquivo." };

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB)." };
                }
                if (archive.FileName != "")
                {
                    return new { hasError = true, message = "Arquivo inválido." };
                }
            }
            #endregion

            try
            {
                model.GuidName = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(clientCollectionRequestPath, model.GuidName);


                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                model.FileName = archive.FileName;
                model.MimeType = archive.ContentType;

                return new { hasError = false };
            }
            catch { return new { hasError = true, message = "Houve um erro ao importar o arquivo." }; }
        }

        #region [Print Download]
        public async Task<IActionResult> ReportPGRSDownload(List<FilterViewModel> filters, string startDate, string endDate, int? unitOfMeasurementId, bool outOfList = false)
        {
            var model = new PrintListViewModel<ClientReportPGRSViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>()
            };

            if (outOfList)//quando esse pagina é chamada de fora da pagina de listagem
                model.Items = await clientReportServices.GetClientReportPGRSViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), null, null, null);
            else
                model.Items = await clientReportServices.GetClientReportPGRSViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable(), unitOfMeasurementId);

            var stream = new MemoryStream();
            ViewData["PDF"] = true;
            var htmlPdf = await RenderPartialViewToString("Print/ReportPGRSPrint", model, viewEngine);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());


            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "Plano de Gerenciamento de Resíduos Sólidos (PGRS).pdf"));
        }
        #endregion

        #endregion

        #region [Load Components]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadClientUserViewComponent(int clientId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Client.ClientUserIndexViewComponent), new { clientId, loadFromController = true }));
        public async Task<IActionResult> LoadGeneratorViewComponent(DateTime? startDate, DateTime? endDate) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.Generator.IndexViewComponent), new { startDate, endDate, loadFromController = true }));
        public async Task<IActionResult> LoadReportPGRSViewComponent(DateTime? startDate, DateTime? endDate, int? UnitOfMeasurementId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.PGRS.IndexViewComponent), new { startDate, endDate, UnitOfMeasurementId, loadFromController = true }));
        public async Task<IActionResult> LoadClientResidueDownloadDestinationViewComponent(int demandId)
        {
            if (User.IsClient())
            {
                var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
                if (!await demandClientServices.ExistClientFromDemand(demandId, clientId))
                {
                    return await Task.Run(() => Forbid());
                }
            }

            return await Task.Run(() => ViewComponent(typeof(ViewComponents.Client.Report.DownloadDestinationViewComponent), new { demandId, loadFromController = true }));
        }
        public async Task<IActionResult> LoadClientResidueDownloadTransporterViewComponent(int demandId)
        {

            if (User.IsClient())
            {
                var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);

                if (!await demandClientServices.ExistClientFromDemand(demandId, clientId))
                {
                    return await Task.Run(() => Forbid());
                }
            }

            return await Task.Run(() => ViewComponent(typeof(ViewComponents.Client.Report.DownloadTransporterViewComponent), new { demandId, loadFromController = true }));
        }
        #endregion
    }
}