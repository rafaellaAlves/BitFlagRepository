using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class SeasonController : Controller
    {
        private readonly BLL.SeasonFunctions seasonFunctions;

        public SeasonController(DB.Models.Insurance_HomologContext context)
        {
            this.seasonFunctions = new BLL.SeasonFunctions(context);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult SeasonIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Season.SeasonIndexViewComponent));
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            IEnumerable<WEB.Models.SeasonViewModel> d = seasonFunctions.GetDataViewModel(seasonFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, "IsDeleted = 0", whereParameter: null));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id)
        {
            return View(id);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult SeasonManageComponent(int? id)
        {
            Models.SeasonViewModel season = new Models.SeasonViewModel();
            if (id.HasValue)
                season = seasonFunctions.GetDataViewModel(seasonFunctions.GetDataByID(id));

            return ViewComponent(typeof(ViewComponents.Season.SeasonManageViewComponent), new { model = season });
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public IActionResult _Manage(Models.SeasonViewModel model)
        {
            model.SeasonId = seasonFunctions.CreateOrUpdate(model);

            return Json(new BLL.Shared.ReturnResult(model.SeasonId.Value, "", false));
        }

        [HttpPost]
        [ActionName("RemoveSeason")]
        public IActionResult RemoveSeason(int id)
        {
            if (!seasonFunctions.Exists(id)) return Json(false);

            seasonFunctions.Delete(id);
            return Json(true);
        }
    }
}