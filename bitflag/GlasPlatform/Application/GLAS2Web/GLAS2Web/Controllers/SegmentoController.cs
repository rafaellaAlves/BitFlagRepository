using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    public class SegmentoController : Shared.BaseController
    {
        private readonly BLL.Utils.SegmentoFunctions SegmentoFunctions;

        public SegmentoController(DAL.GLAS2Context context)
        {
            this.SegmentoFunctions = new BLL.Utils.SegmentoFunctions(context);
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

            IEnumerable<DAL.Segmento> d = this.SegmentoFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered).ToList();
            
            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d.ToList()
            });
        }


        public IActionResult SegmentoCreateViewComponent(int? SegmentoId)
        {
            var Segmento = new DTO.Law.SegmentoViewModel();

            if(SegmentoId.HasValue && SegmentoFunctions.Exists(SegmentoId))
                Segmento = SegmentoFunctions.GetDataViewModel(SegmentoFunctions.GetDataByID(SegmentoId));

            return ViewComponent(typeof(ViewComponents.LawManagement.SegmentoCreateViewComponent), new { model = Segmento});
        }

        [HttpPost]
        [ActionName("Manage")]
        public IActionResult _Manage([FromForm] DTO.Law.SegmentoViewModel model)
        {
            try
            {
                int SegmentoId = SegmentoFunctions.CreateOrUpdate(model);
                return Json(true);
            }
            catch
            {
                return Json(false);

            }
        }
    }
}