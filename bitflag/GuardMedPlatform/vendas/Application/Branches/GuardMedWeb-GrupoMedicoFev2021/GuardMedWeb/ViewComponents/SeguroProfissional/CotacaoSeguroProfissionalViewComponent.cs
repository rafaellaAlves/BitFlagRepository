using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.ViewComponents.SeguroProfissional
{
    public class CotacaoSeguroProfissionalViewComponent : ViewComponent
    {
        public CotacaoSeguroProfissionalViewComponent()
        {
        }

        public IViewComponentResult Invoke(Models.SeguradoProfissionalViewModel model)
        {
            return View(model);
        }
    }
}
