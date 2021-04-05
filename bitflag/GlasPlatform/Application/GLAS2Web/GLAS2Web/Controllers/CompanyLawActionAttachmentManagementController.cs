using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Web;

namespace GLAS2Web.Controllers
{
    public class CompanyLawActionAttachmentManagementController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly BLL.Company.CompanyLawActionsAttachmentFunctions companyLawActionAttachmentFunctions;

        public CompanyLawActionAttachmentManagementController(IHostingEnvironment hostingEnvironment, DAL.GLAS2Context context)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.companyLawActionAttachmentFunctions = new BLL.Company.CompanyLawActionsAttachmentFunctions(context);
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? companyLawActionId)
        {
            if (!companyLawActionId.HasValue)
                return Json(null);

            filter.columns.Add(new DTO.Shared.Column() { name = "CreatedDate", data = "CreatedDate" });
            filter.order.Add(new DTO.Shared.Order() { column = filter.columns.IndexOf(filter.columns.Single(x => x.name == "CreatedDate")), dir = "DESC" });

            int recordsTotal = 0;
            int recordsFiltered = 0;
            var d = this.companyLawActionAttachmentFunctions.GetDataViewModel(this.companyLawActionAttachmentFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyLawActionId = @CompanyLawActionId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawActionId", companyLawActionId)));

            var _d = new List<DTO.Company.CompanyLawActionAttachmentViewModel>();

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
        public IActionResult _Manage([FromForm] DTO.Company.CompanyLawActionAttachmentViewModel model)
        {

            var anexo = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("CompanyLawActionfile"));

            bool validSize = anexo.Length <= 10485760 && anexo.Length > 0;
            bool validAttachment = (anexo != null && validSize);

            if (!validAttachment && anexo.FileName != "")
            {
                if (!validSize)
                {
                    return Json(-1);
                }
                if(anexo.FileName != "")
                {
                    return Json(-2);
                }
            }
            var companylawActionAttachmentDirectory = System.IO.Path.Combine("Assets", "System", "CompanyLawActionAttachment");
            var companylawActionAttachmentFilePath = System.IO.Path.Combine(companylawActionAttachmentDirectory, string.Format("{0}{1}", Guid.NewGuid().ToString(), System.IO.Path.GetExtension(anexo.FileName)));
            if (!Directory.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companylawActionAttachmentDirectory)))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companylawActionAttachmentDirectory));
            }
            var lawActionPdf = companyLawActionAttachmentFunctions.GetLawActionAttachmentFromIFormFile(model.CompanyLawActionId, anexo, companylawActionAttachmentFilePath);
            lawActionPdf.Name = model.Name;
            int companyLawActionAttachmentId = companyLawActionAttachmentFunctions.Create(lawActionPdf, anexo.OpenReadStream(), System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companylawActionAttachmentFilePath));

            return Json(model.CompanyLawActionAttachmentId);
        }

        public IActionResult GetCompanyLawActionAttachment(int companyLawActionAttachmentId)
        {
            var CompanyLawActionAttachment = companyLawActionAttachmentFunctions.GetDataByID(companyLawActionAttachmentId);

            if (CompanyLawActionAttachment != null)
                if (!System.IO.File.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, CompanyLawActionAttachment.FilePath)))
                    return NotFound();

            if (CompanyLawActionAttachment == null)
                return NotFound();

            var fullPath = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, CompanyLawActionAttachment.FilePath);

            return File(System.IO.File.ReadAllBytes(fullPath), CompanyLawActionAttachment.ContentType, CompanyLawActionAttachment.FileName);
        }

        [HttpPost]
        public IActionResult RemoveLawActionAttachmentFromCompanyLawAction(int? companyLawActionAttachmentId)
        {
            if (!companyLawActionAttachmentId.HasValue) return Json(false);
            this.companyLawActionAttachmentFunctions.Delete(companyLawActionAttachmentId.Value);
            return Json(true);
        }
    }
}
