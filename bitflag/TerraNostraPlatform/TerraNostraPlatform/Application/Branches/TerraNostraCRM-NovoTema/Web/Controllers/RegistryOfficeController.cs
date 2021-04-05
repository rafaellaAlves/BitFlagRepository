using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RegistryOfficeController : Controller
    {
        private readonly FUNCTIONS.RegistryOffice.RegistryOfficeFunctions registryOfficeFunctions;

        public RegistryOfficeController(FUNCTIONS.RegistryOffice.RegistryOfficeFunctions registryOfficeFunctions)
        {
            this.registryOfficeFunctions = registryOfficeFunctions;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Manage(DTO.RegistryOffice.RegistryOfficeViewModel model)
        {
            model.RegistryOfficeId = registryOfficeFunctions.CreateOrUpdate(model);

            return Json(model);
        }
        public JsonResult Remove(int id)
        {
            try
            {
                registryOfficeFunctions.Delete(id);
                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            IEnumerable<DTO.RegistryOffice.RegistryOfficeViewModel> d = registryOfficeFunctions.GetDataViewModel(registryOfficeFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        public IActionResult RegistryOfficeManageViewComponent(int? id)
        {
            return ViewComponent(typeof(ViewComponents.RegistryOffice.RegistryOfficeManageViewComponent), new { id });
        }
        public IActionResult RegistryOfficeIndexViewComponent()
        {
            return ViewComponent(typeof(ViewComponents.RegistryOffice.RegistryOfficeIndexViewComponent));
        }
    }
}
