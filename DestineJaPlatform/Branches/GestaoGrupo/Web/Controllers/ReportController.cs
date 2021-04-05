using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using DTO.Client.Report;
using DTO.Shared;
using DTO.Utils;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.Client;
using Services.Residue;
using Web.Helpers;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        ICompositeViewEngine viewEngine;

        public ReportController(ICompositeViewEngine viewEngine)
        {
            this.viewEngine = viewEngine;
        }

        #region [NewContractAndService]
        public async Task<IActionResult> NewContractAndService() => await Task.Run(() => View());
        public async Task<IActionResult> LoadNewContractAndServiceViewComponent(string startDate, string endDate, string state, string city) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.NewContractAndService.IndexViewComponent), new { startDate = startDate.FromBrazilianDateFormat(), endDate = endDate.FromBrazilianDateFormat(), state, city, loadFromController = true }));
        #endregion

        #region [NewAndEndedContracts]
        public async Task<IActionResult> NewAndEndedContracts() => await Task.Run(() => View());
        public async Task<IActionResult> LoadNewAndEndedContractsViewComponent(string startDate, string endDate) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.NewAndEndedContracts.IndexViewComponent), new { startDate = startDate.FromBrazilianDateFormat(), endDate = endDate.FromBrazilianDateFormat(), loadFromController = true }));
        public async Task<IActionResult> LoadNewEndedContractsDetailViewComponent(DateTime date) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.NewAndEndedContracts.DetailViewComponent), new { date, loadFromController = true }));
        #endregion

        #region [EndedContracts]
        public async Task<IActionResult> EndedContracts() => await Task.Run(() => View());
        public async Task<IActionResult> LoadEndedContractsViewComponent(string startDate, string endDate) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.EndedContracts.IndexViewComponent), new { startDate = startDate.FromBrazilianDateFormat(), endDate = endDate.FromBrazilianDateFormat(), loadFromController = true }));
        #endregion

        #region [Service]
        public async Task<IActionResult> Service() => await Task.Run(() => View());
        public async Task<IActionResult> LoadServiceViewComponent(string date) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.Service.IndexViewComponent), new { date = date.FromBrazilianDateFormat(), loadFromController = true }));
        #endregion

        #region [Route]
        public async Task<IActionResult> Route() => await Task.Run(() => View());
        public async Task<IActionResult> LoadRouteViewComponent(string startDate, string endDate, List<string> routeIds) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.Route.IndexViewComponent), new { startDate = startDate.FromBrazilianDateFormat(), endDate = endDate.FromBrazilianDateFormat(), routeIds = string.Join(",", routeIds), loadFromController = true }));
        #endregion

        #region [CollectionHistory]
        public async Task<IActionResult> CollectionHistory() => await Task.Run(() => View());
        public async Task<IActionResult> LoadCollectionHistoryViewComponent(string startDate, string endDate, int? clientId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.CollectionHistory.IndexViewComponent), new { startDate = startDate.FromBrazilianDateFormat(), endDate = endDate.FromBrazilianDateFormat(), clientId, loadFromController = true }));

        public async Task<IActionResult> CollectionHistoryPrint(List<FilterViewModel> filters, List<string> tableHeader, string startDateFormated, string endDateFormated, int? clientId, List<string> chartsBase64, string title, [FromServices] ClientReportServices clientReportServices, [FromServices] ClientServices clientServices)
        {
            List<ClientReportCollectionHistoryViewModel> data = new List<ClientReportCollectionHistoryViewModel>();
            if (User.IsInRole("Administrator"))
                data = await clientReportServices.GetClientReportCollectionHistoryViewModel(clientId, startDateFormated.FromBrazilianDateFormatNullable(), endDateFormated.FromBrazilianDateFormatNullable());
            else
                data = await clientReportServices.GetClientReportCollectionHistoryViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startDateFormated.FromBrazilianDateFormatNullable(), endDateFormated.FromBrazilianDateFormatNullable());

            return await Print(filters, tableHeader, data.OrderBy(x => x.VisitedDate).Select(x => new List<string> { x.DestineJaDemandId, x._VisitedDate, x.Visited == true ? "Sim" : "Não", x.Collected == true ? "Sim" : "Não", x.WeightFormated, x.NonCollectingReason.IfNullChange("-"), x.DriverName, x.ReceptorName.IfNullChange("-") }).ToList(), chartsBase64, title);
        }

        public async Task<IActionResult> CollectionHistoryDownload(List<FilterViewModel> filters, List<string> tableHeader, string startDateFormated, string endDateFormated, int? clientId, List<string> chartsBase64, string title, [FromServices] ClientReportServices clientReportServices, [FromServices] ClientServices clientServices)
        {
            List<ClientReportCollectionHistoryViewModel> data = new List<ClientReportCollectionHistoryViewModel>();
            if (User.IsInRole("Administrator"))
                data = await clientReportServices.GetClientReportCollectionHistoryViewModel(clientId, startDateFormated.FromBrazilianDateFormatNullable(), endDateFormated.FromBrazilianDateFormatNullable());
            else
                data = await clientReportServices.GetClientReportCollectionHistoryViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startDateFormated.FromBrazilianDateFormatNullable(), endDateFormated.FromBrazilianDateFormatNullable());

            return await Download(filters, tableHeader, data.OrderBy(x => x.VisitedDate).Select(x => new List<string> { x.DestineJaDemandId, x._VisitedDate, x.Visited == true ? "Sim" : "Não", x.Collected == true ? "Sim" : "Não", x.WeightFormated, x.NonCollectingReason.IfNullChange("-"), x.DriverName, x.ReceptorName.IfNullChange("-") }).ToList(), chartsBase64);
        }

        #endregion

        #region [CollectionMap]
        public async Task<IActionResult> CollectionMap() => await Task.Run(() => View());
        public async Task<IActionResult> LoadCollectionMapViewComponent(string startDate, string endDate, int? clientId, int? residueFamilyId, List<int> residueIds) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.CollectionMap.IndexViewComponent), new { startDate = startDate.FromBrazilianDateFormat(), endDate = endDate.FromBrazilianDateFormat(), residueFamilyId, residueIds, clientId, loadFromController = true }));
        #endregion

        #region [CollectionMapYear]
        public async Task<IActionResult> CollectionYearMap() => await Task.Run(() => View());
        public async Task<IActionResult> LoadCollectionYearMapViewComponent(int? startYear, int? endYear, int? clientId, int? residueFamilyId, List<int> residueIds) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.CollectionYearMap.IndexViewComponent), new { startYear, endYear, residueFamilyId, residueIds, clientId, loadFromController = true }));

        #endregion

        #region [CollectionMovement]
        public async Task<IActionResult> CollectionMovement() => await Task.Run(() => View());
        public async Task<IActionResult> LoadCollectionMovementViewComponent(DateTime? startDate, DateTime? endDate, int? clientId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.CollectionMovement.IndexViewComponent), new { startDate, endDate, clientId, loadFromController = true }));

        public async Task<IActionResult> CollectionMovementPrint(List<FilterViewModel> filters, string startDate, string endDate, int? clientId, [FromServices] ClientReportServices clientReportServices, [FromServices] ClientServices clientServices)
        {
            var model = new PrintListViewModel<ClientReportCollectionMovementViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>(),
                Items = await clientReportServices.GetClientReportCollectionMovementViewModel(User.IsClient()? await clientServices.GetClientIdByLoggedUser(HttpContext) : clientId, startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable())
            };

            return await Task.Run(() => View("~/Views/Report/Print/CollectionMovementPrint.cshtml", model));
        }

        public async Task<IActionResult> CollectionMovementDownload(List<FilterViewModel> filters, string startDate, string endDate, int? clientId, [FromServices] ClientReportServices clientReportServices, [FromServices] ClientServices clientServices, [FromServices] ViewEngineHelper viewEngineHelper)
        {
            var model = new PrintListViewModel<ClientReportCollectionMovementViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>(),
                Items = await clientReportServices.GetClientReportCollectionMovementViewModel(User.IsClient() ? await clientServices.GetClientIdByLoggedUser(HttpContext) : clientId, startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable())
            };

            var stream = new MemoryStream();
            ViewData["PDF"] = true;
            var htmlPdf = await viewEngineHelper.RenderPartialViewToString(ControllerContext, ViewData, TempData, "Print/CollectionMovementPrint", model);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "Movimentação de Coleta.pdf"));
        }
        #endregion

        #region[Generator]
        public async Task<IActionResult> LoadPGRSViewComponent(DateTime? startDate, DateTime? endDate, int? unitOfMeasurementId, int? clientId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.PGRS.IndexViewComponent), new { startDate, endDate, clientId, unitOfMeasurementId, loadFromController = true }));

        public async Task<IActionResult> LoadGeneratorViewComponent(DateTime? startDate, DateTime? endDate, string search) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Report.Generator.IndexViewComponent), new { startDate, endDate, search, loadFromController = true }));

        public async Task<IActionResult> GeneratorPrint(List<FilterViewModel> filters, string startDate, string endDate, string search,[FromServices] ClientReportServices clientReportServices)
        {
            var model = new PrintListViewModel<ClientReportGeneratorViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>(),
                Items = await clientReportServices.GetClientReportGeneratorViewModel(startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable(), search)
            };

            return await Task.Run(() => View("~/Views/Report/Print/GeneratorPrint.cshtml", model));
        }

        public async Task<IActionResult> GeneratorDownload(List<FilterViewModel> filters, string startDate, string endDate, string search, [FromServices] ClientReportServices clientReportServices, [FromServices] ViewEngineHelper viewEngineHelper)
        {
            var model = new PrintListViewModel<ClientReportGeneratorViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>(),
                Items = await clientReportServices.GetClientReportGeneratorViewModel(startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable(), search)
            };

            var stream = new MemoryStream();
            ViewData["PDF"] = true;
            var htmlPdf = await viewEngineHelper.RenderPartialViewToString(ControllerContext, ViewData, TempData, "Print/GeneratorPrint", model);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "Generator.pdf"));
        }
        #endregion


        #region [PGRS]
        public async Task<IActionResult> PGRS() => await Task.Run(() => View());
     
        public async Task<IActionResult> PGRSPrint(List<FilterViewModel> filters, string startDate, string endDate, int? unitOfMeasurementId, int? clientId, [FromServices] ClientReportServices clientReportServices, [FromServices] ClientServices clientServices)
        {
            var model = new PrintListViewModel<ClientReportPGRSViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>(),
                Items = await clientReportServices.GetClientReportPGRSViewModel(User.IsClient() ? await clientServices.GetClientIdByLoggedUser(HttpContext) : clientId, startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable(), unitOfMeasurementId)
            };

            return await Task.Run(() => View("~/Views/Report/Print/PGRSPrint.cshtml", model));
        }

        public async Task<IActionResult> PGRSDownload(List<FilterViewModel> filters, string startDate, string endDate, int? unitOfMeasurementId, int? clientId, [FromServices] ClientReportServices clientReportServices, [FromServices] ClientServices clientServices, [FromServices] ViewEngineHelper viewEngineHelper)
        {
            var model = new PrintListViewModel<ClientReportPGRSViewModel>
            {
                Filters = filters ?? new List<FilterViewModel>(),
                Items = await clientReportServices.GetClientReportPGRSViewModel(User.IsClient() ? await clientServices.GetClientIdByLoggedUser(HttpContext) : clientId, startDate.FromBrazilianDateFormatNullable(), endDate.FromBrazilianDateFormatNullable(), unitOfMeasurementId)
            };

            var stream = new MemoryStream();
            ViewData["PDF"] = true;
            var htmlPdf = await viewEngineHelper.RenderPartialViewToString(ControllerContext, ViewData, TempData, "Print/PGRSPrint", model);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "PGRS.pdf"));
        }
        #endregion

        #region [FILTER]
        public async Task<IActionResult> GetClientReportAvailableResidueFamilies(int? clientId, [FromServices] ClientReportServices clientReportServices, [FromServices] ResidueFamilyServices residueFamilyServices) => await Task.Run(async () => Json(clientId.HasValue? await clientReportServices.GetClientReportAvailableResidueFamilies(clientId.Value) : await residueFamilyServices.GetViewModelAsNoTrackingAsync(x => !x.IsDeleted)));
        #endregion

        public async Task<IActionResult> Print(List<FilterViewModel> filters, List<string> tableHeader, List<List<string>> tableData, List<string> chartsBase64, string title)
        {
            var model = new ReportPrintViewModel
            {
                Filters = filters ?? new List<FilterViewModel>(),
                TableHeaders = tableHeader,
                TableData = tableData,
                ChartsBase64 = chartsBase64,
                Title = title
            };

            return await Task.Run(() => View("~/Views/Report/Print/Print.cshtml", model));
        }

        public async Task<IActionResult> Download(List<FilterViewModel> filters, List<string> tableHeader, List<List<string>> tableData, List<string> chartsBase64)
        {
            var model = new ReportPrintViewModel
            {
                Filters = filters ?? new List<FilterViewModel>(),
                TableHeaders = tableHeader,
                TableData = tableData,
                ChartsBase64 = chartsBase64
            };

            var stream = new MemoryStream();
            ViewData["PDF"] = true;
            var htmlPdf = await RenderPartialViewToString("Print/Print", model);

            PdfDocument pdfDocument = new PdfDocument(new PdfWriter(stream));
            pdfDocument.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
            HtmlConverter.ConvertToPdf(htmlPdf, pdfDocument, new ConverterProperties());

            return await Task.Run(() => File(stream.ToArray(), MediaTypeNames.Application.Octet, "Relatório.pdf"));
        }

        public async Task<string> RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult = viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, writer, new HtmlHelperOptions());

                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
        #region [FILTER]
        public async Task<IActionResult> Generator() => await Task.Run(() => View());

        #endregion
    }
}
