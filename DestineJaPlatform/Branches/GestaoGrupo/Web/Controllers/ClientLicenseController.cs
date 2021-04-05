using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Client;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Net.Mime;

namespace Web.Controllers
{
    [Authorize]
    public class ClientLicenseController : Shared.BaseCRUDController<ClientLicense, ClientLicenseViewModel, int>
    {
        private readonly string clientLicenseDocumentationPath = Path.Combine(Directory.GetCurrentDirectory(), "SystemArchives", "ClientLicense");
        private readonly ClientLicenseServices clientLicenseServices;
        private readonly ClientServices clientServices;

        public ClientLicenseController(ClientLicenseServices service, UserManager<User> userManager, ClientLicenseServices clientLicenseServices, ClientServices clientServices) : base(service, userManager)
        {
            this.clientLicenseServices = clientLicenseServices;
            this.clientServices = clientServices;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> ListPrint(List<ClientLicenseViewModel> model) => await Task.Run(() => View(model));

        public async Task<IActionResult> LoadClientLicenseManageViewComponent(int? clientLicenseId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Client.ClientLicenseManageViewComponent), new { clientLicenseId, loadFromController = true }));

        public override async Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
            ListParameters.AddParameter("ClientId", clientId);

            return await base.List(filter);
        }

        [HttpPost]
        public override async Task<IActionResult> ManageAjax(ClientLicenseViewModel model)
        {
            if (!Directory.Exists(clientLicenseDocumentationPath)) Directory.CreateDirectory(clientLicenseDocumentationPath);

            var clientId = clientServices.GetClientIdByLoggedUser(HttpContext, out int userId);
            model.ClientId = clientId;
            model.CreatedBy = userId;

            if (Request.Form.Files.Count > 0)
            {
                if (model.ClientLicenseId.HasValue) await RemoveFile(model.ClientLicenseId.Value);
                var r = SaveFile(ref model);

                if (r.hasError == true) return await Task.Run(() => Json(new { success = false, message = r.message }));

                var res = (JsonResult)await base.ManageAjax(model);
                var value = (dynamic)res.Value;
                var id = (int)value.id;

                return await Task.Run(() => Json(new { id = model.ClientLicenseId, success = true, message = "Dados salvos com sucesso!" }));
            }

            await clientLicenseServices.BasicUpdateAsync(model);

            return await Task.Run(() => Json(new { id = model.ClientLicenseId, success = true, message = "Dados salvos com sucesso!" }));
        }

        private async Task RemoveFile(int id)
        {
            var document = await service.GetDataByIdAsync(id);
            var file = Path.Combine(clientLicenseDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(file)) return;

            System.IO.File.Delete(file);
        }

        private dynamic SaveFile(ref ClientLicenseViewModel model)
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

                var filePath = Path.Combine(clientLicenseDocumentationPath, model.GuidName);


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

            var filePath = Path.Combine(clientLicenseDocumentationPath, document.GuidName);

            if (!System.IO.File.Exists(filePath))
            {
                TempData["ErrorMessage"] = $"O arquivo \"{document.FileName}\" não foi encontrado pra download.";

                return await Task.Run(() => RedirectToAction("Index", "ClientLicense", new { error = true }));
            }

            return await Task.Run(() => File(System.IO.File.ReadAllBytes(filePath), document.MimeType, document.FileName));
        }
        public override async Task DeleteDefinitively(int id)
        {
            await RemoveFile(id);

            await base.DeleteDefinitively(id);
        }

        public async Task<IActionResult> ListPrintDownload(List<ClientLicenseViewModel> model, [FromServices] ICompositeViewEngine viewEngine)
        {
            var stream = new MemoryStream();
            ViewData["PDF"] = true;

            var htmlPdf = await RenderPartialViewToString("ListPrint", model, viewEngine);
            iText.Html2pdf.HtmlConverter.ConvertToPdf(htmlPdf, stream);

            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "Licenças.pdf"));
        }
    }
}
