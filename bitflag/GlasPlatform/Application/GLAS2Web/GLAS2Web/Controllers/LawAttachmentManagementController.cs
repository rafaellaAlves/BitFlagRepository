using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using GLAS2Web.Security;

namespace GLAS2Web.Controllers
{
    public class LawAttachmentManagementController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly BLL.Law.LawAttachmentFunctions lawAttachmentFunctions;

        public LawAttachmentManagementController(IHostingEnvironment hostingEnvironment, DAL.GLAS2Context context)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.lawAttachmentFunctions = new BLL.Law.LawAttachmentFunctions(context);
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? lawId)
        {
            if (!lawId.HasValue)
                return Json(null);

            filter.columns.Add(new DTO.Shared.Column() { name = "CreatedDate", data = "CreatedDate" });
            filter.order.Add(new DTO.Shared.Order() { column = filter.columns.IndexOf(filter.columns.Single(x => x.name == "CreatedDate")), dir = "DESC" });

            int recordsTotal = 0;
            int recordsFiltered = 0;
            var d = this.lawAttachmentFunctions.GetDataViewModel(this.lawAttachmentFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "LawId = @LawId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@LawId", lawId)));

            var _d = new List<DTO.Law.LawAttachmentViewModel>();

            foreach (var item in d)
            {
                var fullPath = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, item.FilePath);
                if (System.IO.File.Exists(fullPath))
                {
                    _d.Add(item);
                }
            }

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = _d
            });
        }

        [HttpPost]
        [ActionName("Manage")]
        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public IActionResult _Manage([FromForm] DTO.Law.LawAttachmentViewModel model)
        {
            var anexo = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("Lawfile"));
                        
            bool validAttachment = (anexo != null);

            if (!validAttachment && anexo.FileName != "")
            {
                if (anexo.FileName != "")
                {
                    return Json(-1);
                }
            }

            var lawAttachmentDirectory = System.IO.Path.Combine("Assets", "System", "LawAttachment");
            var lawAttachmentFilePath = System.IO.Path.Combine(lawAttachmentDirectory, string.Format("{0}{1}", Guid.NewGuid().ToString(), System.IO.Path.GetExtension(anexo.FileName)));
            if (!Directory.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, lawAttachmentDirectory)))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, lawAttachmentDirectory));
            }
            var LawPdf = lawAttachmentFunctions.GetLawAttachmentFromIFormFile(model.LawId, anexo, lawAttachmentFilePath);
            LawPdf.Name = model.Name;
            int lawAttachmentId = lawAttachmentFunctions.Create(LawPdf, anexo.OpenReadStream(), System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, lawAttachmentFilePath));

            return Json(model.LawAttachmentId);
        }

        public IActionResult GetLawAttachment(int lawAttachmentId)
        {
            var LawAttachment = lawAttachmentFunctions.GetDataByID(lawAttachmentId);

            if (LawAttachment != null)
                if (!System.IO.File.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, LawAttachment.FilePath)))
                    return NotFound();

            if (LawAttachment == null)
                return NotFound();

            var fullPath = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, LawAttachment.FilePath);

            return File(System.IO.File.ReadAllBytes(fullPath), LawAttachment.ContentType, LawAttachment.FileName);
        }

        [HttpPost]
        public IActionResult RemoveLawAttachmentFromLaw(int? lawAttachmentId)
        {
            if (!lawAttachmentId.HasValue) return Json(false);
            this.lawAttachmentFunctions.Delete(lawAttachmentId.Value);
            return Json(true);
        }

        public async Task<IActionResult> SetFullLaw(int lawAttachmentId)
        {
            var lawAttachment = lawAttachmentFunctions.GetDataByID(lawAttachmentId);

            await lawAttachmentFunctions.RemoveFullLaw(lawAttachment.LawId);
            await lawAttachmentFunctions.SetFullLaw(lawAttachmentId);
            return await Task.Run(() => Json(new { hasError = false, message = $"Anexo\"{lawAttachment.Name}\" foi definido como lei na íntegra com sucesso!" }));
        }
    }
}