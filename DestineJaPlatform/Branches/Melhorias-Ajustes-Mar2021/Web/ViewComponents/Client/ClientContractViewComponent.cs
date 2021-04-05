using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientContractViewComponent : ViewComponent
    {
        public ClientContractViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(int id) => await Task.Run(() => View(id));
    }
}
