using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    public class OrgaoController : Shared.BaseController
    {
        private readonly BLL.Utils.OrgaoFunctions OrgaoFunctions;

        public OrgaoController(DAL.GLAS2Context context)
        {
            this.OrgaoFunctions = new BLL.Utils.OrgaoFunctions(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            IEnumerable<DAL.Orgao> d = this.OrgaoFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered).ToList();

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d.ToList()
            });
        }


        public IActionResult OrgaoCreateViewComponent(int? orgaoId)
        {
            var orgao = new DTO.Law.OrgaoViewModel();

            if (orgaoId.HasValue && OrgaoFunctions.Exists(orgaoId))
                orgao = OrgaoFunctions.GetDataViewModel(OrgaoFunctions.GetDataByID(orgaoId));

            return ViewComponent(typeof(ViewComponents.LawManagement.OrgaoCreateViewComponent), new { model = orgao });
        }

        [HttpPost]
        [ActionName("Manage")]
        public IActionResult _Manage([FromForm] DTO.Law.OrgaoViewModel model)
        {
            try
            {
                int orgaoId = OrgaoFunctions.CreateOrUpdate(model);
                return Json(true);
            }
            catch
            {
                return Json(false);

            }
        }
    }
}