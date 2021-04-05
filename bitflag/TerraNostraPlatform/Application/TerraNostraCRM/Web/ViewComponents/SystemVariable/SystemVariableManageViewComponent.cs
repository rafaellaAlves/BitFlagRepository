using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.SystemVariable
{
    public class SystemVariableManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions;

        public SystemVariableManageViewComponent(FUNCTIONS.SystemVariable.SystemVariableFunctions systemVariableFunctions)
        {
            this.systemVariableFunctions = systemVariableFunctions;
        }

        public IViewComponentResult Invoke(string key)
        {
            if (!string.IsNullOrWhiteSpace(key)) return View(systemVariableFunctions.GetDataByID(key));

            return View(new DB.SystemVariable());
        }
    }
}
