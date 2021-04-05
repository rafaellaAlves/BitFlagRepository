using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace GLAS2Web.Controllers
{
    public class CompanyLawVerificationListItemResponseManagementController : Controller
    {
        private readonly DAL.GLAS2Context context;

        private readonly BLL.Company.CompanyLawVerificationListResponseFunctions companyLawVerificationListItemResponseFunctions;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Law.LawVerificationListFunctions lawVerificationListFunctions;
        private readonly BLL.Law.LawVerificationListItemFunctions lawVerificationListItemFunctions;
        private readonly BLL.Law.LawFunctions lawFunctions;
        private readonly BLL.Company.CompanyLawActionTypeFunctions companyLawActionTypeFunctions;
        private readonly UserManager<DAL.Identity.User> userManager;

        public CompanyLawVerificationListItemResponseManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager)
        {
            this.context = context;
            this.companyLawVerificationListItemResponseFunctions = new BLL.Company.CompanyLawVerificationListResponseFunctions(context);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.lawVerificationListFunctions = new BLL.Law.LawVerificationListFunctions(context);
            this.lawVerificationListItemFunctions = new BLL.Law.LawVerificationListItemFunctions(context);
            this.lawFunctions = new BLL.Law.LawFunctions(context);
            this.companyLawActionTypeFunctions = new BLL.Company.CompanyLawActionTypeFunctions(context);
            this.userManager = userManager;
        }

        public IActionResult Index(int companyLawId)
        {
            var companyLaw = companyLawFunctions.GetDataViewModel(companyLawFunctions.GetDataByID(companyLawId));
            if (companyLaw == null) return View("NotFound");

            var lawVerificationList = lawVerificationListFunctions.GetLawVerificationListByLawId(companyLaw.LawId);
            if (lawVerificationList == null) return View("NotFound");
            if (lawVerificationListItemFunctions.GetData(x => x.LawVerificationListId == lawVerificationList.LawVerificationListId).Count() == 0) return View("NotFound");


            ViewData["Law"] = companyLaw.Law;
            ViewData["CompanyId"] = companyLaw.CompanyId;
            ViewData["CompanyLawId"] = companyLaw.CompanyLawId;
            ViewData["LawVerificationListId"] = lawVerificationList.LawVerificationListId;

            ViewData["CompanyLawActionType"] = this.companyLawActionTypeFunctions.GetData();

            return View(companyLawVerificationListItemResponseFunctions.GetCompanyLawVerificationListItemResponse(companyLawId, lawVerificationList.LawVerificationListId));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]List<DTO.Company.CompanyLawVerificationListItemResponseViewModel> model)
        {
            var user = await this.userManager.GetUserAsync(User);
            foreach (var item in model)
            {
                item.LastHandler = user.Id;
                var id = companyLawVerificationListItemResponseFunctions.CreateOrUpdate(item);
            }
            return Json(true);
        }

        public IActionResult Print(int? id, int companyLawId)
        {
            if (id == null) return NotFound();
            if (!lawVerificationListFunctions.Exists(id))
                return NotFound();
            else
            {
                if (id.HasValue)
                {
                    int lawVerificationListId = Convert.ToInt32(id);
                    var _model = companyLawFunctions.GetDataByID(companyLawId);
                    ViewData["Law"] = lawFunctions.GetDataViewModel(lawFunctions.GetDataByID(_model.LawId));
                    ViewData["CompanyLawActionType"] = this.companyLawActionTypeFunctions.GetData();
                    ViewData["items"] = companyLawVerificationListItemResponseFunctions.GetCompanyLawVerificationListItemResponse(companyLawId, lawVerificationListId);
                    return View(companyLawVerificationListItemResponseFunctions.GetCompanyLawVerificationListItemResponse(companyLawId, lawVerificationListId));
                }
                else return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> List(int? companyLawId)
        {
            var _companyLawVerificationListItemResponses = new List<DTO.Company.CompanyLawVerificationListItemResponseViewModel>();
            if(!companyLawId.HasValue) return Json(_companyLawVerificationListItemResponses);

            var companyLaw = companyLawFunctions.GetData().FirstOrDefault(x => x.CompanyLawId == companyLawId);
            if(companyLaw == null)
                return Json(_companyLawVerificationListItemResponses);

            var lawVerificationList = lawVerificationListFunctions.GetData().FirstOrDefault(x => x.LawId == companyLaw.LawId);

            if (lawVerificationList != null)
                _companyLawVerificationListItemResponses = companyLawVerificationListItemResponseFunctions.GetCompanyLawVerificationListItemResponse(companyLawId.Value, lawVerificationList.LawVerificationListId);

            foreach (var _listItemResponse in _companyLawVerificationListItemResponses)
            {
                if (!_listItemResponse.CompanyLawActionType.HasValue) _listItemResponse.CompanyLawActionTypeName = "-";
                else _listItemResponse.CompanyLawActionTypeName = companyLawActionTypeFunctions.GetDataByID(_listItemResponse.CompanyLawActionType).Name;
            }


            return Json(_companyLawVerificationListItemResponses);
        }
    }
}