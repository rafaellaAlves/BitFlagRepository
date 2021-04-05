using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoiceItemViewModel
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceItemServiceTypeId { get; set; }
        public string InvoiceItemServiceTypeName { get; set; }
        public bool InvoiceItemServiceTypeIsCredit { get; set; }
        public double Value { get; set; }
        public string _Value { get { return Value.ToPtBR(); } set { Value = (double)value.FromDoublePtBR(); } }
    }
}
