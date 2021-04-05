using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Family
{
    public class FamilyFreezeManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Family.FamilyFunctions familyFunctions;
        public FamilyFreezeManageViewComponent(FUNCTIONS.Family.FamilyFunctions familyFunctions)
        {
            this.familyFunctions = familyFunctions;
        }

        public IViewComponentResult Invoke(int clientId)
        {
            var data = familyFunctions.GetCondesedFamilyStructure(clientId);

            return View(data);
        }
    }
}
