using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Transporter;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using System.IO;
using Services.Transporter;
using DTO.Shared;
using Web.Utils;
using Services.Client;
using Services.Demand;
using Microsoft.AspNetCore.Authorization;
using DTO.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class TransporterEnvironmentalDocumentationController : Shared.BaseCRUDController<TransporterEnvironmentalDocumentation, TransporterEnvironmentalDocumentationViewModel, int>
    {
        private readonly string transporterEnvironmentalDocumentationPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "TransporterEnvironmentalDocumentation");
        private readonly TransporterEnvironmentalDocumentationServices transporterEnvironmentalDocumentationServices;
        private readonly TransporterServices transporterServices;
        private readonly TransporterEnvironmentalDocumentationLicenseResidueFamilyServices transporterEnvironmentalDocumentationLicenseResidueFamilyServices;
        private readonly ClientServices clientServices;
        private readonly DemandClientServices demandClientServices;

        public TransporterEnvironmentalDocumentationController(TransporterEnvironmentalDocumentationServices service, UserManager<User> userManager, TransporterServices transporterServices, TransporterEnvironmentalDocumentationLicenseResidueFamilyServices transporterEnvironmentalDocumentationLicenseResidueFamilyServices, ClientServices clientServices, DemandClientServices demandClientServices) : base(service, userManager)
        {
            transporterEnvironmentalDocumentationServices = service;
            this.transporterServices = transporterServices;
            this.transporterEnvironmentalDocumentationLicenseResidueFamilyServices = transporterEnvironmentalDocumentationLicenseResidueFamilyServices;
            this.clientServices = clientServices;
            this.demandClientServices = demandClientServices;
        }

        [HttpPost]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> _ManageAjax(TransporterEnvironmentalDocumentationViewModel model, List<int> licenseResidueFamilyIds)
        {
            if (!Directory.Exists(transporterEnvironmentalDocumentationPath)) Directory.CreateDirectory(transporterEnvironmentalDocumentationPath);

            if (Request.Form.Files.Count > 0)
            {
                if (model.TransporterEnvironmentalDocumentationId.HasValue) await RemoveFile(model.TransporterEnvironmentalDocumentationId.Value);
                var r = SaveFile(ref model);

                if (r.hasError == true) return await Task.Run(() => Json(new { success = false, message = r.message }));

                var res = (JsonResult)await base.ManageAjax(model);
                var value = (dynamic)res.Value;
                var id = (int)value.id;

                await InsertTransporterEnvironmentalDocumentationLicenseResidueFamily(id, licenseResidueFamilyIds);

                return await Task.Run(() => Json(new { id = model.TransporterEnvironmentalDocumentationId, success = true }));
            }

            await transporterEnvironmentalDocumentationServices.BasicUpdateAsync(model);

            if (model.TransporterEnvironmentalDocumentationId.HasValue)
            {
                await InsertTransporterEnvironmentalDocumentationLicenseResidueFamily(model.TransporterEnvironmentalDocumentationId.Value, licenseResidueFamilyIds);
            }

            return await Task.Run(() => Json(new { id = model.TransporterEnvironmentalDocumentationId, success = true }));
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        private async Task InsertTransporterEnvironmentalDocumentationLicenseResidueFamily(int id, List<int> licenseResidueFamilyIds)
        {
            await transporterEnvironmentalDocumentationLicenseResidueFamilyServices.DeleteDefinitivelyByTransporterEnvironmentalDocumentationId(id);

            await transporterEnvironmentalDocumentationLicenseResidueFamilyServices.CreateRange(licenseResidueFamilyIds.Select(x => new TransporterEnvironmentalDocumentationLicenseResidueFamily
            {
                LicenseResidueFamilyId = x,
                TransporterEnvironmentalDocumentationId = id
            }));
        }

        private async Task RemoveFile(int id)
        {
            var document = await service.GetDataByIdAsync(id);
            var file = Path.Combine(transporterEnvironmentalDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(file)) return;

            System.IO.File.Delete(file);
        }

        [Authorize(Roles = Constants.AllRolesExceptClient)]
        private dynamic SaveFile(ref TransporterEnvironmentalDocumentationViewModel model)
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

                var filePath = Path.Combine(transporterEnvironmentalDocumentationPath, model.GuidName);


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

        //baixa o arquivo
        public async Task<IActionResult> GetArchive(int id)
        {
            var document = await service.GetDataByIdAsync(id);

            var filePath = Path.Combine(transporterEnvironmentalDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{document.FileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                {
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));
                }

                return await Task.Run(() => RedirectToAction("Manage", "Transporter", new { id = document.TransporterId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), document.MimeType, document.FileName));
        }

        //abre a tela com o arquivo
        public async Task<IActionResult> GetFile(int id)
        {
            var document = await service.GetDataByIdAsync(id);

            var filePath = Path.Combine(transporterEnvironmentalDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{document.FileName}\" não foi encontrado pra download.";

                if (User.IsClient())
                {
                    return await Task.Run(() => RedirectToAction("ReportDownload", "Client", new { error = true }));
                }

                return await Task.Run(() => RedirectToAction("Manage", "Transporter", new { id = document.TransporterId, error = true }));
            }


            Response.ContentType = document.MimeType;
            HttpContext.Response.Headers.Add("Content-Disposition", "inline; filename=" + document.FileName + Path.GetExtension(document.GuidName));
            await Response.Body.WriteAsync(System.IO.File.ReadAllBytes(filePath));
            await Response.Body.FlushAsync();
            Response.Body.Close();
            await Response.CompleteAsync();

            return await Task.Run(() => View());
        }


        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task DeleteDefinitively(int id)
        {
            await RemoveFile(id);

            await base.DeleteDefinitively(id);
        }

        [RequireRouteValues(new string[] { "transporterId" })]
        [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int transporterId)
        {
            ListParameters.AddParameter("TransporterId", transporterId);

            var _data = service.ToViewModel(service.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, ListParameters.GetQuery(), ListParameters.GetParameters()));

            var data = _data.Select(x => new
            {
                x.ActivityName,
                x.CreatedDate,
                x.DeletedBy,
                x.DeletedDate,
                x.DueDate,
                x.FileName,
                x.GuidName,
                x.IsDeleted,
                x.IsRSSFile,
                x.Issuer,
                x.IssuerDate,
                x.MimeType,
                x.Name,
                x.TransporterEnvironmentalDocumentationId,
                x.TransporterId,
                x.License,
                x.Email,
                x.DaysToNotify,
                LicenseResidueFamilyIds = (transporterEnvironmentalDocumentationLicenseResidueFamilyServices.GetDataAsNoTracking(c => c.TransporterEnvironmentalDocumentationId == x.TransporterEnvironmentalDocumentationId)).Select(x => x.LicenseResidueFamilyId)
            });

            return await Task.Run(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));



        }
    }
}