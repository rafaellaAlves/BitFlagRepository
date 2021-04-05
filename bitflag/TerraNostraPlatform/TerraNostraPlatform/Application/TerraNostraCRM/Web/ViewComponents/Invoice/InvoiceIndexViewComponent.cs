using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Invoice
{
    public class InvoiceIndexViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? invoiceStatusId)
        {
            return View(invoiceStatusId);
        }
    }
}
