using BLL.Law;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.LawManagement
{
    public class LawChangeQuickViewViewComponent : ViewComponent
    {
        readonly LawChangeFunctions lawChangeFunctions;
        readonly LawFunctions lawFunctions;

        public LawChangeQuickViewViewComponent(LawChangeFunctions lawChangeFunctions, LawFunctions lawFunctions)
        {
            this.lawChangeFunctions = lawChangeFunctions;
            this.lawFunctions = lawFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int lawId) => await Task.Run(() => View(lawFunctions.GetDataViewModel(lawChangeFunctions.GetLawChangesFromLawId(lawId))));
    }
}
