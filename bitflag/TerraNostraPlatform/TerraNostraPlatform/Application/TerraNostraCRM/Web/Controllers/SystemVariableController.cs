using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SystemVariableController : Controller
    {
        private readonly FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions;
        public SystemVariableController(FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions)
        {
            this.systemVariableFunctions = systemVariableFunctions;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [ActionName("Manage")]
        public IActionResult Manage(DB.SystemVariable systemVariable)
        {
            systemVariableFunctions.CreateOrUpdate(systemVariable);

            return RedirectToAction("Index", new { saved = true });
        }

        public IActionResult Delete(string key)
        {
            if (!systemVariableFunctions.Exists(key)) return Json(new { hasError = true, message = "Chave não encontrada." });

            systemVariableFunctions.Delete(key);
            return Json(new { hasError = false, message = "Chave removida com sucesso!" });
        }

        public IActionResult SystemVariableManageComponent(string key)
        {
            return ViewComponent(typeof(ViewComponents.SystemVariable.SystemVariableManageViewComponent), new { key });
        }


        [HttpPost]
        public async Task<IActionResult> BuscaVariavel(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            var d = systemVariableFunctions.GetDataViewModel(systemVariableFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, "Internal = 0", whereParameter: null));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }
    }
}