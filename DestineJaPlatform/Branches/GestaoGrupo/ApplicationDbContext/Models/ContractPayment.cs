using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ContractPayment
    {
        public int ContractPaymentId { get; set; }
        public int ContractId { get; set; }
        public DateTime DueDate { get; set; }
        public bool Payed { get; set; }
        public DateTime? PayedDate { get; set; }
        public double? Price { get; set; }
        public string Invoice { get; set; }
        public string InvoiceFileGuidName { get; set; }
        public string InvoiceFileName { get; set; }
        public string InvoiceMimeType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
