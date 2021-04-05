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
using Services.Transporter;
using System.IO;
using Web.Utils;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class TransporterVehicleController : Shared.BaseCRUDController<TransporterVehicle, TransporterVehicleViewModel, int>
    {
        private readonly string transporterVehiclePath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "TransporterVehicle");
        private readonly string transporterVehicleLicensePlatePath;
        private readonly string transporterVehicleDUTPath;
        private readonly string transporterVehicleCIVPath;
        private readonly string transporterVehicleCIPPPath;
        private readonly TransporterVehicleServices transporterVehicleServices;

        public TransporterVehicleController(TransporterVehicleServices service, UserManager<User> userManager) : base(service, userManager)
        {
            transporterVehicleServices = service;

            transporterVehicleLicensePlatePath = Path.Combine(transporterVehiclePath, "LicensePlates");
            transporterVehicleDUTPath = Path.Combine(transporterVehiclePath, "DUT");
            transporterVehicleCIVPath = Path.Combine(transporterVehiclePath, "CIV");
            transporterVehicleCIPPPath = Path.Combine(transporterVehiclePath, "CIPP");
        }

        [HttpPost]
        public override async Task<IActionResult> ManageAjax([FromForm]TransporterVehicleViewModel viewModel)
        {
            #region [CREATE DIRECTORIES]
            if (!Directory.Exists(transporterVehicleLicensePlatePath)) Directory.CreateDirectory(transporterVehicleLicensePlatePath);
            if (!Directory.Exists(transporterVehicleDUTPath)) Directory.CreateDirectory(transporterVehicleDUTPath);
            if (!Directory.Exists(transporterVehicleCIVPath)) Directory.CreateDirectory(transporterVehicleCIVPath);
            if (!Directory.Exists(transporterVehicleCIPPPath)) Directory.CreateDirectory(transporterVehicleCIPPPath);
            #endregion

            #region [CREATEORUPDATE]
            int transporterVehicleId;
            transporterVehicleId = viewModel.TransporterVehicleId.HasValue? await transporterVehicleServices.BasicUpdateAsync(viewModel) : await service.CreateAsync(viewModel);
            #endregion
            
            viewModel.TransporterVehicleId = transporterVehicleId;

            #region [SAVE ARCHIVES]
            var erros = new List<object>();

            var r = await SaveFile(viewModel, "LicensePlate");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterVehicleServices.BasicUpdateLicensePlateFileAsync(viewModel);
            }

            r = await SaveFile(viewModel, "DUT");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterVehicleServices.BasicUpdateDUTFileAsync(viewModel);
            }

            r = await SaveFile(viewModel, "CIV");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterVehicleServices.BasicUpdateCIVFileAsync(viewModel);
            }

            r = await SaveFile(viewModel, "CIPP");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterVehicleServices.BasicUpdateCIPPFileAsync(viewModel);
            }
            #endregion

            return await Task.Run(() => Json(new { id = transporterVehicleId, success = erros.Count == 0, erros }));
        }

        private async Task RemoveFile(int id, string archive)
        {
            var document = await service.GetDataByIdAsync(id);

            var pathName = GetDirectoryPathByArchiveType(archive);

            var guidNameProp = typeof(ApplicationDbContext.Models.TransporterVehicle).GetProperty($"{archive}GuidName");

            var guidName = guidNameProp.GetValue(document);
            if (guidName == null) return;

            var file = Path.Combine(pathName, (string)guidName);

            if (!System.IO.File.Exists(file)) return;

            System.IO.File.Delete(file);
        }

        [ActionName("RemoveFile")]
        public  async Task<IActionResult> _RemoveFile(int id, string archive)
        {
            await RemoveFile(id, archive);

            var model = new TransporterVehicleViewModel { TransporterVehicleId = id };

            if(archive == "LicensePlate") await transporterVehicleServices.BasicUpdateLicensePlateFileAsync(model);
            else if (archive == "DUT") await transporterVehicleServices.BasicUpdateDUTFileAsync(model);
            else if (archive == "CIPP") await transporterVehicleServices.BasicUpdateCIPPFileAsync(model);
            else if (archive == "CIV") await transporterVehicleServices.BasicUpdateCIVFileAsync(model);

            return await Task.Run(() => Json(true));
        }

        private async Task<dynamic> SaveFile(TransporterVehicleViewModel model, string archiveName)
        {
            #region [VALIDATION]
            var archive = Request.Form.Files.SingleOrDefault(x => x.Name == archiveName);

            if(archive == null) return null;

            var pathName = GetDirectoryPathByArchiveType(archiveName);

            //Delete old archive
            await RemoveFile(model.TransporterVehicleId.Value, archiveName);

            bool validSize = archive.Length <= 104857600 && archive.Length > 0;
            bool validAttachment = (archive != null && validSize);

            if (!validAttachment && archive.FileName != "")
            {
                if (!validSize)
                {
                    return new { hasError = true, message = "Arquivo com tamanho inválido (até 100 MB).", fileName = archive.FileName ?? archiveName };
                }
                if (archive.FileName != "")
                {
                    return new { hasError = true, message = "Arquivo inválido.", fileName = archive.FileName?? archiveName };
                }
            }
            #endregion

            try
            {
                var guidNameProp = typeof(TransporterVehicleViewModel).GetProperty($"{archiveName}GuidName");

                guidNameProp.SetValue(model, $"{Guid.NewGuid()}{Path.GetExtension(archive.FileName)}");

                var filePath = Path.Combine(pathName, (string)guidNameProp.GetValue(model));

                using (Stream strArchive = archive.OpenReadStream())
                {
                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        strArchive.Seek(0, SeekOrigin.Begin);
                        strArchive.CopyTo(fileStream);
                    }
                }

                var mimeTypeProp = typeof(TransporterVehicleViewModel).GetProperty($"{archiveName}MimeType");
                var fileNameProp = typeof(TransporterVehicleViewModel).GetProperty($"{archiveName}FileName");

                mimeTypeProp.SetValue(model, archive.ContentType);
                fileNameProp.SetValue(model, archive.FileName);

                return new { hasError = false };
            }
            catch { return new { hasError = true, message = "Houve um erro ao importar o arquivo.", fileName = archiveName }; }

        }

        public async Task<IActionResult> GetArchive(int id, string archive)
        {
            var document = await service.GetDataByIdAsync(id);

            var guidNameProp = typeof(TransporterVehicle).GetProperty($"{archive}GuidName");
            var mimeTypeProp = typeof(TransporterVehicle).GetProperty($"{archive}MimeType");
            var fileNameProp = typeof(TransporterVehicle).GetProperty($"{archive}FileName");

            var pathName = GetDirectoryPathByArchiveType(archive);

            var filePath = Path.Combine(pathName, (string)guidNameProp.GetValue(document));

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{(string)fileNameProp.GetValue(document)}\" não foi encontrado pra download.";
                return await Task.Run(() => RedirectToAction("Manage", "Transporter", new { id = document.TransporterId, error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), (string)mimeTypeProp.GetValue(document), (string)fileNameProp.GetValue(document)));
        }

        public override async Task DeleteDefinitively(int id)
        {
            await RemoveFile(id, "LicensePlate");
            await RemoveFile(id, "DUT");
            await RemoveFile(id, "CIV");
            await RemoveFile(id, "CIPP");

            await base.DeleteDefinitively(id);
        }

        [RequireRouteValues(new string[] { "transporterId" })]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int transporterId)
        {
            ListParameters.AddParameter("TransporterId", transporterId);

            return await base.List(filter);
        }

        private string GetDirectoryPathByArchiveType(string archive)
        {
            string path = "";

            switch (archive)
            {
                case "LicensePlate": path = transporterVehicleLicensePlatePath; break;
                case "DUT": path = transporterVehicleDUTPath; break;
                case "CIV": path = transporterVehicleCIVPath; break;
                case "CIPP": path = transporterVehicleCIPPPath; break;
            }

            return path;
        }

        public async Task Active(int id) => await transporterVehicleServices.ChangeActivity(id, true);
        public async Task Inactive(int id) => await transporterVehicleServices.ChangeActivity(id, false);
    }
}