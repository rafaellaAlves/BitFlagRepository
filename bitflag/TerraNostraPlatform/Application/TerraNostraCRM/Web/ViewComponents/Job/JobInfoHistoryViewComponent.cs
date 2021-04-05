using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Job
{
    public class JobInfoHistoryViewComponent : ViewComponent
    {
        public JobInfoHistoryViewComponent() { }

        public IViewComponentResult Invoke(List<DTO.Job.JobInteractionViewModel> model)
        {
            return View(model);
        }
    }
}
