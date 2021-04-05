using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Controllers
{
    public class FreezedFamilyController : Controller
    {
        private readonly FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions;
        private readonly FUNCTIONS.Family.FamilyFunctions familyFunctions;
        private readonly FUNCTIONS.Family.FreezedFamilyListFunctions freezedFamilyListFunctions;
        private readonly FUNCTIONS.Client.ClientFunctions clientFunctions;
        private readonly FUNCTIONS.Client.ClientStatusFunctions clientStatusFunctions;

        public FreezedFamilyController(FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions, FUNCTIONS.Family.FamilyFunctions familyFunctions, FUNCTIONS.Family.FreezedFamilyListFunctions freezedFamilyListFunctions, FUNCTIONS.Client.ClientStatusFunctions clientStatusFunctions, FUNCTIONS.Client.ClientFunctions clientFunctions)
        {
            this.freezedFamilyFunctions = freezedFamilyFunctions;
            this.familyFunctions = familyFunctions;
            this.freezedFamilyListFunctions = freezedFamilyListFunctions;
            this.clientStatusFunctions = clientStatusFunctions;
            this.clientFunctions = clientFunctions;
        }


        #region [PAGES]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(int freezedFamilyId)
        {
            return View(freezedFamilyFunctions.GetDataViewModel(freezedFamilyFunctions.GetDataByID(freezedFamilyId)));
        }
        #endregion

        #region [VIEW COMPONENT]
        public IActionResult FreezedFamilyIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.FreezeFamily.FreezedFamilyIndexViewComponent));
        }
        public IActionResult FreezedFamilyManageComponent(int freezedFamilyId)
        {
            var applicantFamilyMemberType = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").SingleOrDefault();
            if (applicantFamilyMemberType != null)
                ViewBag.applicantFamilyStructureId = familyFunctions.GetFamilyStructureByFamilyMemberTypeId(applicantFamilyMemberType.FamilyMemberTypeId).Single().FamilyStructureId;
            else
                ViewBag.applicantFamilyStructureId = 0;

            return ViewComponent(typeof(ViewComponents.FreezeFamily.FreezedFamilyManageViewComponent), new { freezedFamilyId });
        }
        public IActionResult FreezedFamilyInvoiceViewComponent(int freezedFamilyId, int invoiceId)
        {
            var applicantFamilyMemberType = familyFunctions.GetFamilyMemberTypeByExternalCode("APPLICANT").SingleOrDefault();
            if (applicantFamilyMemberType != null)
                ViewBag.applicantFamilyStructureId = familyFunctions.GetFamilyStructureByFamilyMemberTypeId(applicantFamilyMemberType.FamilyMemberTypeId).Single().FamilyStructureId;
            else
                ViewBag.applicantFamilyStructureId = 0;

            return ViewComponent(typeof(ViewComponents.FreezeFamily.FreezedFamilyInvoiceViewComponent), new { freezedFamilyId, invoiceId });
        }
        #endregion

        #region [XHR]
        [HttpPost]
        public async Task<IActionResult> FreezedFamilyList(DTO.Shared.DataTablesAjaxPostModel filter, string freezedFamilyStatusFilter)
        {
            string query = "1 = 1";
            List<SqlParameter> param = new List<SqlParameter>();

            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId();
                query += " AND ResponsibleId = @ResponsibleId";
                param.Add(new SqlParameter("@ResponsibleId", userId.Value));
            }

            if (!string.IsNullOrEmpty(freezedFamilyStatusFilter))
            {
                switch(freezedFamilyStatusFilter)
                {
                    case "APPROVED":
                        query += " AND Accepted = 1";
                        break;
                    case "REPROVED":
                        query += " AND AcceptedBy IS NOT NULL AND Accepted = 0";
                        break;
                    case "PENDING":
                        query += " AND AcceptedBy IS NULL AND Accepted = 0";
                        break;
                }
            }


            var r = freezedFamilyListFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray());

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }
        public async Task<IActionResult> AcceptFreezedFamily(int freezedFamilyId)
        {
            freezedFamilyFunctions.AcceptOrReproveFreezedFamily(freezedFamilyId, true, User.GetUserId().Value);

            var freezedFamily = freezedFamilyFunctions.GetDataByID(freezedFamilyId);
            clientFunctions.TryUpdateStatus(freezedFamily.ClientId, clientStatusFunctions.GetDataByExternalCode("GENEALOGIAAPROVADA").First().ClientStatusId);

            return await Task.Run<IActionResult>(() => RedirectToAction("Manage", new { freezedFamilyId }));
        }
        public async Task<IActionResult> ReproveFreezedFamily(int freezedFamilyId)
        {
            freezedFamilyFunctions.AcceptOrReproveFreezedFamily(freezedFamilyId, false, User.GetUserId().Value);

            var freezedFamily = freezedFamilyFunctions.GetDataByID(freezedFamilyId);
            clientFunctions.TryUpdateStatus(freezedFamily.ClientId, clientStatusFunctions.GetDataByExternalCode("GENEALOGIAREPROVADA").First().ClientStatusId);

            return await Task.Run<IActionResult>(() => RedirectToAction("Manage", new { freezedFamilyId }));
        }
        public IActionResult GetApprovedFreezedFamilies(int clientId)
        {
            return Json(freezedFamilyFunctions.GetFreezedFamilyListViewModel(freezedFamilyFunctions.GetData(x => x.ClientId == clientId /*&& x.Accepted == true*/)));
        }
        #endregion
    }
}