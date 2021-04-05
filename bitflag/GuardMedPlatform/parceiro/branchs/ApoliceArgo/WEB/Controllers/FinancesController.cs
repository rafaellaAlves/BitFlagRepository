using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class FinancesController : Controller
    {
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.ChargeFunctions chargeFunctions;
        private readonly BLL.CertificateFunctions certificateFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private readonly Insurance_HomologContext context;

        public FinancesController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
        {
            this.context = context;
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.chargeFunctions = new BLL.ChargeFunctions(context);
            certificateFunctions = new BLL.CertificateFunctions(context);
            auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator, ImobiliariaFinanceiro, ImobiliarioAdministrativo")]
        public async Task<IActionResult> Index(string referenceMonth = "", int? realEstateAgencyId = null, int? realEstateId = null)
        {
            var _realEstateAgencyId = companyTypeFunctions.GetDataByExternalCode("CORRETORA").CompanyTypeId;
            ViewData["RealEstateAgency"] = companyFunctions.GetData(c => !c.IsDeleted && c.CompanyTypeId == _realEstateAgencyId).ToList();

            if (User.IsInRealEstate())
            {
                var user = await userManager.GetUserAsync(User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    var userRealEstateAgencyId = companyFunctions.GetDataByID(companyUser.CompanyId).ParentCompanyId;
                    ViewData["UserRealEstateAgencyId"] = userRealEstateAgencyId;
                    ViewData["UserRealEstateId"] = companyUser.CompanyId;

                    if(userRealEstateAgencyId == ViewBag.RealEstateAgencyId)
                        ViewBag.RealEstateAgencyId = realEstateAgencyId;
                    if (companyUser.CompanyId == realEstateId)
                        ViewBag.RealEstateId = realEstateId;

                }
            }
            else
            {
                ViewBag.RealEstateAgencyId = realEstateAgencyId;
                ViewBag.RealEstateId = realEstateId;
            }

            ViewBag.ReferenceMonth = referenceMonth;

            return View();
        }

        public JsonResult GetCharges(int? realEstateAgencyId, int? realEstateId, string _ReferenceMonth)
        {
            var refMonth = _ReferenceMonth.FromDatePtBR();

            if (!refMonth.HasValue) return Json(new List<Models.ChargeViewModel>());

            return Json(chargeFunctions.GetCharges(realEstateAgencyId, realEstateId, refMonth.Value));
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Charge(int realEstateId, string _mouthRefence)
        {
            var chargeId = await chargeFunctions.Charge(realEstateId, _mouthRefence);
            var user = await userManager.GetUserAsync(User);

            if (chargeId != -1)
            {
                auditLogFunctions.Log("ChargeViewModel", chargeId, "ChargeId", DBActionType.CREATE, chargeFunctions.GetDataViewModel(chargeFunctions.GetDataByID(chargeId)), user.Id);
            }

            return Json(true);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> ChargeActiveRealEstates(int? realEstateAgencyId, int? realEstateId, string _mouthRefence)
        {
            var createCount = await chargeFunctions.ChargeActiveRealEstate(realEstateAgencyId, realEstateId, _mouthRefence);

            return Json(new { message = $"{createCount} Boleto(s) gerado(s) com sucesso!", hasError = false});
        }

        public async Task<JsonResult> ChargePaid(int chargeId, string payedToken)
        {
            if (!chargeFunctions.ValidatePayedToken(chargeId, payedToken)) return await Task.Run<JsonResult>(() => { return Json(false); });

            chargeFunctions.Paid(chargeId, true, true);

            auditLogFunctions.Log("ChargeViewModel", chargeId, "ChargeId", DBActionType.UPDATE, chargeFunctions.GetDataViewModel(chargeFunctions.GetDataByID(chargeId)), -1, "Pagamento");

            return await Task.Run<JsonResult>(() => { return Json(true); });
        }

        [Authorize(Roles = "Administrator")]
        public async Task<JsonResult> PayCharge(int chargeId, string payedToken)
        {
            if (!chargeFunctions.ValidatePayedToken(chargeId, payedToken)) return await Task.Run<JsonResult>(() => { return Json(new { hasError = true, message = "Token para pagamento Incorreto." }); });

            var user = await userManager.GetUserAsync(User);

            if (!User.IsInRole("Administrator")) return await Task.Run<JsonResult>(() => { return Json(new { hasError = true, message = "Você não possui permissão." }); });

            chargeFunctions.PaidByUser(user.Id, chargeId, true, true);
            auditLogFunctions.Log("ChargeViewModel", chargeId, "ChargeId", DBActionType.UPDATE, chargeFunctions.GetDataViewModel(chargeFunctions.GetDataByID(chargeId)), user.Id, "Pagamento");

            return await Task.Run<JsonResult>(() => { return Json(new { hasError = false, message = "Fatura declarada como paga." }); });
        }

        [Authorize(Roles = "Administrator")]
        public async Task<JsonResult> RemoveCharge(int chargeId)
        {
            var user = await userManager.GetUserAsync(User);

            if (!User.IsInRole("Administrator")) return await Task.Run<JsonResult>(() => { return Json(new { hasError = true, message = "Você não possui permissão." }); });

            auditLogFunctions.Log("ChargeViewModel", chargeId, "ChargeId", DBActionType.DELETE, chargeFunctions.GetDataViewModel(chargeFunctions.GetDataByID(chargeId)), user.Id);

            var charge = chargeFunctions.GetDataByID(chargeId);
            await chargeFunctions.Delete(chargeId, charge.IuguinvoiceId);

            return await Task.Run<JsonResult>(() => { return Json(new { hasError = false, message = "Fatura excluída com sucesso." }); });
        }
    }
}