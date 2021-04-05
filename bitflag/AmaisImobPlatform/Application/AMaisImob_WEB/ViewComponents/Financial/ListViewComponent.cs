using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL;
using AMaisImob_WEB.BLL.IUGU;
using AMaisImob_WEB.Models.Charge;
using AMaisImob_WEB.Models.Shared;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Financial
{
    [ViewComponent(Name = "Financial")]
    public class ListViewComponent : ViewComponent
    {
        private readonly BLL.FinancialFunctions financialFunctions;
        private readonly BLL.ChargeFunctions chargeFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly IUGU iugu;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;

        public ListViewComponent(BLL.FinancialFunctions financialFunctions, AMaisImob_HomologContext context, SystemVariableFunctions systemVariableFunctions, ChargeFunctions chargeFunctions, UserCompanyFunctions userCompanyFunctions, UserManager<AMaisImob_DB.Models.User> userManager)
        {
            this.financialFunctions = financialFunctions;
            iugu = new IUGU(systemVariableFunctions.GetSystemVariable("TokenIUGU"), context);
            this.chargeFunctions = chargeFunctions;
            this.userCompanyFunctions = userCompanyFunctions;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(FinancialFilterViewModel filter, bool cutScript = true, bool extract = false)
        {
            bool onlyWidthInvoice = false;

            if (User.IsInRole("Corretor"))
            {
                onlyWidthInvoice = true;

                var userId = (await userManager.GetUserAsync(HttpContext.User)).Id;
                var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                filter.RealEstateAgencyId = companyUser.CompanyId;
            }
            else if (HttpContext.User.IsInRealEstate())
            {
                onlyWidthInvoice = true;

                var userId = (await userManager.GetUserAsync(HttpContext.User)).Id;
                var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                filter.RealEstateId = companyUser.CompanyId;
            }

            var companies = await financialFunctions.GetCompaniesForCharge(filter, onlyWidthInvoice);

            foreach (var company in companies)//valida se boletos foram pagos
            {
                try
                {
                    if (company.ChargeId.HasValue && !string.IsNullOrWhiteSpace(company.IUGUInvoiceId) && !company.PayedDate.HasValue)
                    {
                        var invoice = await iugu.GetInvoice(company.IUGUInvoiceId);

                        if (invoice.Status != System.Net.HttpStatusCode.OK || invoice.Data["status"].ToString() != "paid") continue;

                        company.PayedDate = (DateTime)invoice.Data["paid_at"];
                        chargeFunctions.UpdatePaid(company.ChargeId.Value, (DateTime)invoice.Data["paid_at"]);
                    }
                }
                catch { }
            }

            return await Task.Run(() => View("List", new BaseViewModel<FinancialListViewModel>(new FinancialListViewModel(companies, filter.ReferenceDate?? filter.StartDate.Value, filter.ChargeContractualGuarantee, extract), cutScript)));
        }
    }
}
