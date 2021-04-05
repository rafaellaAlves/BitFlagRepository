using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoicePayment
    {
        public int InvoicePaymentId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InstallmentDate { get; set; }
        public double Price { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
