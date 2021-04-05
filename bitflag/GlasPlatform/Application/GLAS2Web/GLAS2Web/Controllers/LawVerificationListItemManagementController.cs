using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    public class LawVerificationListItemManagementController : Controller
    {
        private readonly DAL.GLAS2Context context;
        private readonly BLL.Law.LawVerificationListItemFunctions lawVerificationListItemFunctions;
        
        public LawVerificationListItemManagementController(DAL.GLAS2Context context)
        {
            this.context = context;
            this.lawVerificationListItemFunctions = new BLL.Law.LawVerificationListItemFunctions(context);
        }

        [HttpPost]
        public IActionResult Manage(DTO.Law.LawVerificationListItemViewModel model)
        {
            int lawVerificationListItemId = lawVerificationListItemFunctions.CreateOrUpdate(model);
            model.LawVerificationListItemId = lawVerificationListItemId;

            return Json(model);
        }

        [HttpPost]
        public IActionResult Get(int? id)
        {
            if (!id.HasValue) NotFound();
            if (lawVerificationListItemFunctions.Exists(id)) NotFound();

            return Json(lawVerificationListItemFunctions.GetDataViewModel(lawVerificationListItemFunctions.GetDataByID(id)));
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) NotFound();
            if (lawVerificationListItemFunctions.Exists(id)) NotFound();

            lawVerificationListItemFunctions.Delete(id);

            return Json(true);
        }
    }
}
 