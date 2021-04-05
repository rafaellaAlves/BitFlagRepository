using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoicePaymentTypeViewModel
    {
        public int InvoicePaymentTypeId { get; set; }
        public string Name { get; set; }
        public int PaymentTimes { get; set; }
        public double? Taxes { get; set; }
        public string _Taxes { get { return Taxes.ToPtBR(); } }
        public string _TaxesABS { get { return Taxes == null ? "" : Math.Abs(Taxes.Value).ToPtBR(); } }
        public int Order { get; set; }
    }
}
