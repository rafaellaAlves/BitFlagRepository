using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoiceItemServiceTypeViewModel
    {
        public int InvoiceItemServiceTypeId { get; set; }
        public string Name { get; set; }
        public bool IsCredit { get; set; }
        public double Value { get; set; }
        public string _Value { get { return Value.ToPtBR(); } }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}
