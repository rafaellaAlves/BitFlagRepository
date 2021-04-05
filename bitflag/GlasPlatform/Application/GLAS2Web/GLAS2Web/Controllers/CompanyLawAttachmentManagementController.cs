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
    public class CompanyLawAttachmentManagementController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly BLL.Company.CompanyLawAttachmentFunctions companyLawAttachmentFunctions;

        public CompanyLawAttachmentManagementController(IHostingEnvironment hostingEnvironment, DAL.GLAS2Context context)
        {
            this._hostingEnvironment = hostingEnvironment;
            this.companyLawAttachmentFunctions = new BLL.Company.CompanyLawAttachmentFunctions(context);
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? companyLawId)
        {
            if (!companyLawId.HasValue)
                return Json(new
                {
                    draw = filter.draw,
                    recordsTotal = 0,
                    recordsFiltered = 0,
                    data = new List<object>()
                });

            filter.columns.Add(new DTO.Shared.Column() { name = "CreatedDate", data = "CreatedDate" });
            filter.order.Add(new DTO.Shared.Order() { column = filter.columns.IndexOf(filter.columns.Single(x => x.name == "CreatedDate")), dir = "DESC" });

            int recordsTotal = 0;
            int recordsFiltered = 0;
            var d = this.companyLawAttachmentFunctions.GetDataViewModel(this.companyLawAttachmentFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyLawId = @CompanyLawId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyLawId", companyLawId)));

            var _d = new List<DTO.Company.CompanyLawAttachmentViewModel>();

            foreach(var item in d)
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
        public IActionResult _Manage([FromForm] DTO.Company.CompanyLawAttachmentViewModel model)
        {

            var anexo = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("CompanyLawfile"));
            
            bool validSize = anexo.Length <= 10485760 && anexo.Length > 0;
            bool validAttachment = (anexo != null && validSize);

            if (!validAttachment && anexo.FileName != "")
            {
                if (!validSize)
                {
                    return Json(-1);
                }
                if (anexo.FileName != "")
                {
                    return Json(-2);
                }
            }

            var companylawAttachmentDirectory = System.IO.Path.Combine("Assets", "System", "CompanyLawAttachment");
            var companylawAttachmentFilePath = System.IO.Path.Combine(companylawAttachmentDirectory, string.Format("{0}{1}", Guid.NewGuid().ToString(), System.IO.Path.GetExtension(anexo.FileName)));
            if (!Directory.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companylawAttachmentDirectory)))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companylawAttachmentDirectory));
            }
            var LawPdf = companyLawAttachmentFunctions.GetLawAttachmentFromIFormFile(model.CompanyLawId, anexo, companylawAttachmentFilePath);
            LawPdf.Name = model.Name;
            int companyLawAttachmentId = companyLawAttachmentFunctions.Create(LawPdf, anexo.OpenReadStream(), System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, companylawAttachmentFilePath));

            return Json(model.CompanyLawAttachmentId);
        }

        public IActionResult GetCompanyLawAttachment(int companyLawAttachmentId)
        {
            var CompanylawAttachment = companyLawAttachmentFunctions.GetDataByID(companyLawAttachmentId);

            if (CompanylawAttachment != null)
                if (!System.IO.File.Exists(System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, CompanylawAttachment.FilePath)))
                    return NotFound();

            if (CompanylawAttachment == null)
                return NotFound();

            var fullPath = System.IO.Path.Combine(this._hostingEnvironment.ContentRootPath, CompanylawAttachment.FilePath);

            return File(System.IO.File.ReadAllBytes(fullPath), CompanylawAttachment.ContentType, CompanylawAttachment.FileName);
        }

        [HttpPost]
        public IActionResult RemoveLawAttachmentFromCompanyLaw(int? companyLawAttachmentId)
        {
            if (!companyLawAttachmentId.HasValue) return Json(false);
            this.companyLawAttachmentFunctions.Delete(companyLawAttachmentId.Value);
            return Json(true);
        }

        public async Task<IActionResult> CompanyLawAttachmentListViewComponent(int companyLawId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.CompanyLawAttachment.CompanyLawAttachmentListViewComponent), new { companyLawId }));
    }
}
