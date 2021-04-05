using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.BLL;

namespace WEB.ViewComponents.Apolice
{
    public class ApoliceViewComponent : ViewComponent
    {
        readonly SeguradoProfissionalFunctions seguradoProfissionalFunctions;

        public ApoliceViewComponent(SeguradoProfissionalFunctions seguradoProfissionalFunctions)
        {
            this.seguradoProfissionalFunctions = seguradoProfissionalFunctions;
           
        }

      //  public async Task<IViewComponentResult> InvokeAsync(int seguradoProfissionalId) => await Task.Run(() => View(seguradoProfissionalFunctions.GetApoliceById(seguradoProfissionalId)));

    }
}
