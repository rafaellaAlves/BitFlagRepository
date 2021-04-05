using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Family
{
    public class FamilyInfoManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Family.FamilyFunctions familyFunctions;
        public FamilyInfoManageViewComponent(FUNCTIONS.Family.FamilyFunctions familyFunctions)
        {
            this.familyFunctions = familyFunctions;
        }

        public IViewComponentResult Invoke(int clientId, int clientApplicantId)
        {
            var data = familyFunctions.GetStructuredFamily(clientId, clientApplicantId);
            return View(data);
        }
    }
}
