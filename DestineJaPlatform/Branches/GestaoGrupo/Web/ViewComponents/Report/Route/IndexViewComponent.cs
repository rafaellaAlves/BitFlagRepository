using DTO.Report;
using DTO.Report.Route;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.ViewComponents.Report.Route
{
    [ViewComponent(Name = "Report\\Route")]
    public class IndexViewComponent : ViewComponent
    {
        readonly ReportService reportService;

        public IndexViewComponent(ReportService reportService)
        {
            this.reportService = reportService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime startDate, DateTime endDate, string routeIds, bool loadFromController = false)
        {
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;

            return await Task.Run(async () => View("Index", new EntityViewMode<RouteReportViewModel>(await reportService.GetRoutes(startDate, endDate, routeIds), loadFromController)));
        }
    }
}
