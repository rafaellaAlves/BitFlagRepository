using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services.SeguradoProfissional;

namespace Web.ViewComponents.SeguradoProfissional
{
    public class InsuredManageViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly SeguradoProfissionalService seguradoProfissionalService;

        public InsuredManageViewComponent(SeguradoProfissionalService seguradoProfissionalService)
        {
            this.seguradoProfissionalService = seguradoProfissionalService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int seguradoProfissionalId) => await Task.Run(() => View(seguradoProfissionalService.ObterSegurado(seguradoProfissionalId)));
    }
}
