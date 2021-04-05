using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.DemandDestination;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.DemandDestination;
using DTO.Shared;
using Web.ViewComponents.DemandDestination;
using Services.Demand;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using DTO.Utils;
using Services.Client;
using Microsoft.AspNetCore.Authorization;
using Services.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class DemandDestinationController : Shared.BaseCRUDController<DemandDestination, DemandDestinationViewModel, int>
    {
        private readonly DemandDestinationServices demandDestinationServices;
        private readonly DemandDestinationListServices demandDestinationListServices;
        private readonly DemandDestinationDemandServices demandDestinationDemandServices;
        private readonly DemandDestinationStatusServices demandDestinationStatusServices;
        private readonly DemandServices demandServices;
        private readonly DemandListServices demandListServices;
        private readonly ClientServices clientServices;
        private readonly DemandClientServices demandClientServices;
        private readonly EmailServices emailServices;
        private readonly IConfiguration configuration;
        private readonly ICompositeViewEngine viewEngine;

        private readonly string MTRFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "DemandDestination", "MTR");
        private readonly string CDFFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "DemandDestination", "CDF");

        public DemandDestinationController(DemandDestinationServices service, UserManager<User> userManager, DemandDestinationListServices demandDestinationListServices, DemandDestinationDemandServices demandDestinationDemandServices, DemandDestinationStatusServices demandDestinationStatusServices, DemandServices demandServices, ClientServices clientServices, DemandClientServices demandClientServices, DemandListServices demandListServices, EmailServices emailServices, IConfiguration configuration, ICompositeViewEngine viewEngine) : base(service, userManager)
        {
            this.demandDestinationServices = service;
            this.demandDestinationListServices = demandDestinationListServices;
            this.demandDestinationDemandServices = demandDestinationDemandServices;
            this.demandDestinationStatusServices = demandDestinationStatusServices;
            this.demandServices = demandServices;
            this.clientServices = clientServices;
            this.demandClientServices = demandClientServices;
            this.demandListServices = demandListServices;
            this.emailServices = emailServices;
            this.configuration = configuration;
            this.viewEngine = viewEngine;
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public IActionResult Index() => View();
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Manage(int? id)
        {
            var demandDestination = id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new DemandDestinationViewModel();

            if (demandDestination.IsDeleted)
            {
                TempData["ErrorMessage"] = "Este MTR de Destinação foi excluído.";
                return await Task.Run(() => RedirectToAction("Index", new { error = true }));
            }

            return await Task.Run(() => View(demandDestination));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Finish(int? id) => await Task.Run(async () => View(id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new DemandDestinationViewModel()));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> MTRFile(int id) => await Task.Run(() => View(id));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> LoadDemandDestinationDemandViewComponent(int residueFamilyId, int? demandDestinationId) => await Task.Run(() => ViewComponent(typeof(DemandDestinationDemandViewComponent), new { residueFamilyId, demandDestinationId, loadFromController = true }));
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return await base.AlternativeList(filter, (filter, num1, num2, query, param) => demandDestinationListServices.ToViewModel(demandDestinationListServices.GetDataFiltered(filter, out num1, out num2, query, param)));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> ValidateDemandDestinationCreation(DemandDestinationViewModel model)
        {
            var r = await demandDestinationServices.ExistAlternativeDemandDestinationId(model.DemandDestinationId, model.AlternativeDemandDestinationId);

            return await Task.Run(() => Json(new { hasError = r, message = r ? "Este número de MTR já foi cadastrado no sistema" : "" }));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> _ManageForm(DemandDestinationViewModel model, List<DemandDestinationDemand> demands)
        {
            var alreadyFinished = model.DemandDestinationId.HasValue && (await service.GetDataByIdAsync(model.DemandDestinationId.Value)).Finished;

            if (!model.DemandDestinationId.HasValue)
            {
                model.DemandDestinationStatusId = (await demandDestinationStatusServices.GetInitialStatus()).DemandDestinationStatusId;
            }

            var r = (JsonResult)(await base.ManageAjax(model));
            var value = (dynamic)r.Value;
            var id = (int)value.id;

            if (!alreadyFinished)
            {
                await demandDestinationDemandServices.DeleteByDemandDestinationIdAsync(id);
                demands.ForEach(x => x.DemandDestinationId = id);
                await demandDestinationDemandServices.CreateRange(demands);
            }

            if (!model.DemandDestinationId.HasValue)
                await SendNewDemandDestinationEmail(id);

            return await Task.Run(() => RedirectToAction("Manage", new { id, success = true }));
        }

        async Task SendNewDemandDestinationEmail(int demandDestinationId)
        {
            if (!configuration.GetValue<bool>("Emails:SendNewDemandDestinationEmail"))
                return;

            var model = await demandDestinationServices.GetNewDemandDestinationEmailViewModel(demandDestinationId);
            var html_Admin = await RenderPartialViewToString("NewDemandDestinationEmail", model, viewEngine);
#if DEBUG
            emailServices.Send($"MTR de destinação \"{model.DemandDestination.DestineJaDemandDestinationId}\" criado. Veja o resumo...", html_Admin, new List<string> { "sarah.reggiani@bitflag.systems" });
#else
            emailServices.Send($"MTR de destinação \"{model.DemandDestination.DestineJaDemandDestinationId}\" criado. Veja o resumo...", html_Admin, new List<string> { "operacional@destineja.com.br" });
#endif
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> FinishUpdate(DemandDestinationViewModel model, List<DemandDestinationDemand> demands)
        {
            await demandDestinationServices.FinishUpdate(model); //Atualiza os dados

            //Deleta as demandas já vinculadas e inseri as novas
            await demandDestinationDemandServices.DeleteByDemandDestinationIdAsync(model.DemandDestinationId.Value);
            demands.ForEach(x => x.DemandDestinationId = model.DemandDestinationId.Value);
            await demandDestinationDemandServices.CreateRange(demands);

            return await Task.Run(() => RedirectToAction("Finish", new { id = model.DemandDestinationId.Value, success = true }));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> FinishValidate(int demandDestinationId, string weight, List<int> demandsId, [FromServices] DemandResidueFamilyTotalWeightServices demandResidueFamilyTotalWeightServices)
        {
            var _weight = weight.FromDoublePtBR();
            var entity = await service.GetDataByIdAsync(demandDestinationId);
            //var demandsIds = (await demandDestinationDemandServices.GetDataAsNoTrackingAsync(x => x.DemandDestinationId == demandDestinationId)).Select(x => x.DemandId);


            //if (string.IsNullOrWhiteSpace(entity.MTRFileGuidName))
            //{
            //    return await Task.Run(() => Json(new { hasError = true, canContinue = false, message = $"Antes de Finalizar faça o upload dos arquivos de MTR." }));
            //}

            //var totalWeight = demandsId.Select(async x => (await demandResidueFamilyTotalWeightServices.GetFirstDataAsync(x => demandsIds.Contains(x.DemandId) && x.ResidueFamilyId == entity.ResidueFamilyId))?.TotalWeight ?? 0).Sum(x => x.Result);
            var totalWeight = demandsId.Select(async c => (await demandResidueFamilyTotalWeightServices.GetFirstDataAsync(x => c == x.DemandId && x.ResidueFamilyId == entity.ResidueFamilyId))?.TotalWeight ?? 0).Sum(x => x.Result);

            int minWeight = (int)(totalWeight * .92f);
            int maxWeight = (int)(totalWeight * 1.08f);

            if (totalWeight == 0)
            {
                return await Task.Run(() => Json(new { hasError = true, canContinue = false, message = $"Não é possível prosseguir com o peso total de coleta <b>0 Kg(zero)</b>." }));
            }
            if (_weight < minWeight)
            {
                return await Task.Run(() => Json(new { hasError = true, canContinue = true, message = $"O peso inserido é inferior a 8% do total <b>({minWeight} Kg)</b>." }));
            }
            else if (_weight > maxWeight)
            {
                return await Task.Run(() => Json(new { hasError = true, canContinue = true, message = $"O peso inserido é superior a 8% do total <b>({maxWeight} Kg)</b>." }));
            }

            return await Task.Run(() => Json(new { hasError = false }));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> WeightValidate(int demandDestinationId, string weight, List<int> demandsId, [FromServices] DemandResidueFamilyTotalWeightServices demandResidueFamilyTotalWeightServices)
        {
            var _weight = weight.FromDoublePtBR();
            var entity = await service.GetDataByIdAsync(demandDestinationId);
            //var demandsIds = (await demandDestinationDemandServices.GetDataAsNoTrackingAsync(x => x.DemandDestinationId == demandDestinationId)).Select(x => x.DemandId);

            var totalWeight = demandsId.Select(async c => (await demandResidueFamilyTotalWeightServices.GetFirstDataAsync(x => c == x.DemandId && x.ResidueFamilyId == entity.ResidueFamilyId))?.TotalWeight ?? 0).Sum(x => x.Result);

            int minWeight = (int)(totalWeight * .92f);
            int maxWeight = (int)(totalWeight * 1.08f);

            if (_weight < minWeight)
            {
                return await Task.Run(() => Json(new { hasError = true, message = $"O peso inserido é inferior a 8% do total <b>({minWeight})</b>." }));
            }
            else if (_weight > maxWeight)
            {
                return await Task.Run(() => Json(new { hasError = true, message = $"O peso inserido é superior a 8% do total <b>({maxWeight})</b>." }));
            }

            return await Task.Run(() => Json(new { hasError = false }));
        }

        [ActionName("Finish")]
        [HttpPost]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> _Finish(DemandDestinationViewModel model, List<DemandDestinationDemand> demands)
        {
            await demandDestinationServices.FinishUpdate(model); //Atualiza os dados

            //Deleta as demandas já vinculadas e inseri as novas
            await demandDestinationDemandServices.DeleteByDemandDestinationIdAsync(model.DemandDestinationId.Value);
            demands.ForEach(x => x.DemandDestinationId = model.DemandDestinationId.Value);
            await demandDestinationDemandServices.CreateRange(demands);

            await demandDestinationServices.Finish(model.DemandDestinationId.Value, (await GetUser()).Id); // Finaliza o MTR de destinação

            return await Task.Run(() => RedirectToAction("Finish", new { id = model.DemandDestinationId.Value, success = true }));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> UpdateDCF(DemandDestinationViewModel model)
        {
            await demandDestinationServices.UpdateCDF(model); //Atualiza os dados

            return await Task.Run(() => RedirectToAction("Finish", new { id = model.DemandDestinationId.Value, success = true }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetDemands(string departureDate, int residueFamilyId, int? demandDestinationId)
        {
            var date = departureDate.FromBrazilianDateFormatNullable();

            var usedDemand = demandDestinationDemandServices.GetUsedDemandsNotAsync(demandDestinationId);

            var r = demandDestinationServices.GetDemandForDemandDestinationNotAsync(residueFamilyId, date);

            r = r.Where(x => !usedDemand.Any(c => c.DemandId == x.DemandId && c.ResidueFamilyId == residueFamilyId)).ToList(); //Não obtem as Coletas já utilizadas


            return await Task.Run(() => Json(r.Select(x => new { x.DemandId, x.DestinaJaDemandId, description = $"MTR - {x.DestinaJaDemandId} | Data Saída - {x._DepartureDate} | Data Chegada - {x._ArriveDate} | Peso (Kg) - {x.TotalWeight}" })));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> GetDemandsFromDemandDestination(int demandDestinationId) => await Task.Run(async () => Json(await demandDestinationDemandServices.GetDemandsByDemandDestination(demandDestinationId)));

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Unlock(int demandId, string reason)
        {
            var user = await GetUser();

            await demandDestinationServices.Unlock(demandId, user.Id, reason);

            var demandDestination = await service.GetViewModelByIdAsync(demandId);
            return await Task.Run(() => Json(new { hasError = false, message = $"A Destinação '{demandDestination.DestineJaDemandDestinationId}' foi aberta com sucesso." }));
        }


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

            if (demandDestinationServices.TryGetMTRFile(id, out DemandDestination entity)) //Deleting old file
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

                await demandDestinationServices.UpdateMTRFile(id, guidName, archive.FileName, archive.ContentType);

                return await Task.Run(() => Json(new { hasError = false, fileName = archive.FileName, message = "Arquivo importado com sucesso!" }));
            }
            catch
            {
                return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao importar o arquivo." }));
            }
        }
        public async Task<IActionResult> GetMTRFile(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(MTRFilePath, entity.MTRFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.MTRFileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));

                return await Task.Run(() => RedirectToAction("Finish", new { id = entity.DemandDestinationId, error = true }));
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
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(MTRFilePath, entity.MTRFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.MTRFileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                {
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));
                }
                return await Task.Run(() => RedirectToAction("Finish", new { id = entity.DemandDestinationId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.MTRFileMimeType, entity.MTRFileName));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> RemoveMTRFile(int id)
        {
            if (demandDestinationServices.TryGetMTRFile(id, out DemandDestination entity))
                System.IO.File.Delete(Path.Combine(MTRFilePath, entity.MTRFileGuidName));

            await demandDestinationServices.UpdateMTRFile(id, null, null, null);

            return await Task.Run(() => Json(new { success = true, message = "Arquivo removido com sucesso!" }));
        }
        #endregion

        #region [CDF File]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> UploadCDFFile(int id)
        {
            if (!Directory.Exists(CDFFilePath)) Directory.CreateDirectory(CDFFilePath);

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

            if (demandDestinationServices.TryGetCDFFile(id, out DemandDestination entity)) //Deleting old file
            {
                System.IO.File.Delete(Path.Combine(CDFFilePath, entity.CDFFileGuidName));
            }

            try
            {
                var guidName = $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}";

                var filePath = Path.Combine(CDFFilePath, guidName);

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                await demandDestinationServices.UpdateCDFFile(id, guidName, archive.FileName, archive.ContentType);

                //atualiza os status das demandas vinculadas
                var demandsToConclude = new List<int>();
                foreach (var demandId in (await demandDestinationDemandServices.GetDataAsNoTrackingAsync(x => x.DemandDestinationId == id)).Select(x => x.DemandId)) //se houver outros MTRs de destino utilizando a mesma demanda e esses MTRs não estiverem com o arquivo de CDF então essas demandas não serão consideradas como concluidas
                {
                    var demandDestionations = (await demandDestinationDemandServices.GetDataAsNoTrackingAsync(x => x.DemandId == demandId && x.DemandDestinationId != id)).Select(x => x.DemandDestinationId);
                    if (await demandDestinationServices.dbSet.AnyAsync(x => demandDestionations.Contains(x.DemandDestinationId) && string.IsNullOrWhiteSpace(x.CDFFileGuidName))) continue;

                    demandsToConclude.Add(demandId);
                }
                await demandServices.Conclude(demandsToConclude);

                return await Task.Run(() => Json(new { hasError = false, fileName = archive.FileName, message = "Arquivo importado com sucesso!" }));
            }
            catch
            {
                return await Task.Run(() => Json(new { hasError = true, message = "Houve um erro ao importar o arquivo." }));
            }
        }
        public async Task<IActionResult> GetCDFFile(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(CDFFilePath, entity.CDFFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.CDFFileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));

                return await Task.Run(() => RedirectToAction("Index", new { id = entity.DemandDestinationId, error = true }));
            }

            Response.ContentType = entity.CDFFileMimeType;
            HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + path);
            await Response.Body.WriteAsync(System.IO.File.ReadAllBytes(path));
            await Response.Body.FlushAsync();
            Response.Body.Close();
            await Response.CompleteAsync();

            return await Task.Run(() => View());
        }
        public async Task<IActionResult> DownloadCDFFile(int id)
        {
            var entity = await service.GetDataByIdAsync(id);

            var path = Path.Combine(CDFFilePath, entity.CDFFileGuidName);

            if (!System.IO.File.Exists(path))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{entity.CDFFileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));

                return await Task.Run(() => RedirectToAction("Manage", new { id = entity.DemandDestinationId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(path), entity.CDFFileMimeType, entity.CDFFileName));
        }
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> RemoveCDFFile(int id)
        {
            if (demandDestinationServices.TryGetCDFFile(id, out DemandDestination entity))
                System.IO.File.Delete(Path.Combine(CDFFilePath, entity.CDFFileGuidName));

            await demandDestinationServices.UpdateCDFFile(id, null, null, null);

            return await Task.Run(() => Json(new { success = true, message = "Arquivo removido com sucesso!" }));
        }
        #endregion
    }
}
