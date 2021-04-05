using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator, Financial")]
    public class FinancialController : Controller
    {
        private readonly FUNCTIONS.Invoice.InvoiceFunctions invoiceFunctions;
        private readonly FUNCTIONS.Invoice.InvoicePaymentFunctions invoicePayment;
        private readonly FUNCTIONS.Job.JobFunctions jobFunctions;
        private readonly FUNCTIONS.Invoice.InvoicePaymentListFunctions invoicePaymentListFunctions;

        public FinancialController(FUNCTIONS.Invoice.InvoiceFunctions invoiceFunctions, FUNCTIONS.Job.JobFunctions jobFunctions, FUNCTIONS.Invoice.InvoicePaymentFunctions invoicePayment, FUNCTIONS.Invoice.InvoicePaymentListFunctions invoicePaymentListFunctions)
        {
            this.invoiceFunctions = invoiceFunctions;
            this.invoicePayment = invoicePayment;
            this.jobFunctions = jobFunctions;
            this.invoicePaymentListFunctions = invoicePaymentListFunctions;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(int invoiceId)
        {
            return View(invoiceId);
        }

        public IActionResult FinancialIndexViewComponent()
        {
            return ViewComponent(typeof(ViewComponents.Financial.FinancialIndexViewComponent));
        }

        public IActionResult FinancialManageViewComponent(int invoiceId)
        {
            return ViewComponent(typeof(ViewComponents.Financial.FinancialManageViewComponent), new { invoiceId });
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> _List(DTO.Shared.DataTablesAjaxPostModel filter, bool? processStatus)
        {
            string query = "InvoiceStatusId = 3";
            List<SqlParameter> param = new List<SqlParameter>();

            if (processStatus.HasValue)
            {
                query += " AND Started = @Started";
                param.Add(new SqlParameter("@Started", processStatus));
            }

            var data = this.invoiceFunctions.List(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()).AsEnumerable();

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));
        }

        [HttpPost]
        [ActionName("StartProcess")]
        public async Task<IActionResult> _StartProcess(int invoiceId)
        {
            if (jobFunctions.JobExistByInvoiceId(invoiceId))
            {
                return await Task.Run<IActionResult>(() => Json(new { hasError = true, message = "Esse processo já foi iniciado!" }));
            }
            invoiceFunctions.CreateNewJobFromInvoiceIfApproved(invoiceId);
            return await Task.Run<IActionResult>(() => Json(new { hasError = false, message = "Processo iniciado com sucesso!", invoiceId = invoiceId }));
        }

        [HttpPost]
        [ActionName("ListarParcelas")]
        public async Task<IActionResult> _ListarParcela(DTO.Shared.DataTablesAjaxPostModel filter, int invoiceId)
        {
            if (!invoiceFunctions.Exists(invoiceId)) return Forbid();

            SqlParameter[] param = new SqlParameter[1] { new SqlParameter("@InvoiceId", invoiceId) };
            var data = invoicePaymentListFunctions.GetDataViewModel(invoicePaymentListFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, "InvoiceId = @InvoiceId", param));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));

        }

        public IActionResult UpdateParcela(int parcelaId)
        {
            var data = invoicePayment.GetDataByID(parcelaId);
            if (data.Paid) return Json(false);

            invoicePayment.UpdateParcela(parcelaId);

            return Json(true);
        }
    }
}