using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoicePaymentListViewModel
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int InvoicePaymentId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InstallmentDate { get; set; }
        public string _InstallmentDate { get { return InstallmentDate.ToDatePtBR(); } set { InstallmentDate = (DateTime)value.FromDatePtBR(); } }
        public double Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } set { Price = (double)value.FromDoublePtBR(); } }
        public bool Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string _PaymentDate { get { return PaymentDate.ToDatePtBR(); } set { PaymentDate = (DateTime)value.FromDatePtBR(); } }
        public int PaymentNumber { get; set; }
    }
}
