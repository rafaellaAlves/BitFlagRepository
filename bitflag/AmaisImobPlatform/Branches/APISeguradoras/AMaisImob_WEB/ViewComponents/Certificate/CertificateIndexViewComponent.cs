using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Certificate
{
    public class CertificateIndexViewComponent : ViewComponent
    {
        public CertificateIndexViewComponent() { }

        public IViewComponentResult Invoke(int certificateType)
        {
            return View(certificateType);
        }
    }
}
