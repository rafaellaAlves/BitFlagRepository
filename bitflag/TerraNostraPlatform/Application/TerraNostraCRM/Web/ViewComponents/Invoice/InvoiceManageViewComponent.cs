using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Invoice
{
    public class InvoiceManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Invoice.InvoiceFunctions invoiceFunctions;

        public InvoiceManageViewComponent(FUNCTIONS.Invoice.InvoiceFunctions invoiceFunctions)
        {
            this.invoiceFunctions = invoiceFunctions;
        }

        public IViewComponentResult Invoke(int? invoiceId)
        {
            var invoiceViewModel = new DTO.Invoice.InvoiceViewModel();

            if (invoiceId.HasValue && invoiceFunctions.Exists(invoiceId))
                invoiceViewModel = invoiceFunctions.GetDataViewModel(invoiceFunctions.GetDataByID(invoiceId));

            return View(invoiceViewModel);
        }
    }
}
