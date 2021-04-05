using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.FreezeFamily
{
    public class FreezedFamilyIndexViewComponent : ViewComponent
    {
        public FreezedFamilyIndexViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
