using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoiceServicePayment
    {
        public int InvoiceServicePaymentId { get; set; }
        public int InvoicePaymentTypeId { get; set; }
        public int InvoiceServiceTypeId { get; set; }
    }
}
