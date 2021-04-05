using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoicePaymentType
    {
        public int InvoicePaymentTypeId { get; set; }
        public string Name { get; set; }
        public int PaymentTimes { get; set; }
        public double? Taxes { get; set; }
        public int Order { get; set; }
    }
}
