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
    public class TransporterDriverController : Shared.BaseCRUDController<TransporterDriver, TransporterDriverViewModel, int>
    {
        private readonly string transporterDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "TransporterDriver");
        private readonly string transporterDriverCNHPath;
        private readonly string transporterDriverMOPPPath;
        private readonly string transporterDriverASOPath;
        private readonly TransporterDriverServices transporterDriverServices;

        public TransporterDriverController(TransporterDriverServices service, UserManager<User> userManager) : base(service, userManager)
        {
            transporterDriverServices = service;

            transporterDriverCNHPath = Path.Combine(transporterDriverPath, "CNH");
            transporterDriverMOPPPath = Path.Combine(transporterDriverPath, "MOPP");
            transporterDriverASOPath = Path.Combine(transporterDriverPath, "ASO");
        }

        [HttpPost]
        public override async Task<IActionResult> ManageAjax([FromForm]TransporterDriverViewModel viewModel)
        {
            #region [CREATE DIRECTORIES]
            if (!Directory.Exists(transporterDriverCNHPath)) Directory.CreateDirectory(transporterDriverCNHPath);
            if (!Directory.Exists(transporterDriverMOPPPath)) Directory.CreateDirectory(transporterDriverMOPPPath);
            if (!Directory.Exists(transporterDriverASOPath)) Directory.CreateDirectory(transporterDriverASOPath);
            #endregion

            #region [CREATEORUPDATE]
            viewModel.TransporterDriverId = await service.CreateOrUpdateAsync(viewModel);
            #endregion

            #region [SAVE ARCHIVES]
            var erros = new List<object>();

            var r = await SaveFile(viewModel, "CNH");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterDriverServices.BasicUpdateCNHFileAsync(viewModel);
            }

            r = await SaveFile(viewModel, "MOPP");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterDriverServices.BasicUpdateMOPPFileAsync(viewModel);
            }

            r = await SaveFile(viewModel, "ASO");
            if (r != null)
            {
                if ((bool)r.hasError) erros.Add(new { item = r.fileName, r.message });
                else await transporterDriverServices.BasicUpdateASOFileAsync(viewModel);
            }
            #endregion

            return await Task.Run(() => Json(new { id = viewModel.TransporterDriverId, success = erros.Count == 0, erros }));
        }

        private async Task RemoveFile(int id, string archive)
        {
            var document = await service.GetDataByIdAsync(id);

            var pathName = GetDirectoryPathByArchiveType(archive);

            var guidNameProp = typeof(ApplicationDbContext.Models.TransporterDriver).GetProperty($"{archive}GuidName");

            var guidName = guidNameProp.GetValue(document);
            if (guidName == null) return;

            var file = Path.Combine(pathName, (string)guidName);

            if (!System.IO.File.Exists(file)) return;

            System.IO.File.Delete(file);
        }

        [ActionName("RemoveFile")]
        public async Task<IActionResult> _RemoveFile(int id, string archive)
        {
            await RemoveFile(id, archive);

            var model = new TransporterDriverViewModel { TransporterDriverId = id };

            if (archive == "CNH") await transporterDriverServices.BasicUpdateCNHFileAsync(model);
            else if (archive == "MOPP") await transporterDriverServices.BasicUpdateMOPPFileAsync(model);
            else if (archive == "ASO") await transporterDriverServices.BasicUpdateASOFileAsync(model);

            return await Task.Run(() => Json(true));
        }

        private async Task<dynamic> SaveFile(TransporterDriverViewModel model, string archiveName)
        {
            #region [VALIDATION]
            var archive = Request.Form.Files.SingleOrDefault(x => x.Name == archiveName);

            if (archive == null) return null;

            var pathName = GetDirectoryPathByArchiveType(archiveName);

            //Delete old archive
            await RemoveFile(model.TransporterDriverId.Value, archiveName);

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
                    return new { hasError = true, message = "Arquivo inválido.", fileName = archive.FileName ?? archiveName };
                }
            }
            #endregion

            try
            {
                var guidNameProp = typeof(TransporterDriverViewModel).GetProperty($"{archiveName}GuidName");

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

                var mimeTypeProp = typeof(TransporterDriverViewModel).GetProperty($"{archiveName}MimeType");
                var fileNameProp = typeof(TransporterDriverViewModel).GetProperty($"{archiveName}FileName");

                mimeTypeProp.SetValue(model, archive.ContentType);
                fileNameProp.SetValue(model, archive.FileName);

                return new { hasError = false };
            }
            catch { return new { hasError = true, message = "Houve um erro ao importar o arquivo.", fileName = archiveName }; }
        }

        public async Task<IActionResult> GetArchive(int id, string archive)
        {
            var document = await service.GetDataByIdAsync(id);

            var guidNameProp = typeof(TransporterDriver).GetProperty($"{archive}GuidName");
            var mimeTypeProp = typeof(TransporterDriver).GetProperty($"{archive}MimeType");
            var fileNameProp = typeof(TransporterDriver).GetProperty($"{archive}FileName");

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
            await RemoveFile(id, "CNH");
            await RemoveFile(id, "MOPP");

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
                case "CNH": path = transporterDriverCNHPath; break;
                case "MOPP": path = transporterDriverMOPPPath; break;
                case "ASO": path = transporterDriverASOPath; break;
            }

            return path;
        }


        public async Task Active(int id) => await transporterDriverServices.ChangeActivity(id, true);
        public async Task Inactive(int id) => await transporterDriverServices.ChangeActivity(id, false);
    }
}
