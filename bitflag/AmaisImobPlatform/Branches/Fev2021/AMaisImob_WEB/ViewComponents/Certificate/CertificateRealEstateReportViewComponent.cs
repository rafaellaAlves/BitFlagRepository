using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Certificate
{
    [ViewComponent(Name = "CertificateReport")]
    public class CertificateRealEstateReportViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => await Task.Run(() => View("RealEstateReport"));
    }
}
