using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Certificate
{
    public class CertificateManageViewComponent : ViewComponent
    {
        public CertificateManageViewComponent() { }

        public IViewComponentResult Invoke(AMaisImob_WEB.Models.CertificateViewModel model)
        {
            return View(model);
        }
    }
}
