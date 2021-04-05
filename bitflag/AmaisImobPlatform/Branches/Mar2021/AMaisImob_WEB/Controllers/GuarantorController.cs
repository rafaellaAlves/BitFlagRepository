using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.IO;

namespace AMaisImob_WEB.Controllers
{
    [Authorize(Roles = "Corretor, ImobiliariaOperacional, Administrator, ImobiliariaFinanceiro, ImobiliarioAdministrativo")]
    public class GuarantorController : Controller
    {
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.GuarantorFunctions guarantorFunctions;
        private readonly BLL.UserFunctions userFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;

        public GuarantorController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager, SignInManager<AMaisImob_DB.Models.User> signInManager)
        {
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.userManager = userManager;
            this.guarantorFunctions = new BLL.GuarantorFunctions(context);
            this.userFunctions = new BLL.UserFunctions(context, userManager);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);

        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id)
        {
            return View(id);
        }
        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(Models.GuarantorViewModel model)
        {
            var _user = await userManager.GetUserAsync(User);

            Utils.DBActionType dbActionType;
            if (model.GuarantorId != null) dbActionType = Utils.DBActionType.UPDATE;
            else dbActionType = Utils.DBActionType.CREATE;

            var file = Request.Form.Files.FirstOrDefault();

            if (file != null)
            {
                var validContentType = new List<string>() { };

                if (!file.ContentType.Contains("image")) return await Task.Run(() => Json(new { hasError = true, message = "O arquivo deve ser uma imagem." }));

                model.LogoTipoMimeType = file.ContentType;

                using (var stream = file.OpenReadStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        model.Logotipo = ms.ToArray();
                    }
                }
            }

            var guarantorId = guarantorFunctions.CreateOrUpdate(model);

            //if (guarantorId != null)
            //{ 
            //auditLogFunctions.Log("GuarantorViewModel", guarantorId, "GuarantorId", dbActionType, guarantorFunctions.GetDataViewModel(guarantorFunctions.GetDataByID(guarantorId)), _user.Id);
            //}

            return await Task.Run(() => Json(new { hasError = false, data = guarantorId }));
        }
        [HttpPost]
        [ActionName("RemoveGuarantor")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveGuarantor(int id)
        {
            if (!guarantorFunctions.Exists(id)) return Json(null);

            var _user = await userManager.GetUserAsync(User);

            guarantorFunctions.Delete(id);
            // auditLogFunctions.Log("UserViewModel", id, "UserId", Utils.DBActionType.DELETE, userFunctions.GetDataViewModel(userFunctions.GetDataByID(id)), _user.Id, "Exclusão");
            return Json(true);
        }


        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            var d = this.guarantorFunctions.GetDataViewModel(this.guarantorFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null).ToList());

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        public IActionResult GuarantorIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Guarantor.GuarantorIndexViewComponent));
        }

        [Authorize(Roles = "Corretor, ImobiliariaOperacional, Administrator, ImobiliariaFinanceiro, ImobiliarioAdministrativo")]
        public async Task<IActionResult> GetGuarantorLogo(int? guarantorId)
        {
            if (guarantorId.HasValue)
            {
                var guarantor = guarantorFunctions.GetDataByID(guarantorId);

                if (guarantor.Logotipo != null)
                    return await Task.Run(() => File(guarantor.Logotipo, guarantor.LogoTipoMimeType, $"{guarantor.RazaoSocial}_Logo"));
            }

            var directoryNoImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "noimage.png");

            var imageBytes = System.IO.File.ReadAllBytes(directoryNoImage);

            return await Task.Run(() => File(imageBytes, "image/png", "Logo"));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult GuarantorManageComponent(int? id)
        {
            Models.GuarantorViewModel model = new Models.GuarantorViewModel();

            if (id.HasValue)
                model = guarantorFunctions.GetDataViewModel(guarantorFunctions.GetDataByID(id));




            return ViewComponent(typeof(ViewComponents.Guarantor.GuarantorManageViewComponent), new { model = model });
        }
    }
}