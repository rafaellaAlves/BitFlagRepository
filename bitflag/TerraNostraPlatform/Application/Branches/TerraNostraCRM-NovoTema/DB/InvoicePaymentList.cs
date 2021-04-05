using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB
{
    public class InvoicePaymentList
    {
        [Key]
        public int InvoicePaymentId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InstallmentDate { get; set; }
        public double Price { get; set; }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int PaymentNumber { get; set; }
    }
}
