using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Contract
{
    public class ContractPaymentViewModel
    {
        public int? ContractPaymentId { get; set; }
        public int ContractId { get; set; }
        public DateTime DueDate { get; set; }
        public string _DueDate { get; set; }
        public bool Payed { get; set; }
        public DateTime? PayedDate { get; set; }
        public string _PayedDate { get => PayedDate.ToBrazilianDateFormat(); set => PayedDate = value.FromBrazilianDateFormatNullable(); }
        public double? Price { get; set; }
        public string _Price { get => Price.ToPtBR(); set => Price = value.FromDoublePtBR(); }
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
