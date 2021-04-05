using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.AuditManagement
{
    public class AuditListViewComponent : ViewComponent
    {
        public AuditListViewComponent()
        {
        }

        public IViewComponentResult Invoke(int? companyId)
        {
            return View(companyId);
        }
    }
}
