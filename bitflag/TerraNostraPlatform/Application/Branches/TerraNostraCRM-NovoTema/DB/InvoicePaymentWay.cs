using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoicePaymentWay
    {
        public int InvoicePaymentWayId { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
