using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Job
{
    public class JobFreezedFamilyItemInfoManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Job.JobFunctions jobFunctions;
        public JobFreezedFamilyItemInfoManageViewComponent(FUNCTIONS.Job.JobFunctions jobFunctions) 
        {
            this.jobFunctions = jobFunctions;
        }

        public IViewComponentResult Invoke(int id, string title, List<string> columns, List<string> modules, bool block, bool IsPrintMode)
        {
            var jobFreezedFamilyInfoContainerViewModel = new DTO.Job.JobFreezedFamilyInfoContainerViewModel();

            jobFreezedFamilyInfoContainerViewModel.JobId = id;
            jobFreezedFamilyInfoContainerViewModel.Title = title;
            jobFreezedFamilyInfoContainerViewModel.JobFreezedFamilyInfoViewModels = jobFunctions.GetJobFreezedFamilyItemInfo(id);
            if (columns != null) jobFreezedFamilyInfoContainerViewModel.Columns.AddRange(columns);
            if (modules != null) jobFreezedFamilyInfoContainerViewModel.Modules.AddRange(modules);
            jobFreezedFamilyInfoContainerViewModel.Block = block;
            jobFreezedFamilyInfoContainerViewModel.IsPrintMode = IsPrintMode;

            return View(jobFreezedFamilyInfoContainerViewModel);
        }
    }
}
