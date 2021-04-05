using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GLAS2Web.Controllers
{
    public class LawVerificationListManagementController : Controller
    {
        private readonly DAL.GLAS2Context context;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Law.LawVerificationListFunctions lawVerificationListFunctions;
        private readonly BLL.Law.LawVerificationListItemFunctions lawVerificationListItemFunctions;
        private readonly BLL.Law.LawVerificationListItemViewFunctions lawVerificationListItemViewFunctions;

        public LawVerificationListManagementController(DAL.GLAS2Context context, BLL.Law.LawVerificationListItemViewFunctions lawVerificationListItemViewFunctions)
        {
            this.context = context;

            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.lawVerificationListFunctions = new BLL.Law.LawVerificationListFunctions(context);
            this.lawVerificationListItemFunctions = new BLL.Law.LawVerificationListItemFunctions(context);
            this.lawVerificationListItemViewFunctions = lawVerificationListItemViewFunctions;
        }

        // TODO: Quando criar uma lei, criar junto uma lista de verificação
        public IActionResult Get(int? lawId)
        {
            if (lawId == null) return NotFound();
            if (!lawFunctions.Exists(lawId.Value)) return NotFound();

            var lawVerificationList = lawVerificationListFunctions.GetLawVerificationListByLawId(lawId.Value);
            if (lawVerificationList != null)
                return RedirectToAction("Manage", new { id = lawVerificationList.LawVerificationListId });

            var lawViewModel = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(lawId.Value));
            int lawVerificationListId = lawVerificationListFunctions.Create(new DTO.Law.LawVerificationListViewModel() { Name = "Lista de Verificação", Description = lawViewModel.Number + ": " + lawViewModel.Title, LawId = lawId.Value });

            return RedirectToAction("Manage", new { id = lawVerificationListId });
        }

        public IActionResult Manage(int? id)
        {
            if (id == null) return NotFound();
            if (!lawVerificationListFunctions.Exists(id))
                return NotFound();
            else
                return View(this.lawVerificationListFunctions.GetDataViewModel(this.lawVerificationListFunctions.GetDataByID(id)));
        }
        [HttpPost]
        [ActionName("Manage")]
        public IActionResult _Manage([FromForm] DTO.Law.LawVerificationListViewModel model)
        {
            int lawVerificationListId = lawVerificationListFunctions.CreateOrUpdate(model);
            return RedirectToAction("Manage", new { id = lawVerificationListId, saved = true });
        }

        [HttpPost]
        public IActionResult Items(DTO.Shared.DataTablesAjaxPostModel filter, int? id)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;
            List<LawVerificationListItemView> d;
            if (id.HasValue)
                d = this.lawVerificationListItemViewFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "LawVerificationListId = @LawVerificationListId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@LawVerificationListId", id)).ToList();
            else
                d = null;
            
            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        public IActionResult Print(int? id)
        {
            if (id == null) return NotFound();
            if (!lawVerificationListFunctions.Exists(id))
                return NotFound();
            else
            {
                if (id.HasValue)
                {
                    int lawVerificationListId = Convert.ToInt32(id);
                    ViewData["items"] = lawVerificationListItemFunctions.ItemsInList(lawVerificationListId).Where(x => x.IsDeleted == false).ToList();
                    return View(this.lawVerificationListFunctions.GetDataViewModel(this.lawVerificationListFunctions.GetDataByID(id)));
                }
                else return NotFound();
            }
                
        }
    }
}
