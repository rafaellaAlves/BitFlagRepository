using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DTO.Utils;
using System.Data.SqlClient;
using Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator, Salesman, Financial, Administrative, Administrative Assistant")]
    public class InvoiceController : Controller
    {
        private FUNCTIONS.Client.ClientFunctions clientFunctions;
        private FUNCTIONS.Invoice.InvoiceFunctions invoiceFunctions;
        private FUNCTIONS.Invoice.InvoiceFreezedFamilyItemFunctions invoiceFreezedFamilyItemFunctions;
        private FUNCTIONS.Invoice.InvoiceItemFunctions invoiceItemFunctions;
        private FUNCTIONS.Invoice.InvoicePaymentTypeFunctions invoicePaymentTypeFunctions;
        private FUNCTIONS.Invoice.InvoicePaymentFunctions invoicePaymentFunctions;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;
        public InvoiceController(FUNCTIONS.Invoice.InvoiceFunctions invoiceFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager, FUNCTIONS.Invoice.InvoiceFreezedFamilyItemFunctions invoiceFreezedFamilyItemFunctions, FUNCTIONS.Invoice.InvoiceItemFunctions invoiceItemFunctions, FUNCTIONS.Invoice.InvoicePaymentTypeFunctions invoicePaymentTypeFunctions, FUNCTIONS.Invoice.InvoicePaymentFunctions invoicePaymentFunctions, FUNCTIONS.Client.ClientFunctions clientFunctions)
        {
            this.invoiceFunctions = invoiceFunctions;
            this.userManager = userManager;
            this.invoiceFreezedFamilyItemFunctions = invoiceFreezedFamilyItemFunctions;
            this.invoiceItemFunctions = invoiceItemFunctions;
            this.invoicePaymentTypeFunctions = invoicePaymentTypeFunctions;
            this.invoicePaymentFunctions = invoicePaymentFunctions;
            this.clientFunctions = clientFunctions;
        }

        public IActionResult Index(int? invoiceStatusId)
        {
            return View(invoiceStatusId);
        }

        public IActionResult Manage(int? invoiceId)
        {
            return View(invoiceId);
        }

        public IActionResult Payment()
        {
            return View();
        }

        #region [ViewComponent]
        public IActionResult InvoiceIndexViewComponent(int? invoiceStatusId)
        {
            return ViewComponent(typeof(ViewComponents.Invoice.InvoiceIndexViewComponent), new { invoiceStatusId });
        }
        public IActionResult InvoiceManageViewComponent(int? invoiceId)
        {
            return ViewComponent(typeof(ViewComponents.Invoice.InvoiceManageViewComponent), new { invoiceId });
        }
        public IActionResult InvoicePaymentViewComponent()
        {
            return ViewComponent(typeof(ViewComponents.Invoice.InvoicePaymentViewComponent));
        }
        #endregion

        #region [XHR]
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> _List(DTO.Shared.DataTablesAjaxPostModel filter, int? invoiceStatusFilter)
        {
            string query = "1 = 1";
            List<SqlParameter> param = new List<SqlParameter>();

            if (invoiceStatusFilter.HasValue)
            {
                query += " AND InvoiceStatusId = @InvoiceStatusId";
                param.Add(new SqlParameter("@InvoiceStatusId", invoiceStatusFilter.Value));
            }

            if (User.IsInRole("Salesman"))
            {
                var userId = User.GetUserId();
                query += " AND ResponsibleId = @ResponsibleId";
                param.Add(new SqlParameter("@ResponsibleId", userId.Value));
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
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(DTO.Invoice.InvoiceViewModel invoice, List<DB.InvoiceFreezedFamilyItem> invoiceFreezedFamilyItems, List<DTO.Invoice.InvoiceItemViewModel> invoiceItems, List<DTO.Invoice.InvoicePaymentViewModel> invoicePayments)
        {
            if (!User.InvoiceCanAccessEdition()) return Forbid();

            if (invoice.InvoiceId.HasValue && invoiceFunctions.IsLocked(invoice.InvoiceId.Value))
                return await Task.Run<IActionResult>(() => Json(new { hasError = true, message = "Orçamento bloqueado!" }));

            var user = await userManager.GetUserAsync(User);

            invoice.CreatedBy = user.Id;
            invoice.AlteredBy = user.Id;

            var invoiceId = invoiceFunctions.CreateOrUpdate(invoice);

            invoiceFreezedFamilyItems.ForEach(x => x.InvoiceId = invoiceId);

            invoiceFreezedFamilyItemFunctions.DeleteByInvoiceId(invoiceId);
            invoiceFreezedFamilyItemFunctions.Create(invoiceFreezedFamilyItems);

            invoiceItems.ForEach(x => x.InvoiceId = invoiceId);

            invoiceItemFunctions.DeleteInvoiceItemByInvoiceId(invoiceId);
            invoiceItemFunctions.CreateInvoiceItem(invoiceItems);

            invoicePaymentFunctions.DeleteByInvoiceId(invoiceId);

            if (invoicePayments.Count > 0)
            {
                invoicePayments.ForEach(x => x.InvoiceId = invoiceId);
                invoicePaymentFunctions.Create(invoicePayments);
            }

            invoiceFunctions.UpdateValues(invoiceId, out double grandTotal);
            if (invoiceFunctions.ShouldLock(invoice.InvoiceStatusId))
            {
                invoiceFunctions.Lock(invoiceId);
                //invoiceFunctions.CreateNewJobFromInvoiceIfApproved(invoiceId);
            }

            if (invoicePayments.Count == 0) // caso não haja parcelas(seja a vísta) é criada uma parcela para o dia atual, para ser listada na tela de finanças
            {
                invoicePaymentFunctions.Create(new DTO.Invoice.InvoicePaymentViewModel
                {
                    InstallmentDate = DateTime.Now,
                    InvoiceId = invoiceId,
                    Price = grandTotal
                });
            }

            return await Task.Run<IActionResult>(() => Json(new { hasError = false, message = "Orçamento salvo com sucesso!", invoiceId = invoiceId }));
        }

        public IActionResult GetPaymentTypeByInvoiceServiceType(int invoiceServiceTypeId)
        {
            return Json(invoicePaymentTypeFunctions.GetInvoicePaymentTypeViewModel(invoicePaymentTypeFunctions.GetPaymentTypeByInvoiceServiceType(invoiceServiceTypeId)));
        }

        public IActionResult GetInvoicePaymentTypePrice(string price, int invoicePaymentTypeId, string installmentDay)
        {
            var _price = price.FromDoublePtBR().Value;

            return Json(invoicePaymentTypeFunctions.GetInvoicePaymentTypeInstallment(_price, invoicePaymentTypeId, int.Parse(installmentDay)));
        }

        // Parcelamento 4x Diffida

        private List<DTO.Invoice.InstallmentViewModel> ParcelamentoEspecificoQuatroVezesDiffida(int installmentDay, double valorTotalComTaxa, double valorDocComTaxa, double valorAberturaProcessoComTaxa, double custoProcuracaoItaliana)
        {

            double parcela1 = valorDocComTaxa;
            double parcela2 = (valorAberturaProcessoComTaxa / 4);
            double parcela3 = (valorAberturaProcessoComTaxa / 4);
            double parcela4 = valorTotalComTaxa - (parcela1 + parcela2 + parcela3);
            var date = DateTime.Now;
            DateTime data1 = new DateTime(date.Year, date.Month, installmentDay);
            DateTime data2 = data1.AddMonths(1);
            DateTime data3 = data2.AddMonths(1);
            DateTime data4 = data3.AddMonths(12);


            return new List<DTO.Invoice.InstallmentViewModel> {
                new DTO.Invoice.InstallmentViewModel (parcela1, data1),
                new DTO.Invoice.InstallmentViewModel (parcela2, data2),
                new DTO.Invoice.InstallmentViewModel (parcela3, data3),
                new DTO.Invoice.InstallmentViewModel (parcela4, data4)
            };
        }

        private List<DTO.Invoice.InstallmentViewModel> ParcelamentoEspecificoSeisVezesDiffida(int installmentDay, double valorTotalComTaxa)
        {

            double parcela1 = valorTotalComTaxa / 100 * 25;
            double parcela2 = valorTotalComTaxa / 100 * 10;
            double parcela3 = valorTotalComTaxa / 100 * 10;
            double parcela4 = valorTotalComTaxa / 100 * 10;
            double parcela5 = valorTotalComTaxa / 100 * 40;
            double parcela6 = valorTotalComTaxa / 100 * 5;
            var date = DateTime.Now;
            DateTime data1 = new DateTime(date.Year, date.Month, installmentDay);
            DateTime data2 = data1.AddMonths(1);
            DateTime data3 = data2.AddMonths(1);
            DateTime data4 = data3.AddMonths(1);
            DateTime data5 = data4.AddMonths(1);
            DateTime data6 = data5.AddMonths(1);

            return new List<DTO.Invoice.InstallmentViewModel> {
                new DTO.Invoice.InstallmentViewModel (parcela1, data1),
                new DTO.Invoice.InstallmentViewModel (parcela2, data2),
                new DTO.Invoice.InstallmentViewModel (parcela3, data3),
                new DTO.Invoice.InstallmentViewModel (parcela4, data4),
                new DTO.Invoice.InstallmentViewModel (parcela5, data5, false),
                new DTO.Invoice.InstallmentViewModel (parcela6, data6, false)
            };
        }

        private List<DTO.Invoice.InstallmentViewModel> ParcelamentoEspecificoSeteVezesDiffida(int installmentDay, double valorDocumentacaoSemTaxa, int aberturaProcessoSemTaxa, double cotacaoEuro, double valorTotalComTaxa, double valorInscricaoNoAire, double custoProcuracaoItaliana)
        {

            double parcela1 = valorDocumentacaoSemTaxa + custoProcuracaoItaliana;
            double aberturaProcesso = aberturaProcessoSemTaxa * cotacaoEuro;
            double parcela2 = (aberturaProcesso / 2) / 4;
            double parcela3 = (aberturaProcesso / 2) / 4;
            double parcela4 = (aberturaProcesso / 2) / 4;
            double parcela5 = (aberturaProcesso / 2) / 4;
            double parcela7 = valorInscricaoNoAire;
            double parcela6 = valorTotalComTaxa - (parcela1 + parcela2 + parcela3 + parcela4 + parcela5 + parcela7);
            var date = DateTime.Now;
            DateTime data1 = new DateTime(date.Year, date.Month, installmentDay);
            DateTime data2 = data1.AddMonths(1);
            DateTime data3 = data2.AddMonths(1);
            DateTime data4 = data3.AddMonths(1);
            DateTime data5 = data4.AddMonths(1);
            DateTime data6 = data5.AddMonths(1);
            DateTime data7 = data6.AddMonths(1);

            return new List<DTO.Invoice.InstallmentViewModel>
            {
                new DTO.Invoice.InstallmentViewModel (parcela1, data1),
                new DTO.Invoice.InstallmentViewModel (parcela2, data2),
                new DTO.Invoice.InstallmentViewModel (parcela3, data3),
                new DTO.Invoice.InstallmentViewModel (parcela4, data4),
                new DTO.Invoice.InstallmentViewModel (parcela5, data5),
                new DTO.Invoice.InstallmentViewModel (parcela6, data6),
                new DTO.Invoice.InstallmentViewModel (parcela7, data7),
            };
        }
        private List<DTO.Invoice.InstallmentViewModel> ParcelamentoEspecificoVinteEQuatroVezesDiffida(int installmentDay, double valorTotalComTaxa)
        {
            double parcela1 = valorTotalComTaxa / 100 * 20;
            double valorParcelas = valorTotalComTaxa - parcela1;
            double parcela2 = valorParcelas / 23;
            double parcela3 = valorParcelas / 23;
            double parcela4 = valorParcelas / 23;
            double parcela5 = valorParcelas / 23;
            double parcela6 = valorParcelas / 23;
            double parcela7 = valorParcelas / 23;
            double parcela8 = valorParcelas / 23;
            double parcela9 = valorParcelas / 23;
            double parcela10 = valorParcelas / 23;
            double parcela11 = valorParcelas / 23;
            double parcela12 = valorParcelas / 23;
            double parcela13 = valorParcelas / 23;
            double parcela14 = valorParcelas / 23;
            double parcela15 = valorParcelas / 23;
            double parcela16 = valorParcelas / 23;
            double parcela17 = valorParcelas / 23;
            double parcela18 = valorParcelas / 23;
            double parcela19 = valorParcelas / 23;
            double parcela20 = valorParcelas / 23;
            double parcela21 = valorParcelas / 23;
            double parcela22 = valorParcelas / 23;
            double parcela23 = valorParcelas / 23;
            double parcela24 = valorParcelas / 23;
            var date = DateTime.Now;
            DateTime data1 = new DateTime(date.Year, date.Month, installmentDay);
            DateTime data2 = data1.AddMonths(1);
            DateTime data3 = data2.AddMonths(1);
            DateTime data4 = data3.AddMonths(1);
            DateTime data5 = data4.AddMonths(1);
            DateTime data6 = data5.AddMonths(1);
            DateTime data7 = data6.AddMonths(1);
            DateTime data8 = data7.AddMonths(1);
            DateTime data9 = data8.AddMonths(1);
            DateTime data10 = data9.AddMonths(1);
            DateTime data11 = data10.AddMonths(1);
            DateTime data12 = data11.AddMonths(1);
            DateTime data13 = data12.AddMonths(1);
            DateTime data14 = data13.AddMonths(1);
            DateTime data15 = data14.AddMonths(1);
            DateTime data16 = data15.AddMonths(1);
            DateTime data17 = data16.AddMonths(1);
            DateTime data18 = data17.AddMonths(1);
            DateTime data19 = data18.AddMonths(1);
            DateTime data20 = data19.AddMonths(1);
            DateTime data21 = data20.AddMonths(1);
            DateTime data22 = data21.AddMonths(1);
            DateTime data23 = data22.AddMonths(1);
            DateTime data24 = data23.AddMonths(1);

            return new List<DTO.Invoice.InstallmentViewModel>
            {
                new DTO.Invoice.InstallmentViewModel (parcela1, data1),
                new DTO.Invoice.InstallmentViewModel (parcela2, data2),
                new DTO.Invoice.InstallmentViewModel (parcela3, data3),
                new DTO.Invoice.InstallmentViewModel (parcela4, data4),
                new DTO.Invoice.InstallmentViewModel (parcela5, data5),
                new DTO.Invoice.InstallmentViewModel (parcela6, data6),
                new DTO.Invoice.InstallmentViewModel (parcela7, data7),
                new DTO.Invoice.InstallmentViewModel (parcela8, data8),
                new DTO.Invoice.InstallmentViewModel (parcela9, data9),
                new DTO.Invoice.InstallmentViewModel (parcela10, data10),
                new DTO.Invoice.InstallmentViewModel (parcela11, data11),
                new DTO.Invoice.InstallmentViewModel (parcela12, data12),
                new DTO.Invoice.InstallmentViewModel (parcela13, data13),
                new DTO.Invoice.InstallmentViewModel (parcela14, data14),
                new DTO.Invoice.InstallmentViewModel (parcela15, data15),
                new DTO.Invoice.InstallmentViewModel (parcela16, data16),
                new DTO.Invoice.InstallmentViewModel (parcela17, data17),
                new DTO.Invoice.InstallmentViewModel (parcela18, data18),
                new DTO.Invoice.InstallmentViewModel (parcela19, data19),
                new DTO.Invoice.InstallmentViewModel (parcela20, data20),
                new DTO.Invoice.InstallmentViewModel (parcela21, data21),
                new DTO.Invoice.InstallmentViewModel (parcela22, data22),
                new DTO.Invoice.InstallmentViewModel (parcela23, data23),
                new DTO.Invoice.InstallmentViewModel (parcela24, data24),
            };
        }



        public IActionResult GetInvoicePaymentTypePriceDiffida(int installmentDay, double valorTotalComTaxa, double valorDocComTaxa, double valorAberturaProcessoComTaxa, int qtdparcelas, double valorDocumentacaoSemTaxa, int aberturaProcessoSemTaxa, double cotacaoEuro, int valorInscricaoNoAire, double custoProcuracaoItaliana, bool visible)
        {
            if (qtdparcelas == 4)
            {
                return Json(ParcelamentoEspecificoQuatroVezesDiffida(installmentDay, valorTotalComTaxa, valorDocComTaxa, valorAberturaProcessoComTaxa, custoProcuracaoItaliana));
            }
            else if (qtdparcelas == 6)
            {
                return Json(ParcelamentoEspecificoSeisVezesDiffida(installmentDay, valorTotalComTaxa));
            }
            else if (qtdparcelas == 7)
            {
                return Json(ParcelamentoEspecificoSeteVezesDiffida(installmentDay, valorDocumentacaoSemTaxa, aberturaProcessoSemTaxa, cotacaoEuro, valorTotalComTaxa, valorInscricaoNoAire, custoProcuracaoItaliana));
            }
            else if (qtdparcelas == 24)
            {
                return Json(ParcelamentoEspecificoVinteEQuatroVezesDiffida(installmentDay, valorTotalComTaxa));
            }
            else
            {
                return Json(null);
            }


        }

        //public IActionResult GetInvoicePaymentTypeSevenTimesDiffida(int installmentDay, double valorDocumentacao, int aberturaProcesso,
        //double cotacaoEuro, double valorTotal, int valorInscricaoNoAire)
        // {
        //  return Json(ParcelamentoEspecificoSeteVezesDiffida( installmentDay, valorDocumentacao, aberturaProcesso, cotacaoEuro, valorTotal, valorInscricaoNoAire));
        //  }

        public async Task<IActionResult> ListPayment(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            var data = this.invoicePaymentFunctions.List(filter, out int recordsTotal, out int recordsFiltered, "", null).AsEnumerable();
            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal,
                recordsFiltered,
                data
            }));
        }
        #endregion

        public IActionResult Print(DTO.Invoice.InvoiceViewModel invoice, List<DTO.Invoice.InvoiceFreezedFamilyItemViewModel> invoiceFreezedFamilyItems, List<DTO.Invoice.InvoiceItemViewModel> invoiceItems, List<DTO.Invoice.InvoicePaymentViewModel> invoicePayments, List<DTO.Invoice.InstallmentViewModel> installments)
        {
            var client = clientFunctions.GetDataViewModel(clientFunctions.GetDataByID(invoice.ClientId));

            return View(new DTO.Invoice.InvoicePrintViewModel(client, invoice, invoiceFreezedFamilyItems, invoiceItems, invoicePayments, installments));
        }


    }
}