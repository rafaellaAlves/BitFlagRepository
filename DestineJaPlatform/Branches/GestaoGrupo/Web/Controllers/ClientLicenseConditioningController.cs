using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using AspNetIdentityDbContext;
using DTO.Client;
using DTO.Shared;
using DTO.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Services.Client;
using Services.Shared;

namespace Web.Controllers
{
    public class ClientLicenseConditioningController : Controller
    {
        readonly UserManager<User> userManager;
        readonly ClientLicenseServices clientLicenseServices;
        readonly ClientLicenseConditioningService clientLicenseConditioningService;
        readonly ClientLicenseConditioningItemService clientLicenseConditioningItemService;
        readonly ClientLicenseConditioningItemListService clientLicenseConditioningItemListService;
        readonly string clientLicenseConditioningItemBasePath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "ClientLicenseConditioning");


        public ClientLicenseConditioningController(ClientLicenseConditioningService clientLicenseConditioningService, ClientLicenseConditioningItemService clientLicenseConditioningItemService, ClientLicenseConditioningItemListService clientLicenseConditioningItemListService, UserManager<User> userManager, ClientLicenseServices clientLicenseServices)
        {
            this.clientLicenseConditioningService = clientLicenseConditioningService;
            this.clientLicenseConditioningItemService = clientLicenseConditioningItemService;
            this.clientLicenseConditioningItemListService = clientLicenseConditioningItemListService;
            this.userManager = userManager;
            this.clientLicenseServices = clientLicenseServices;
        }

        public async Task<IActionResult> Index(int clientLicenseId) => await Task.Run(() => View(clientLicenseId));

        public async Task<IActionResult> LoadClientLicenseConditioningManageViewComponent(int? clientLicenseConditioningId, int clientLicenseId) => await Task.Run(() => ViewComponent(typeof(Web.ViewComponents.Client.ClientLicenseConditioningManageViewComponent), new { clientLicenseConditioningId, clientLicenseId, loadFromController = true }));
        public async Task<IActionResult> LoadClientLicenseConditioningItemViewComponent(int clientLicenseConditioningId) => await Task.Run(() => ViewComponent(typeof(Web.ViewComponents.Client.ClientLicenseConditioningItemIndexViewComponent), new { clientLicenseConditioningId, loadFromController = true }));

        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, int clientLicenseId)
        {
            var ListParameters = new Models.Parameters();

            ListParameters.AddParameter("IsDeleted", false);
            ListParameters.AddParameter("ClientLicenseId", clientLicenseId);

            var data = clientLicenseConditioningService.ToViewModel(clientLicenseConditioningService.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, ListParameters.GetQuery(), ListParameters.GetParameters()));

            return await Task.Run(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));
        }

        public async Task<IActionResult> ManageAjax(ClientLicenseConditioningViewModel model)
        {
            var clientLicense = await clientLicenseServices.GetDataByIdAsync(model.ClientLicenseId);

            if (!model.ProtocolDate.HasValue && !clientLicense.DueDate.HasValue)
                return await Task.Run(() => Json(new ReturnResult(null, $"A <u>Data de Protocolo</u> deve ser preenchida para prosseguir.", true)));

            if (!await clientLicenseConditioningService.CheckDate((model.ProtocolDate ?? clientLicense.IssueDate).Value, model.ClientLicenseConditioningPeriodicityId, model.DaysToRegularize.Value, model.DaysToNotify.Value))
                return await Task.Run(() => Json(new ReturnResult(null, $"A data para notificação é menor que a data atual. Altere a informação do campo <u>Data de Protocolo</u> ou <u>Notificar o vencimento em quanto dias</u> para prosseguir. Caso não possua essas informações, verifique a data de emissão da licença", true)));

            var data = await clientLicenseConditioningService.CreateOrUpdateAsync(model);

            return await Task.Run(() => Json(new DTO.Shared.ReturnResult(data, "Condicionante salva com sucesso!", false)));
        }

        public async Task Delete(int id) => await clientLicenseConditioningService.DeleteAsync(id, (await userManager.GetUserAsync(User)).Id);


        #region [ITEMS]
        public async Task<IActionResult> ListItems(DTO.Shared.DataTablesAjaxPostModel filter, int clientLicenseConditioningId)
        {
            var ListParameters = new Models.Parameters();

            ListParameters.AddParameter("IsDeleted", false);
            ListParameters.AddParameter("ClientLicenseConditioningId", clientLicenseConditioningId);

            var data = clientLicenseConditioningItemListService.ToViewModel(clientLicenseConditioningItemListService.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, ListParameters.GetQuery(), ListParameters.GetParameters()));

            return await Task.Run(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));
        }

        [HttpPost]
        public async Task<IActionResult> ManageItem(ClientLicenseConditioningItemViewModel model)
        {
            var clientLicenseConditioning = await clientLicenseConditioningService.GetDataByIdAsync(model.ClientLicenseConditioningId);
            var clientLicense = await clientLicenseServices.GetDataByIdAsync(clientLicenseConditioning.ClientLicenseId);

            if (!model.ProtocolDate.HasValue && !clientLicense.DueDate.HasValue)
                return await Task.Run(() => Json(new ReturnResult(null, $"A <u>Data de Protocolo</u> deve ser preenchida para prosseguir.", true)));

            if (!await clientLicenseConditioningService.CheckDate((model.ProtocolDate ?? clientLicense.IssueDate).Value, model.ClientLicenseConditioningPeriodicityId, model.DaysToRegularize, model.DaysToNotify))
                return await Task.Run(() => Json(new ReturnResult(null, $"A data para notificação é menor que a data atual. Altere a informação do campo <u>Data de Protocolo</u> ou <u>Notificar o vencimento em quanto dias</u> para prosseguir. Caso não possua essas informações, verifique a data de emissão da licença", true)));

            if (!Directory.Exists(clientLicenseConditioningItemBasePath)) Directory.CreateDirectory(clientLicenseConditioningItemBasePath);

            var isRenew = clientLicenseConditioningItemService.dbSet.Any(x => x.ClientLicenseConditioningId == model.ClientLicenseConditioningId);

            var r = SaveFile(ref model);

            if (!r.HasError)
            {
                await clientLicenseConditioningItemService.CreateAsync(model);
                await clientLicenseConditioningService.UpdateAsync(model.CopyToEntity<ClientLicenseConditioningViewModel>());
            }

            return await Task.Run(() => Json(new ReturnResult(null, $"Condicionante {(isRenew ? "renovada" : "criada")} com sucesso!", false)));
        }

        public async Task RemoveFile(int id)
        {
            var document = await clientLicenseConditioningItemService.GetDataByIdAsync(id);
            var file = Path.Combine(clientLicenseConditioningItemBasePath, document.FileGuid);

            await clientLicenseConditioningItemService.DeleteDefinitivelyAsync(id);

            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);
        }

        private ReturnResult SaveFile(ref ClientLicenseConditioningItemViewModel model)
        {
            #region [VALIDATION]
            if (Request.Form.Files.Count == 0) return new ReturnResult(null, "Houve um erro ao importar o arquivo.", true);

            var archive = Request.Form.Files[0];

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return new ReturnResult(null, "Arquivo com tamanho inválido (até 100 MB).", true);
                }
                if (archive.FileName != "")
                {
                    return new ReturnResult(null, "Arquivo inválido.", true);
                }
            }
            #endregion

            try
            {
                model.FileGuid = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(clientLicenseConditioningItemBasePath, model.FileGuid);


                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                model.FileName = archive.FileName;
                model.FileType = archive.ContentType;

                return new ReturnResult(null, "Arquivo salvo com sucesso", false);
            }
            catch { return new ReturnResult(null, "Houve um erro ao importar o arquivo.", true); }
        }

        public async Task<IActionResult> DownloadFile(int id)
        {
            var document = await clientLicenseConditioningItemService.GetDataByIdAsync(id);

            var filePath = Path.Combine(clientLicenseConditioningItemBasePath, document.FileGuid);

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{document.FileName}\" não foi encontrado pra download.";
                var clientLicenseConditioning = await clientLicenseConditioningService.GetDataByIdAsync(document.ClientLicenseConditioningId);
                return await Task.Run(() => RedirectToAction("Index", new { clientLicenseId = clientLicenseConditioning.ClientLicenseId, error = true }));
            }


            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), document.FileType, document.FileName));
        }
        #endregion
    }
}
