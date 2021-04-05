using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.LawManagement
{
    public class OrgaoCreateViewComponent : ViewComponent
    {
        public OrgaoCreateViewComponent()
        {
        }

        public IViewComponentResult Invoke(DTO.Law.OrgaoViewModel model)
        {
            return View(model);
        }
    }
}
