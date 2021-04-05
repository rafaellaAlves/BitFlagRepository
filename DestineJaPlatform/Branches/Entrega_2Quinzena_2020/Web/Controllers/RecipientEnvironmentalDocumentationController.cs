using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Recipient;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using System.IO;
using Services.Recipient;
using DTO.Shared;
using Web.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class RecipientEnvironmentalDocumentationController : Shared.BaseCRUDController<RecipientEnvironmentalDocumentation, RecipientEnvironmentalDocumentationViewModel, int>
    {
        private readonly string recipientEnvironmentalDocumentationPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "RecipientEnvironmentalDocumentation");
        private readonly RecipientEnvironmentalDocumentationServices recipientEnvironmentalDocumentationServices;

        public RecipientEnvironmentalDocumentationController(RecipientEnvironmentalDocumentationServices service, UserManager<User> userManager) : base(service, userManager)
        {
            recipientEnvironmentalDocumentationServices = service;
        }
        [HttpPost]
        public override async Task<IActionResult> ManageAjax(RecipientEnvironmentalDocumentationViewModel model)
        {
            if (!Directory.Exists(recipientEnvironmentalDocumentationPath)) Directory.CreateDirectory(recipientEnvironmentalDocumentationPath);

            if (Request.Form.Files.Count > 0)
            {
                if (model.RecipientEnvironmentalDocumentationId.HasValue) await RemoveFile(model.RecipientEnvironmentalDocumentationId.Value);
                var r = SaveFile(ref model);

                if (r.hasError == true) return await Task.Run(() => Json(new { success = false, message = r.message }));

                return await base.ManageAjax(model);
            }

            await recipientEnvironmentalDocumentationServices.BasicUpdateAsync(model);
            return await Task.Run(() => Json(new { id = model.RecipientEnvironmentalDocumentationId, success = true }));
        }

        private async Task RemoveFile(int id)
        {
            var document = await service.GetDataByIdAsync(id);
            var file = Path.Combine(recipientEnvironmentalDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(file)) return;

            System.IO.File.Delete(file);
        }

        private dynamic SaveFile(ref RecipientEnvironmentalDocumentationViewModel model)
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

                var filePath = Path.Combine(recipientEnvironmentalDocumentationPath, model.GuidName);


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

        public async Task<IActionResult> GetArchive(int id)
        {
            var document = await service.GetDataByIdAsync(id);

            var filePath = Path.Combine(recipientEnvironmentalDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{document.FileName}\" não foi encontrado pra download.";
                return await Task.Run(() => RedirectToAction("Manage", "Recipient", new { id = document.RecipientId, error = true }));
            }


            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), document.MimeType, document.FileName));
        }

        public override async Task DeleteDefinitively(int id)
        {
            await RemoveFile(id);

            await base.DeleteDefinitively(id);
        }

        [RequireRouteValues(new string[] { "recipientId" })]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int recipientId)
        {
            ListParameters.AddParameter("RecipientId", recipientId);

            return await base.List(filter);
        }
    }
}
