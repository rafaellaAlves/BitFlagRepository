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
    public class DetailViewComponent : ViewComponent
    {
        readonly ReportService reportService;

        public DetailViewComponent(ReportService reportService)
        {
            this.reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime date, bool loadFromController = false) => await Task.Run(async () => View("Detail", new EntityViewMode<NewAndEndedContractDetailViewModel>(await reportService.GetNewAndEndedContractDetails(date), loadFromController)));
    }
}
