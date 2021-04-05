using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Demand;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Demand;
using DTO.Shared;
using Services.Route;
using DTO.Utils;
using Services.DemandDestination;
using Services.Contract;
using Services.Residue;
using Services.Service;
using System.IO;
using DTO.Residue;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Services.Client;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using Microsoft.AspNetCore.Authorization;
using Services.Email;
using System.Net.Mime;
using Services.Transporter;
using DTO.Client;
using System.Net.Mail;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class DemandController : Shared.BaseCRUDController<Demand, DemandViewModel, int>
    {
        private readonly BaseDemandClientListServices baseDemandClientListServices;
        private readonly DemandClientServices demandClientServices;
        private readonly DemandResidueFamilyServices demandResidueFamilyServices;
        private readonly DemandClientResidueServices demandClientResidueServices;
        private readonly DemandClientResidueListServices demandClientResidueListServices;
        private readonly DemandServices demandServices;
        private readonly DemandStatusServices demandStatusServices;
        private readonly DemandListServices demandListServices;
        private readonly DemandDestinationDemandServices demandDestinationDemandServices;
        private readonly DemandNotUsedClientServices demandNotUsedClientServices;
        private readonly ClientServices clientServices;
        private readonly ContractServices contractServices;
        private readonly TransporterDriverServices transporterDriverServices;
        private readonly TransporterVehicleServices transporterVehicleServices;
        private readonly ClientCollectionAddressServices clientCollectionAddressServices;
        private readonly ContractResidueServices contractResidueServices;
        private readonly EmailServices emailServices;
        private readonly IConfiguration configuration;

        private readonly ICompositeViewEngine viewEngine;
        private readonly string MTRFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "Demand", "MTR");

        public DemandController(DemandServices service, UserManager<User> userManager, BaseDemandClientListServices baseDemandClientListServices, DemandClientServices demandClientServices, DemandResidueFamilyServices demandResidueFamilyServices, DemandClientResidueServices demandClientResidueServices, DemandClientResidueListServices demandClientResidueListServices, DemandStatusServices demandStatusServices, DemandListServices demandListServices, DemandDestinationDemandServices demandDestinationDemandServices, DemandNotUsedClientServices demandNotUsedClientServices, ClientServices clientServices, ContractServices contractServices, ICompositeViewEngine viewEngine, TransporterDriverServices transporterDriverServices, TransporterVehicleServices transporterVehicleServices, ClientCollectionAddressServices clientCollectionAddressServices, ContractResidueServices contractResidueServices, EmailServices emailServices, IConfiguration configuration) : base(service, userManager)
        {
            demandServices = service;
            this.baseDemandClientListServices = baseDemandClientListServices;
            this.demandClientServices = demandClientServices;
            this.demandResidueFamilyServices = demandResidueFamilyServices;
            this.demandClientResidueServices = demandClientResidueServices;
            this.demandClientResidueListServices = demandClientResidueListServices;
            this.demandStatusServices = demandStatusServices;
            this.demandListServices = demandListServices;
            this.demandDestinationDemandServices = demandDestinationDemandServices;
            this.demandNotUsedClientServices = demandNotUsedClientServices;
            this.clientServices = clientServices;
            this.contractServices = contractServices;
            this.transporterDriverServices = transporterDriverServices;
            this.transporterVehicleServices = transporterVehicleServices;
            this.clientCollectionAddressServices = clientCollectionAddressServices;
            this.viewEngine = viewEngine;
            this.contractResidueServices = contractResidueServices;
            this.emailServices = emailServices;
            this.configuration = configuration;
        }

        #region [PAGES]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Index() => await Task.Run(() => View());
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Manage(int? id)
        {
            var demand = id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new DemandViewModel();

            if (demand.IsDeleted)
            {
                TempData["ErrorMessage"] = "Este MTR de Coleta foi excluído.";
                return await Task.Run(() => RedirectToAction("Index", new { error = true }));
            }

            return await Task.Run(() => View(demand));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Close(int id) => await Task.Run(async () => View(await service.GetViewModelByIdAsync(id)));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> MTRFile(int id) => await Task.Run(() => View(id));
        public async Task<IActionResult> Certificate(int id) => await Task.Run(async () => View(await demandServices.GetDemandClientCertificateViewModel(id)));

        //public async Task<IActionResult> ContractWeightAlmostEndEmail(int id) => await Task.Run(async () => View(await service.GetViewModelByIdAsync(id)));
        //public async Task<IActionResult> ContractWeightEndEmail(int id) => await Task.Run(async () => View(await service.GetViewModelByIdAsync(id)));
        //public async Task<IActionResult> NewDemandEmail(int demandId)
        //{
        //    var demand = await service.GetViewModelByIdAsync(demandId);
        //    var driver = await transporterDriverServices.GetViewModelByIdAsync(demand.TransporterDriverId);

        //    var item = await demandClientServices.GetFirstDataAsync(x => x.DemandId == demandId);

        //    var clientCollectionAddress = await clientCollectionAddressServices.GetDataByIdAsync(item.ClientCollectionAddressId);
        //    var client = await clientServices.GetViewModelByIdAsync(clientCollectionAddress.ClientId);

        //    var model = new NewDemandEmailViewModel
        //    {
        //        Demand = demand,
        //        Driver = driver,
        //        Client = client
        //    };

        //    return await Task.Run(() => View(model));
        //}

        //public async Task<IActionResult> CloseDemandEmail(int demandId)
        //{
        //    var demand = await service.GetViewModelByIdAsync(demandId);
        //    var driver = await transporterDriverServices.GetViewModelByIdAsync(demand.TransporterDriverId);

        //    var item = await demandClientServices.GetFirstDataAsync(x => x.DemandId == demandId);

        //    var clientCollectionAddress = await clientCollectionAddressServices.GetDataByIdAsync(item.ClientCollectionAddressId);
        //    var client = await clientServices.GetViewModelByIdAsync(clientCollectionAddress.ClientId);

        //    var model = new CloseDemandEmailViewModel
        //    {
        //        Demand = demand,
        //        Driver = driver,
        //        Client = client,
        //        DemandClient = demandClientServices.ToViewModel(item)
        //    };

        //    return await Task.Run(() => View(model));
        //}

        #endregion

        #region [COMPONENTS]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadDemandClientViewComponent(int routeId, int? demandId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Demand.DemandClientViewComponent), new { routeId, demandId, loadFromController = true }));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadDemandClientManageViewComponent(int demandClientId, ViewMode viewMode) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Demand.DemandClientManageViewComponent), new { demandClientId, viewMode, loadFromController = true }));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadDemandClientResidueSelectionViewComponent(DemandClientResidueListViewModel model) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Demand.DemandClientResidueSelectionViewComponent), new { model, loadFromController = true }));//int demandClientId, int? demandClientResidueId

        public async Task<IActionResult> LoadDemandClientQuickListViewComponent(int demandId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Demand.DemandClientQuickListViewComponent), new { demandId }));

        #endregion

        #region [XHR]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return await base.AlternativeList(filter, (filter, num1, num2, query, param) => demandListServices.ToViewModel(demandListServices.GetDataFiltered(filter, out num1, out num2, query, param)));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetClients(int routeId, string search, bool notValidateFamily, [FromServices] RouteServices routeServices, [FromServices] RouteTypeServices routeTypeServices)
        {
            var route = await routeServices.GetDataByIdAsync(routeId);
            var RouteUsedForContract = route.RouteTypeId == (await routeTypeServices.GetDataByExternalCode("CONTRATO"))?.RouteTypeId;
            var RouteUsedForService = route.RouteTypeId == (await routeTypeServices.GetDataByExternalCode("SERVICO"))?.RouteTypeId;

            var ret = await baseDemandClientListServices.GetDataAsNoTrackingAsync(x => (x.CompanyName.Contains(search) || x.TradeName.Contains(search) || x.ClientId.ToString().Contains(search)) && (!RouteUsedForContract || (RouteUsedForContract && x.ContractId.HasValue)) && (!RouteUsedForService || (RouteUsedForService && x.ServiceId.HasValue)));

            var availbleFamilyIds = (await routeServices.GetResidueFamiliesByRouteId(routeId)).Select(x => x.ResidueFamilyId);

            ret.Select(async x => await contractResidueServices.GetDataAsNoTrackingAsync());
            return await Task.Run(() => Json(ret.Select(async item =>
            {
                IEnumerable<ResidueFamilyList> families = new List<ResidueFamilyList>();
                if (RouteUsedForContract) // se for contrato verifica a quantidade de familias disponiveis para cada cliente (Obs. na linha que contêm o retorno)
                {
                    families = await demandServices.GetAvailbleResidueFamilies(routeId, item.ContractId, item.ServiceId, notValidateFamily);
                    item.ServiceId = null;//caso haja serviceId ele será removido pois se a rota é de contrato não será necessário ele
                }
                if (RouteUsedForService)
                {
                    families = await demandServices.GetAvailbleResidueFamilies(routeId, item.ContractId, item.ServiceId);
                    item.ContractId = null;//caso haja contractId ele será removido pois se a rota é de serviço não será necessário ele
                }

                return new
                {
                    addressId = item.ClientCollectionAddressId,
                    item,
                    families = families.Select(x => new { name = x.Name, id = x.ResidueFamilyId }) //As familias estão sendo pegas nesta etapa pra não precisar abrir a modal de familias e visualizar que não existe familias disponiveis. Obs.: se os blocos de if e else if forem retirados o sistema ainda sim funciona.
                };
            }).Select(x => x.Result)));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetClientAddresses(List<int> clientCollectionAddressIds) => await Task.Run(async () => Json(await baseDemandClientListServices.GetViewModelAsNoTrackingAsync(x => clientCollectionAddressIds.Contains(x.ClientCollectionAddressId))));

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> ValidateDemandCreation(DemandViewModel model)
        {
            var r = await demandServices.ExistAlternativeDemandId(model.DemandId, model.AlternativeDemandId);

            return await Task.Run(() => Json(new { hasError = r, message = r ? "Este número de MTR já foi cadastrado no sistema" : "" }));
        }


        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> _ManageForm(DemandViewModel model, List<DemandNotUsedClientViewModel> notUsedClients, List<DemandClientViewModel> clients, List<DemandResidueFamily> demandResidueFamily)
        {
            var alreadyClosed = model.DemandId.HasValue && (await service.GetDataByIdAsync(model.DemandId.Value)).Closed;
            bool newDemand = !model.DemandId.HasValue;

            if (newDemand)
                model.DemandStatusId = (await demandStatusServices.GetInitialStatus()).DemandStatusId;

            var r = (JsonResult)(await base.ManageAjax(model));
            var value = (dynamic)r.Value;
            var id = (int)value.id;

            if (!alreadyClosed)
            {
                await demandServices.UpdateServiceStatusToOSAssinada(id); //volta os status dos serviços anteriormente vinculados para 'o.s. assinada'(caso algum dos serviços tenha sido removido do contrato isso garante que os status deles não estejam mais como 'coleta agendado')

                await UpdateDemandResidueFamily(id, demandResidueFamily);
                await UpdateDemandNotUsedClient(id, notUsedClients);
                await UpdateDemandClient(id, clients);

                await demandServices.UpdateServiceStatusToDemandSchedule(id); //atualiza os status dos serviços vinculados para coleta agendada
            }

            if (newDemand)
                await SendNewDemandEmail(id);

            return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        private async Task UpdateDemandResidueFamily(int demandId, List<DemandResidueFamily> demandResidueFamily)
        {
            demandResidueFamily.ForEach(x => x.DemandId = demandId);

            await demandResidueFamilyServices.DeleteByDemandIdAsync(demandId);
            await demandResidueFamilyServices.CreateRange(demandResidueFamily);
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        private async Task UpdateDemandClient(int demandId, List<DemandClientViewModel> clients)
        {
            await demandClientServices.DeleteByDemandIdAsync(demandId, clients.Where(x => x.DemandClientId.HasValue).Select(x => x.DemandClientId.Value));
            clients.ForEach(x => x.DemandId = demandId);
            await demandClientServices.CreateRange(clients.Where(x => !x.DemandClientId.HasValue));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        private async Task UpdateDemandNotUsedClient(int demandId, List<DemandNotUsedClientViewModel> notUsedClients)
        {
            await demandNotUsedClientServices.DeleteByDemandIdAsync(demandId);
            notUsedClients.ForEach(x => x.DemandId = demandId);
            await demandNotUsedClientServices.CreateRange(notUsedClients);
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> ValidateDemandClientManage(int demandClientId, List<int?> demandResidues) => await Task.Run(async () => Json(await demandClientResidueServices.Validate(demandClientId, demandResidues)));

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> DemandClientManage(DemandClientViewModel model, [FromForm] List<DemandClientResidueViewModel> demandClientResidue, [FromServices] ContractClientCollectionAddressService contractClientCollectionAddressService, [FromServices] ContractServices contractServices)
        {
            await demandClientServices.UpdateDemandClient(model);
            var entity = await demandClientServices.GetDataByIdAsync(model.DemandClientId.Value);

            if (entity.ContractId.HasValue)//Contract
            {
                var contract = await contractServices.GetDataByIdAsync(entity.ContractId.Value);
                var contractClientAddress = await contractClientCollectionAddressService.GetFirstDataAsync(x => x.ContractId == contract.ContractId);
                var oldTotalCollected = await demandServices.GetWeightCollectedFromClient(contract.ContractId, contractClientAddress.ClientCollectionAddressId) ?? 0;

                await demandClientResidueServices.DeleteByDemandClientIdAsync(model.DemandClientId.Value);
                demandClientResidue.ForEach(x => x.DemandClientId = model.DemandClientId.Value);
                await demandClientResidueServices.CreateRange(demandClientResidue);

                await CreateThatAreResidueOutOfContract(model.DemandClientId.Value, demandClientResidue.Select(x => x.ResidueId).ToList());

                var currentTotalCollected = await demandServices.GetWeightCollectedFromClient(contract.ContractId, contractClientAddress.ClientCollectionAddressId) ?? 0;

                if (oldTotalCollected * 100 / contract.ContractedWeight < 100 && currentTotalCollected * 100 / contract.ContractedWeight >= 100) //excedeu o peso contratado
                {
                    await SendContractWeightEndEmail(contract.ContractId);
                }
                else if (oldTotalCollected * 100 / contract.ContractedWeight < 75 && currentTotalCollected * 100 / contract.ContractedWeight >= 75) //chegou a 75% do contratado
                {
                    await SendContractWeightAlmostEndEmail(contract.ContractId);
                }
            }
            else//Service
            {
                await demandClientResidueServices.DeleteByDemandClientIdAsync(model.DemandClientId.Value);
                demandClientResidue.ForEach(x => x.DemandClientId = model.DemandClientId.Value);
                await demandClientResidueServices.CreateRange(demandClientResidue);
            }


            var demandClient = await demandClientServices.GetDataByIdAsync(model.DemandClientId.Value);
            return await Task.Run(() => RedirectToAction("Close", new { id = demandClient.DemandId, success = true }));
        }

        private async Task CreateThatAreResidueOutOfContract(int demandClientId, List<int?> demandResidues)
        {
            var newContractResidues = await demandClientResidueServices.GetResiduesOutOfContract(demandClientId, demandResidues);

            await contractResidueServices.CreateRangeAsync(newContractResidues);
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> CanClose(int id)
        {
            var r = await demandServices.CanClose(id);

            return await Task.Run(() => Json(new { canClose = r, message = r ? "" : $"Não é possível fechar esta demanada, pois nem todos gerados foram informados se houve visita." }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> CloseSave(DemandViewModel model)
        {
            await demandServices.CloseUpdate(model);

            return await Task.Run(() => RedirectToAction("Close", new { id = model.DemandId.Value, success = true }));
        }

        [ActionName("Close")]
        [HttpPost]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> _Close(DemandViewModel model, bool sendEmail = false)
        {
            await demandServices.CloseUpdate(model);

            await demandServices.Close(model.DemandId.Value, (await GetUser()).Id);

            await demandServices.UpdateServiceStatusToDemandClosed(model.DemandId.Value);

            if (sendEmail)
                await SendCloseDemandEmail(model.DemandId.Value);

            await SendDemandFeedbackEmail(model.DemandId.Value);

            TempData["SuccessMessage"] = $"A Demanda '#{model.DestinaJaDemandId}' foi fechada com sucesso!";
            return await Task.Run(() => RedirectToAction("Close", new { id = model.DemandId.Value, success = true }));
        }

        async Task SendDemandFeedbackEmail(int demandId)
        {
            var clients = await demandClientServices.GetClientsByDemandId(demandId);

            foreach (var client in clients)
            {
                if (client.DemandFeedbackEmailSendedDate.HasValue && client.DemandFeedbackEmailSendedDate.Value.Year == DateTime.Now.Year && client.DemandFeedbackEmailSendedDate.Value.Month == DateTime.Now.Month) continue;

                emailServices.Send($"Avalie sua coleta com a DESTINE JÁ. É rapidinho!", await RenderPartialViewToString("DemandFeedbackEmail", client, viewEngine), client.CentralEmail.Split(";").ToList(), null, null, null,
                    new List<LinkedResource> { new LinkedResource(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens", "logo2.png"), MediaTypeNames.Image.Jpeg) { ContentId = "Logo" } }, false);

                await clientServices.UpdateDemandFeedbackEmailSendedDate(client.ClientId.Value);
            }
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Cancel(int demandId, string reason)
        {
            await demandServices.Cancel(demandId, reason);

            var demand = await service.GetViewModelByIdAsync(demandId);

            return await Task.Run(() => Json(new { hasError = false, message = $"A Demanda '{demand.DestinaJaDemandId}' foi cancelada com sucesso." }));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Unlock(int demandId, string reason)
        {
            var user = await GetUser();

            await demandServices.Unlock(demandId, user.Id, reason);

            var demand = await service.GetViewModelByIdAsync(demandId);

            return await Task.Run(() => Json(new { hasError = false, message = $"A Demanda '{demand.DestinaJaDemandId}' foi aberta com sucesso." }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task<IActionResult> GetViewModelById(int id)
        {
            return Json(await demandListServices.GetViewModelByIdAsync(id));
        }

        //public async Task<IActionResult> GetDemands()
        //{
        //    var usedDemandIds = await demandDestinationDemandServices.GetUsedDemands();

        //    return await Task.Run(async () => Json(await demandServices.GetDataAsNoTrackingAsync(x => !x.IsDeleted && !usedDemandIds.Contains(x.DemandId!))));
        //}

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetViewModelByIdForDemandDestination(int demandId, int residueFamilyId, [FromServices] RouteServices routeServices, [FromServices] DemandResidueFamilyTotalWeightServices demandResidueFamilyTotalWeightServices)
        {
            var viewModel = await demandListServices.GetViewModelByIdAsync(demandId);

            foreach (var demandClient in await demandClientServices.GetDataAsNoTrackingAsync(x => x.DemandId == demandId))
            {
                var families = (await demandResidueFamilyServices.GetDataAsNoTrackingAsync(x => x.ClientCollectionAddressId == demandClient.ClientCollectionAddressId && x.DemandId == demandId)).Select(x => x.ResidueFamilyId);

                //if ((await demandServices.GetAvailbleResidueFamilies(viewModel.RouteId, demandClient.ContractId, demandClient.ServiceId)).Select(x => x.ResidueFamilyId).Contains(residueFamilyId))
                if (families.Contains(residueFamilyId))
                {
                    return await Task.Run(async () => Json(new { hasError = false, data = viewModel, demandResidueFamilyTotalWeight = ((await demandResidueFamilyTotalWeightServices.GetFirstDataAsync(x => x.DemandId == demandId && x.ResidueFamilyId == residueFamilyId))?.TotalWeight ?? 0).ToWeightPtBr() }));
                }

            }

            return await Task.Run(() => Json(new { hasError = true, message = "O MTR de coleta escolhido não possuí a mesma familía selecionada." }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadDemandInfoViewComponent(int demandId, int? residueFamilyId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Demand.DemandInfoViewComponent), new { demandId, residueFamilyId, loadFromController = true }));

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadFileViewComponent(string viewComponentId, int id, string guidName, string fileName, string getUrl, string setUrl, string downloadUrl, string removeUrl, bool isModal = false) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Shared.FileViewComponent), new { viewComponentId, id, guidName, fileName, getUrl, setUrl, downloadUrl, removeUrl, isModal, loadFromController = true }));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadDemandClientSOSelectionViewComponent(int addressId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Demand.DemandClientSOSelectionViewComponent), new { addressId, loadFromController = true }));

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetClientsByDemandId(int demandId) => await Task.Run(async () => Json(await demandClientServices.GetClientsByDemandId(demandId)));

        public async Task<IActionResult> DemandClientInsertionValidateFamilies(List<int> residueFamilyIds, [FromServices] ResidueFamilyServices residueFamilyServices) => await Task.Run(async () => Json(await residueFamilyServices.ValidateResidueFamiliesForDemand(residueFamilyIds)));

        #region [MTR File]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> UploadMTRFile(int id)
        {
            if (!Directory.Exists(MTRFilePath)) Directory.CreateDirectory(MTRFilePath);

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

            if (demandClientServices.TryGetMTRFile(id, out DemandClient entity)) //Deleting old file
            {
                System.IO.File.Delete(Path.Combine(MTRFilePath, entity.MTRFileGuidName));
            }

            try
            {
                var guidName = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(MTRFilePath, guidName);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                await demandClientServices.UpdateMTRFile(id, guidName, archive.FileName, archive.ContentType);

                return await Task.Run(() => Json(new { hasError = false, fileName = archive.FileName, message = "Arquivo importado com sucesso!" }));
            }
            catch
            {
                return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao importar o arquivo." }));
            }
        }
        public async Task<IActionResult> GetMTRFile(int id)
        {
            var entity = await demandClientServices.GetDataByIdAsync(id);

            var path = Path.Combine(MTRFilePath, entity.MTRFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.MTRFileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));

                return await Task.Run(() => RedirectToAction("Close", new { id = entity.DemandId, error = true }));
            }

            Response.ContentType = entity.MTRFileMimeType;
            HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + path);
            await Response.Body.WriteAsync(System.IO.File.ReadAllBytes(path));
            await Response.Body.FlushAsync();
            Response.Body.Close();
            await Response.CompleteAsync();

            return await Task.Run(() => View());
        }
        public async Task<IActionResult> DownloadMTRFile(int id)
        {
            var entity = await demandClientServices.GetDataByIdAsync(id);

            if (User.IsClient())
            {
                var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
                if (!await demandClientServices.ExistClientFromDemand(entity.DemandId, clientId))
                {
                    return await Task.Run(() => Forbid());
                }
            }

            var path = Path.Combine(MTRFilePath, entity.MTRFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.MTRFileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                {
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));
                }
                return await Task.Run(() => RedirectToAction("Close", new { id = entity.DemandId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.MTRFileMimeType, entity.MTRFileName));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> RemoveMTRFile(int id)
        {
            if (demandClientServices.TryGetMTRFile(id, out DemandClient entity))
                System.IO.File.Delete(Path.Combine(MTRFilePath, entity.MTRFileGuidName));

            await demandClientServices.UpdateMTRFile(id, null, null, null);

            return await Task.Run(() => Json(new { success = true, message = "Arquivo removido com sucesso!" }));
        }
        #endregion

        #region [Certificate]

        public async Task<IActionResult> DownloadCertificateFile(int id)
        {
            if (User.IsClient())
            {
                var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
                var entity = await demandClientServices.GetDataByIdAsync(id);
                if (!await demandClientServices.ExistClientFromDemand(entity.DemandId, clientId))
                {
                    return await Task.Run(() => Forbid());
                }
            }
            var model = await demandServices.GetDemandClientCertificateViewModel(id);
            model.PDF = true;

            var stream = new MemoryStream();
            var htmlPdf = await RenderPartialViewToString("Certificate", model, viewEngine);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            return await Task.Run(() => File(stream.ToArray(), "application/pdf", $"Certificado-{model.Demand.DemandId}.pdf"));

        }

        public async Task<IActionResult> GetCertificateFile(int id)
        {
            if (User.IsClient())
            {
                var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
                var entity = await demandClientServices.GetDataByIdAsync(id);
                if (!await demandClientServices.ExistClientFromDemand(entity.DemandId, clientId))
                {
                    return await Task.Run(() => Forbid());
                }
            }
            var model = await demandServices.GetDemandClientCertificateViewModel(id);
            model.PDF = true;

            var stream = new MemoryStream();
            var htmlPdf = await RenderPartialViewToString("Certificate", model, viewEngine);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            //return await Task.Run(() => File(stream.ToArray(), "application/pdf", $"Certificado-{model.Demand.DemandId}.pdf"));

            Response.ContentType = "application/pdf";
            HttpContext.Response.Headers.Add("Content-Disposition", $"inline; filename=Certificado-{model.Demand.DemandId}.pdf");
            await Response.Body.WriteAsync(stream.ToArray());
            await Response.Body.FlushAsync();
            Response.Body.Close();
            await Response.CompleteAsync();

            return await Task.Run(() => View());

        }

        public async Task<IActionResult> SendCertficateEmail(int id, string emails)
        {
            if (!configuration.GetValue<bool>("Emails:SendCertficateEmail"))
                return await Task.Run(() => Json(new { message = "O envio de e-mail está desabilitado." }));

            var entity = await demandClientServices.GetViewModelByIdAsync(id);
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);

            if (User.IsClient())
            {
                if (!await demandClientServices.ExistClientFromDemand(entity.DemandId, clientId))
                {
                    return await Task.Run(() => Forbid());
                }
            }

            var to = new List<string>();
            if (to != null) to = emails.Split(";").Select(x => x.Trim()).Distinct().ToList();
            while (to.Contains("")) to.Remove(""); //caso o usuário insira ";" desnecessário

            var model = await demandServices.GetDemandClientCertificateViewModel(id);
            model.PDF = true;

            var stream = new MemoryStream();
            var htmlPdf = await RenderPartialViewToString("Certificate", model, viewEngine);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            var client = await clientServices.GetViewModelByIdAsync(clientId);

            var r = emailServices.Send(
                $"Destine Já - CERTIFICADO DE COLETA #{entity.DestineJaCertificateId}",
                $"<label>Olá,</label><br/><label>Segue anexo o certificado de coleta número <b> {entity.DestineJaCertificateId}</b>, da empresa <b>{client.Name}</b>.</label><br/><br/><label>Atenciosamente,</label><br/><label>Equipe Destine Já.</label>",
                to, null, null, new List<System.Net.Mail.Attachment> { new System.Net.Mail.Attachment(new MemoryStream(stream.ToArray()), $"Certificado de Coleta \"{entity.DestineJaCertificateId}\".pdf", MediaTypeNames.Application.Octet) });

            return await Task.Run(() => Json(new { message = r ? "E-mail enviado com sucesso!" : "Houve um erro ao enviar o e-mail, tente novamente." }));

        }

        #endregion

        #region [Email]
        private async Task SendContractWeightAlmostEndEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendContractWeightAlmostEndEmail"))
                return;

            var model = await contractServices.GetViewModelByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(model.ClientId.Value);

            #region [CLIENT EMAIL]
            var html = await RenderPartialViewToString("ContractWeightAlmostEndEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, você usou 75% da sua franquia de peso.", html, null);
#else
            emailServices.Send($"{client.Name}, você usou 75% da sua franquia de peso.", html, new List<string> { model.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("ContractWeightAlmostEnd_AdminEmail", client, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, atingiu 75% da franquia de peso.", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"{client.Name}, atingiu 75% da franquia de peso.", html_Admin, new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" });
#endif
            #endregion
        }

        private async Task SendContractWeightEndEmail(int contractId)
        {
            if (!configuration.GetValue<bool>("Emails:SendContractWeightEndEmail"))
                return;

            var model = await contractServices.GetViewModelByIdAsync(contractId);
            var client = await clientServices.GetViewModelByIdAsync(model.ClientId.Value);

            #region [CLIENT EMAIL]
            var html_Client = await RenderPartialViewToString("ContractWeightEndEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, sua franquia de peso excedeu.", html_Client, new List<string> { "sarah.reggiani@bitflag.systems", "joao.gregorio@bitflag.systems" });
#else
            emailServices.Send($"{client.Name}, sua franquia de peso excedeu.", html_Client, new List<string> { model.ContactEmail });
#endif
            #endregion

            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("ContractWeightEnd_AdminEmail", client, viewEngine);
#if DEBUG
            emailServices.Send($"{client.Name}, franquia excedida.", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems", "joao.gregorio@bitflag.systems" });
#else
            emailServices.Send($"{client.Name}, franquia excedida.", html_Admin, new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br", "operacional@destineja.com.br" });
#endif
            #endregion
        }

        private async Task SendNewDemandEmail(int demandId)
        {
            if (!configuration.GetValue<bool>("Emails:SendNewDemandEmail"))
                return;

            var demand = await service.GetViewModelByIdAsync(demandId);
            var driver = await transporterDriverServices.GetViewModelByIdAsync(demand.TransporterDriverId);
            var vehicle = await transporterVehicleServices.GetViewModelByIdAsync(demand.TransporterVehicleId);


            var allClients = new List<ClientViewModel>();

            #region [CLIENT EMAIL]
            foreach (var item in await demandClientServices.GetDataAsNoTrackingAsync(x => x.DemandId == demandId))
            {
                var clientCollectionAddress = await clientCollectionAddressServices.GetDataByIdAsync(item.ClientCollectionAddressId);
                var client = await clientServices.GetViewModelByIdAsync(clientCollectionAddress.ClientId);
                allClients.Add(client);

                var model = new NewDemandEmailViewModel
                {
                    Demand = demand,
                    Driver = driver,
                    Client = client,
                    Vehicle = vehicle

                };

                var html_Client = await RenderPartialViewToString("NewDemandEmail", model, viewEngine);
#if DEBUG
                emailServices.Send($"{client.Name}, sua coleta foi programada.", html_Client, null);
#else
                emailServices.Send($"{client.Name}, sua coleta foi programada.", html_Client, new List<string> { client.CentralEmail });
#endif
            }
            #endregion


            #region [ADMIN EMAIL]
            var html_Admin = await RenderPartialViewToString("NewDemand_AdminEmail", new NewDemand_AdminEmailViewModel { Demand = demand, Clients = allClients }, viewEngine);
#if DEBUG
            emailServices.Send($"MTR de coleta \"{demand.DestinaJaDemandId}\" criado. Veja o resumo...", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems", "joao.gregorio@bitflag.systems" });
#else
            emailServices.Send($"MTR de coleta \"{demand.DestinaJaDemandId}\" criado. Veja o resumo...", html_Admin, new List<string> { "operacional@destineja.com.br", "comercial@destineja.com.br" });
#endif
            #endregion
        }

        private async Task SendCloseDemandEmail(int demandId)
        {
            if (!configuration.GetValue<bool>("Emails:SendClosedDemandEmail"))
                return;

            var demand = await service.GetViewModelByIdAsync(demandId);
            var driver = await transporterDriverServices.GetViewModelByIdAsync(demand.TransporterDriverId);

            foreach (var item in await demandClientServices.GetDataAsNoTrackingAsync(x => x.DemandId == demandId))
            {
                var clientCollectionAddress = await clientCollectionAddressServices.GetDataByIdAsync(item.ClientCollectionAddressId);
                var client = await clientServices.GetViewModelByIdAsync(clientCollectionAddress.ClientId);

                var model = new CloseDemandEmailViewModel
                {
                    Demand = demand,
                    Driver = driver,
                    Client = client,
                    DemandClient = demandClientServices.ToViewModel(item)
                };

                var html = await RenderPartialViewToString("CloseDemandEmail", model, viewEngine);
#if DEBUG
                emailServices.Send($"{client.Name}, sua coleta foi finalizada.", html, new List<string> { "sarah.reggiani@bitflag.systems", "joao.gregorio@bitflag.systems" });
#else
                emailServices.Send($"{client.Name},  coleta foi finalizada.", html, new List<string> { client.CentralEmail , "operacional@destineja.com.br" });
#endif
            }
        }
        #endregion
        #endregion
    }
}
