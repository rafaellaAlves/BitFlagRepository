using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.FreezeFamily
{
    public class FreezedFamilyManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions;
        public FreezedFamilyManageViewComponent(FUNCTIONS.Family.FreezedFamilyFunctions freezedFamilyFunctions)
        {
            this.freezedFamilyFunctions = freezedFamilyFunctions;
        }

        public IViewComponentResult Invoke(int freezedFamilyId)
        {
            return View(freezedFamilyFunctions.GetDataViewModel(freezedFamilyFunctions.GetDataByID(freezedFamilyId)));
        }
    }
}
