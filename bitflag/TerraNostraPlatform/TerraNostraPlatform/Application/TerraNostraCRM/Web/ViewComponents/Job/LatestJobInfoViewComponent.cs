using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Job
{
    public class LatestJobInfoViewComponent : ViewComponent
    {
        public LatestJobInfoViewComponent() { }

        public IViewComponentResult Invoke(DTO.Job.JobInteractionViewModel model)
        {
            return View(model);
        }
    }
}
