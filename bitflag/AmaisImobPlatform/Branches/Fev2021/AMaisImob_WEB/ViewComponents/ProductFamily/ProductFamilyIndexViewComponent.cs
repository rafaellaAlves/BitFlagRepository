using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ProductFamily
{
    public class ProductFamilyIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(() => View());
    }
}
