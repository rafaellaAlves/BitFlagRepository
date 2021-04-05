using DTO.Report;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.NewAndEndedContracts
{
    [ViewComponent(Name = "Report\\NewAndEndedContracts")]
    public class IndexViewComponent : ViewComponent
    {
        readonly ReportService reportService;

        public IndexViewComponent(ReportService reportService)
        {
            this.reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime startDate, DateTime endDate, bool loadFromController = false) => await Task.Run(async () => View("Index", new EntityViewMode<List<NewAndEndedContractViewModel>>(await reportService.GetNewAndEndedContracts(startDate, endDate), loadFromController)));
    }
}
