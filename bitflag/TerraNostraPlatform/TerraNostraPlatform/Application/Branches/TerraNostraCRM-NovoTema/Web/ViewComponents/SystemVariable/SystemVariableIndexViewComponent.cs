using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.SystemVariable
{
    public class SystemVariableIndexViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions;

        public SystemVariableIndexViewComponent(FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions)
        {
            this.systemVariableFunctions = systemVariableFunctions;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
