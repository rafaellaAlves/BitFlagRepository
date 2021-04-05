using DTO.Invoice;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Invoice
{
    public class InvoicePaymentTypeFunctions
    {
        private readonly DB.TerraNostraContext context;
        
        public InvoicePaymentTypeFunctions(DB.TerraNostraContext context)
        {
            this.context = context;
        }

        public List<DB.InvoicePaymentType> GetPaymentTypeByInvoiceServiceType(int invoiceServiceTypeId)
        {
            return (from y in context.InvoicePaymentType
                    join x in context.InvoiceServicePayment on y.InvoicePaymentTypeId equals x.InvoicePaymentTypeId
                    where x.InvoiceServiceTypeId == invoiceServiceTypeId
                    orderby y.Order
                    select y).ToList();
        }

        public DB.InvoicePaymentType GetInvoicePaymentTypeById(int invoicePaymentTypeId)
        {
            return context.InvoicePaymentType.SingleOrDefault(x => x.InvoicePaymentTypeId == invoicePaymentTypeId);
        }

        public List<DTO.Invoice.InvoicePaymentTypeViewModel> GetInvoicePaymentTypeViewModel(List<DB.InvoicePaymentType> invoicePaymentTypes)
        {
            return invoicePaymentTypes.Select(x => new DTO.Invoice.InvoicePaymentTypeViewModel {
                InvoicePaymentTypeId = x.InvoicePaymentTypeId,
                Name = x.Name,
                Order = x.Order,
                PaymentTimes = x.PaymentTimes,
                Taxes = x.Taxes
            }).ToList();
        }

        public DTO.Invoice.InvoicePaymentTypeViewModel GetInvoicePaymentTypeViewModel(DB.InvoicePaymentType invoicePaymentType)
        {
            return new DTO.Invoice.InvoicePaymentTypeViewModel
            {
                InvoicePaymentTypeId = invoicePaymentType.InvoicePaymentTypeId,
                Name = invoicePaymentType.Name,
                Order = invoicePaymentType.Order,
                PaymentTimes = invoicePaymentType.PaymentTimes,
                Taxes = invoicePaymentType.Taxes
            };
        }

        public List<InstallmentViewModel> GetInvoicePaymentTypeInstallment(double price, int invoicePaymentTypeId, int installmentDay)
        {
            var invoicePaymentType = GetInvoicePaymentTypeById(invoicePaymentTypeId);
            if (invoicePaymentType == null || (invoicePaymentType != null && invoicePaymentType.PaymentTimes == 0)) return null;

            List<InstallmentViewModel> payments = new List<InstallmentViewModel>();
            var today = DateTime.Now;

            //var valorTotal = ;

            // Opção de parcelamento em 3x           
            if (invoicePaymentType.PaymentTimes == 3)
                return ParcelamentoEspecificoTresVezes(price, installmentDay);

            // > 3x, utilizar entrada de 20%
            double entrada = CalculoEntrada(price, 20.0d);
            payments.Add(new InstallmentViewModel(entrada, new DateTime(today.Year, today.Month, installmentDay)));

            var pricePerMonth = ((price - entrada) / (invoicePaymentType.PaymentTimes - 1));
            for (int i = 1; i <= invoicePaymentType.PaymentTimes - 1; i++)
            {
                var date = today.AddMonths(i);
                int day = DateTime.DaysInMonth(date.Year, date.Month) < installmentDay ? DateTime.DaysInMonth(date.Year, date.Month) : installmentDay;

                payments.Add(new InstallmentViewModel(pricePerMonth, new DateTime(date.Year, date.Month, day)));
            }

            return payments;
        }

        // Opção de parcelamento em 3x
        private List<InstallmentViewModel> ParcelamentoEspecificoTresVezes(double price, int installmentDay)
        {
            double parcela1 = (price / 100d) * 37.5;
            double parcela2 = (price / 100d) * 37.5;
            double parcela3 = (price / 100d) * 25.0;
            var date = DateTime.Now;
            DateTime data1 = new DateTime(date.Year, date.Month, installmentDay);
            DateTime data2 = data1.AddMonths(1);
            DateTime data3 = data2.AddMonths(1);


            return new List<InstallmentViewModel> {
                new InstallmentViewModel(parcela1, data1),
                new InstallmentViewModel(parcela2, data2),
                new InstallmentViewModel(parcela3, data3)
            };
        }

        // Opção de parcelamento a prazo entrada 20%
        private double CalculoEntrada(double price, double percent)
        {
            return (price / 100d) * percent;
        }
    }
}
