using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Indication
{
    public class IndicationManageViewComponent : ViewComponent
    {
        public IndicationManageViewComponent() { }

        public IViewComponentResult Invoke(DTO.Indication.IndicationViewModel model)
        {
            return View(model);
        }
    }
}
