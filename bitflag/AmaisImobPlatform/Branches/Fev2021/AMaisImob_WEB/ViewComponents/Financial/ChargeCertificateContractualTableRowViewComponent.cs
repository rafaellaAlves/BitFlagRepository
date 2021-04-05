using AMaisImob_WEB.Models.Charge;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Financial
{
    [ViewComponent(Name = "Financial")]
    public class ChargeCertificateContractualTableRowViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ChargePriceItem chargePriceItem, int realEstateId, bool chargeContractualGuarantee)
        {
            ViewBag.RealEstateId = realEstateId;
            ViewBag.ChargeContractualGuarantee = chargeContractualGuarantee;

            return await Task.Run(() => View("ChargeCertificateContractualTableRow", chargePriceItem));
        }
    }
}
