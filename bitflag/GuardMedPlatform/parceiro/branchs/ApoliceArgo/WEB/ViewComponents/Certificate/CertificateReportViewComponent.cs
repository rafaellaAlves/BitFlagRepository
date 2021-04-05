using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Certificate
{
    public class CertificateReportViewComponent : ViewComponent
    {
        public CertificateReportViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
