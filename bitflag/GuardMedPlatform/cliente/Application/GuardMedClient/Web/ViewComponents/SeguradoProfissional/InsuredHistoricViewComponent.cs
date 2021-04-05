using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Services.SeguradoProfissional;

namespace Web.ViewComponents.SeguradoProfissional
{
    public class InsuredHistoricViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly SeguradoProfissionalHistoricoService seguradoProfissionalHistoricoService;

        public InsuredHistoricViewComponent(SeguradoProfissionalHistoricoService seguradoProfissionalHistoricoService)
        {
            this.seguradoProfissionalHistoricoService = seguradoProfissionalHistoricoService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? seguradoProfissionalHistoricoId, int seguradoProfissionalId) => await Task.Run(async () => View(await seguradoProfissionalHistoricoService.GetChange(seguradoProfissionalHistoricoId, seguradoProfissionalId)));
    }
}
