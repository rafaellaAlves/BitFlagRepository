using DTO.Report;
using DTO.Service;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.Service
{
    [ViewComponent(Name = "Report\\Service")]
    public class IndexViewComponent : ViewComponent
    {
        readonly ReportService reportService;

        public IndexViewComponent(ReportService reportService)
        {
            this.reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime date, bool loadFromController = false) => await Task.Run(async () => View("Index", new EntityViewMode<List<ServiceListViewModel>>(await reportService.GetServices(date), loadFromController)));
    }
}
