using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.AuditManagement
{
    public class AuditManageViewComponent : ViewComponent
    {
        public AuditManageViewComponent()
        {
        }

        public IViewComponentResult Invoke(DTO.Audit.AuditViewModel model)
        {
            return View(model);
        }
    }
}
