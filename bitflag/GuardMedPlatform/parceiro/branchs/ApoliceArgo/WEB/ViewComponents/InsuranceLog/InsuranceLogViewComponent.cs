using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.BLL;

namespace WEB.ViewComponents.InsuranceLog
{
    public class InsuranceLogViewComponent : ViewComponent
    {
        readonly SeguradoProfissionalFunctions seguradoProfissionalFunctions;

        public InsuranceLogViewComponent(SeguradoProfissionalFunctions seguradoProfissionalFunctions)
        {
            this.seguradoProfissionalFunctions = seguradoProfissionalFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int seguradoProfissionalId) => await Task.Run(async () => View(await seguradoProfissionalFunctions.GetInsuranceLog(seguradoProfissionalId)));
    }
}
