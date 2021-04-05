using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Season
{
    public class SeasonManageViewComponent : ViewComponent
    {
        public SeasonManageViewComponent() { }

        public IViewComponentResult Invoke(AMaisImob_WEB.Models.SeasonViewModel model)
        {
            return View(model);
        }
    }
}
