using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Certificate
{
    public class CertificateManageViewComponent : ViewComponent
    {
        public CertificateManageViewComponent() { }

        public IViewComponentResult Invoke(WEB.Models.CertificateViewModel model)
        {
            return View(model);
        }
    }
}
