using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEB.BLL;
using WEB.Models;
using WEB.Utils;

namespace WEB.Controllers
{
    [Authorize(Roles = "Administrator, GrupoMedico")]
    public class MedicGroupController : Controller
    {

        private readonly BLL.MedicGroupFunctions medicGroupFunctions;
        private readonly BLL.MedicGroupListViewFunctions medicGroupListViewFunctions;
        private readonly BLL.MedicGroupCRMFunctions medicGroupCRMFunctions;
        private readonly BLL.UserMedicGroupFunctions userMedicGroupFunctions;
        private readonly UserManager<AspNetUser> userManager;
        private ICompositeViewEngine viewEngine;

        public MedicGroupController(BLL.MedicGroupFunctions medicGroupFunctions, BLL.MedicGroupListViewFunctions medicGroupListViewFunctions, BLL.MedicGroupCRMFunctions medicGroupCRMFunctions, BLL.UserMedicGroupFunctions userMedicGroupFunctions, UserManager<AspNetUser> userManager, ICompositeViewEngine viewEngine)
        {
            this.medicGroupFunctions = medicGroupFunctions;
            this.medicGroupListViewFunctions = medicGroupListViewFunctions;
            this.medicGroupCRMFunctions = medicGroupCRMFunctions;
            this.userMedicGroupFunctions = userMedicGroupFunctions;
            this.userManager = userManager;
            this.viewEngine = viewEngine;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "GrupoMedico")]
        public async Task<IActionResult> MedicGroupCRM()
        {
            var user = await userManager.GetUserAsync(User);

            return View(userMedicGroupFunctions.GetData(x => x.UserId == user.Id).First().MedicGroupId);
        }

        public async Task<IActionResult> Gerenciar(int? id)
        {
            var medicGroup = new Models.MedicGroupViewModel();
            if (id.HasValue)
                medicGroup = medicGroupFunctions.GetDataViewModel(medicGroupFunctions.GetDataByID(id));

            return View(medicGroup);
        }

        [HttpPost]
        [ActionName("Gerenciar")]
        public async Task<IActionResult> _Gerenciar(MedicGroupViewModel model)
        {
            try
            {
                if (medicGroupFunctions.ExiteCNPJ(model.CNPJ, model.MedicGroupId))
                {
                    return Json(new { temErro = true, mensagem = "CNPJ já utilizado." });
                }

                model.MedicGroupId = medicGroupFunctions.CreateOrUpdate(model);

                return Json(new { temErro = false, mensagem = model.MedicGroupId });
            }
            catch
            {
                return Json(new { temErro = true, mensagem = "Houve um erro ao salvar." });
            }
        }

        [HttpPost]
        [ActionName("RemoverMedicGroup")]
        [Authorize(Roles = "Administrator")]
        public IActionResult RemoverMedicGroup(int? medicGroupId)
        {
            if (!medicGroupId.HasValue)
                return Json(new { temErro = true, mensagem = "Houve um erro ao salvar." });

            medicGroupCRMFunctions.DeleteByMedicGroupId(medicGroupId.Value);

            medicGroupFunctions.Delete(medicGroupId);

            return Json(new { temErro = false, mensagem = medicGroupId });
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;
            IEnumerable<Models.GroupMedicListViewModel> d;

            SqlParameterList parameters = new SqlParameterList();

            if (User.IsInRole("GrupoMedico"))
            {
                var user = await userManager.GetUserAsync(User);

                parameters.AddQuery("MedicGroupIds", $"MedicGroupId IN ({string.Join(", ", userMedicGroupFunctions.GetData(x => x.UserId == user.Id).Select(x => x.MedicGroupId))})", "");
            }

            d = medicGroupListViewFunctions.GetDataViewModel(medicGroupListViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, parameters.GetQuery(), parameters.GetParameters()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("MedicGroupCRMList")]
        public async Task<IActionResult> MedicGroupCRMList(Models.DataTablesAjaxPostModel filter, int medicGroupId)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;
            IEnumerable<Models.MedicGroupCRMViewModel> d;

            d = medicGroupCRMFunctions.GetDataViewModel(medicGroupCRMFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "MedicGroupId = @MedicGroupId", new SqlParameter("@MedicGroupId", medicGroupId)));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("SalvarCRM")]
        public async Task<IActionResult> SalvarCRM(Models.MedicGroupCRMViewModel model)
        {
            try
            {
                if (medicGroupCRMFunctions.ExiteCRM(model.CRM, model.CRMEstado, model.MedicGroupId.Value))
                {
                    return Json(new { temErro = true, mensagem = "CRM já utilizado neste grupo médico." });
                }

                var creation = !model.MedicGroupCRMId.HasValue;

                model.MedicGroupCRMId = medicGroupCRMFunctions.Create(model);

                if (creation && User.IsInRole("GrupoMedico"))
                {
                    var medicGroup = medicGroupFunctions.GetDataViewModel(medicGroupFunctions.GetDataByID(model.MedicGroupId));

                    var html = await RenderPartialViewToString("Email", new MedicGroupEmailViewModel(model, medicGroup, (await userManager.GetUserAsync(User)).CopyToEntity<UserViewModel>(), MedicGroupEmailViewModel.MedicGroupEmailAction.Create));
#if DEBUG
                    await MailFunctions.SendAsync($"Novo Médico Adicionado - {medicGroup.MedicGroupName}", html, new List<string>() { "yuri.santana@bitflag.systems" }, null);
#else
                    await MailFunctions.SendAsync($"Novo Médico Adicionado - {medicGroup.MedicGroupName}", html, new List<string>() { "contato@guardmed.com.br" }, null);
#endif
                }

                return Json(new { temErro = false, mensagem = model.MedicGroupCRMId });
            }
            catch
            {
                return Json(new { temErro = true, mensagem = "Houve um erro ao salvar." });
            }
        }

        [HttpPost]
        [ActionName("RemoverCRM")]
        public async Task<IActionResult> RemoverCRM(int? medicGroupCRMId)
        {
            if (!medicGroupCRMId.HasValue)
                return Json(new { temErro = true, mensagem = "Houve um erro ao salvar." });

            var medicGroupCRM = medicGroupCRMFunctions.GetDataViewModel(medicGroupCRMFunctions.GetDataByID(medicGroupCRMId));

            medicGroupCRMFunctions.Delete(medicGroupCRMId);

            if (User.IsInRole("GrupoMedico"))
            {
                var medicGroup = medicGroupFunctions.GetDataViewModel(medicGroupFunctions.GetDataByID(medicGroupCRM.MedicGroupId));

                var html = await RenderPartialViewToString("Email", new MedicGroupEmailViewModel(medicGroupCRM, medicGroup, (await userManager.GetUserAsync(User)).CopyToEntity<UserViewModel>(), MedicGroupEmailViewModel.MedicGroupEmailAction.Remove));

                await MailFunctions.SendAsync($"Um Médico foi removido - {medicGroup.MedicGroupName}", html, new List<string>() { "rpetrilli@guardmed.com.br" }, null);
            }

            return Json(new { temErro = false, mensagem = medicGroupCRMId });
        }

        [HttpPost]
        [ActionName("GetDataByCRM")]
        public IActionResult GetDataByCRM(string crm, string crmEstado)
        {
            var medicGroups = medicGroupFunctions.GetMedicGroupsByCRM(crm, crmEstado);

            if (medicGroups == null || medicGroups.Count == 0) return Json(null);

            return Json(medicGroupFunctions.GetDataViewModel(medicGroups.OrderByDescending(x => x.Discount).First()));
        }

        public async Task<JsonResult> ImportarCRMs(int? medicGroupId)
        {
            var file = Request.Form.Files.SingleOrDefault(x => x.Name.Equals("Arquivo"));

            if (file == null || !medicGroupId.HasValue) return Json(new { hasError = true, mensagem = "Erro ao Importar, tente novamente." });

            bool validArchive = Path.GetExtension(file.FileName) == ".xlsx";

            if (!validArchive) return Json(new { hasError = true, mensagem = "Arquivo com extensão diferente do aceito." });

            int crmAdicionados = 0;

            using (ExcelPackage package = new ExcelPackage(file.OpenReadStream()))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                for (int i = 2;
                         i <= workSheet.Dimension.End.Row;
                         i++)
                {
                    Models.MedicGroupCRMViewModel medicGroupCRM = new Models.MedicGroupCRMViewModel();

                    if (workSheet.Cells[i, 3].Value == null || workSheet.Cells[i, 4].Value == null) continue;
                    if (!WEB.Utils.StatesUtils.GetEstados().Any(x => x.EstadoId.ToUpper() == workSheet.Cells[i, 4].Value.ToString().ToUpper())) continue;
                    if (medicGroupCRMFunctions.ExiteCRM(workSheet.Cells[i, 3].Value.ToString(), workSheet.Cells[i, 4].Value.ToString(), medicGroupId.Value)) continue;

                    if (workSheet.Cells[i, 1].Value != null)
                        medicGroupCRM.Nome = workSheet.Cells[i, 1].Value.ToString();

                    if (workSheet.Cells[i, 2].Value != null)
                    {
                        string cpf = new String(workSheet.Cells[i, 2].Value.ToString().Where(Char.IsDigit).ToArray());
                        medicGroupCRM.CPF = Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
                    }

                    medicGroupCRM.CRM = workSheet.Cells[i, 3].Value.ToString();
                    medicGroupCRM.CRMEstado = workSheet.Cells[i, 4].Value.ToString();
                    medicGroupCRM.MedicGroupId = medicGroupId;

                    medicGroupCRMFunctions.Create(medicGroupCRM);
                    crmAdicionados++;
                }
            }
            var mensagem = (crmAdicionados == 0 ? "Nenhum CRM foi importado." : crmAdicionados + " CRMs importados com sucesso!");
            return await Task.Run(() => Json(new { temErro = false, mensagem }));
        }

        private async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
