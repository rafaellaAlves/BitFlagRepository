using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.LawManagement
{
    public class SegmentoCreateViewComponent : ViewComponent
    {
        public SegmentoCreateViewComponent()
        {
        }

        public IViewComponentResult Invoke(DTO.Law.SegmentoViewModel model)
        {
            return View(model);
        }
    }
}
