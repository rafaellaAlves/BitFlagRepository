using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace GuardMedWeb.Controllers
{
    public class GrupoMedicoController : Controller
    {
        private readonly BLL.SeguradoProfissional.MedicGroupFunctions medicGroupFunctions;
        private readonly BLL.SeguradoProfissional.MedicGroupListViewFunctions medicGroupListViewFunctions;
        private readonly BLL.SeguradoProfissional.MedicGroupCRMFunctions medicGroupCRMFunctions;

        public GrupoMedicoController(GuardMedWeb.DAL.GuardMedWebContext context)
        {
            this.medicGroupFunctions = new BLL.SeguradoProfissional.MedicGroupFunctions(context);
            this.medicGroupListViewFunctions = new BLL.SeguradoProfissional.MedicGroupListViewFunctions(context);
            this.medicGroupCRMFunctions = new BLL.SeguradoProfissional.MedicGroupCRMFunctions(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gerenciar(int? id)
        {
            var medicGroup = new Models.MedicGroupViewModel();
            if (id.HasValue)
                medicGroup = medicGroupFunctions.GetDataViewModel(medicGroupFunctions.GetDataByID(id));

            return View(medicGroup);
        }

        [HttpPost]
        [ActionName("Gerenciar")]
        public IActionResult _Gerenciar(Models.MedicGroupViewModel model)
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

            d = medicGroupListViewFunctions.GetDataViewModel(medicGroupListViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered));

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
        public IActionResult SalvarCRM(Models.MedicGroupCRMViewModel model)
        {
            try
            {
                if (medicGroupCRMFunctions.ExiteCRM(model.CRM, model.CRMEstado, model.MedicGroupId.Value))
                {
                    return Json(new { temErro = true, mensagem = "CRM já utilizado neste grupo médico." });
                }

                model.MedicGroupCRMId = medicGroupCRMFunctions.Create(model);

                return Json(new { temErro = false, mensagem = model.MedicGroupCRMId });
            }
            catch
            {
                return Json(new { temErro = true, mensagem = "Houve um erro ao salvar." });
            }
        }

        [HttpPost]
        [ActionName("RemoverCRM")]
        public IActionResult RemoverCRM(int? medicGroupCRMId)
        {
            if (!medicGroupCRMId.HasValue)
                return Json(new { temErro = true, mensagem = "Houve um erro ao salvar." });

            medicGroupCRMFunctions.Delete(medicGroupCRMId);

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
                    if (!BLL.Utils.Utils.GetEstados().Any(x => x.EstadoId.ToUpper() == workSheet.Cells[i, 4].Value.ToString().ToUpper())) continue;
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
            var mensagem = (crmAdicionados == 0? "Nenhum CRM foi importado." : crmAdicionados + " CRMs importados com sucesso!");
            return await Task.Run(() => Json(new { temErro = false, mensagem }));
        }

    }
}