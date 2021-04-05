using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.FreezeFamily
{
    public class FreezedFamilyInvoiceViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Invoice.InvoiceFreezedFamilyItemFunctions invoiceFreezedFamilyItemFunctions;
        public FreezedFamilyInvoiceViewComponent(FUNCTIONS.Invoice.InvoiceFreezedFamilyItemFunctions invoiceFreezedFamilyItemFunctions)
        {
            this.invoiceFreezedFamilyItemFunctions = invoiceFreezedFamilyItemFunctions;
        }
        public IViewComponentResult Invoke(int freezedFamilyId, int invoiceId)
        {
            return View(invoiceFreezedFamilyItemFunctions.GetFreezedFamilyInvoiceViewModel(freezedFamilyId, invoiceId));
        }
    }
}