using DTO.Report;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.ViewComponents.Report.NewContractAndService
{
    [ViewComponent(Name = "Report\\NewContractAndService")]
    public class IndexViewComponent : ViewComponent
    {
        readonly ReportService reportService;

        public IndexViewComponent(ReportService reportService)
        {
            this.reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime startDate, DateTime endDate, string state, string city, bool loadFromController = false) => await Task.Run(async () => View("Index", new EntityViewMode<List<NewContractAndServiceViewModel>>(await reportService.GetNewContractAndService(startDate, endDate, state, city), loadFromController)));
    }
}
