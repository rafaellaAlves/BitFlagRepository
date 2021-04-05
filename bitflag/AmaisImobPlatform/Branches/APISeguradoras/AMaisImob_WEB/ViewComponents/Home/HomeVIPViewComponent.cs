using AMaisImob_WEB.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Home
{
    [ViewComponent(Name = "Home")]
    public class HomeVIPViewComponent : ViewComponent
    {
        private readonly HomeFunctions homeFunctions;
            public HomeVIPViewComponent(HomeFunctions homeFunctions)
        {
            this.homeFunctions = homeFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? realEstateId, int? realEstateAgencyId) => await Task.Run(async () => View("VIP", await homeFunctions.GetHomeVIPViewModel(realEstateAgencyId, realEstateId)));
    }
}
