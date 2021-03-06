using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Menu
{
    public class MenuClientViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => await Task.Run(() => View());
    }
}
