using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoiceListViewModel
    {
        public int InvoiceId { get; set; }
        public string InvoiceTerraNostraId
        {
            get
            {
                return !ExternalCode.HasValue ? "[SEM NÚMERO]" : $"{ExternalCode.Value}/{CreatedDate.Year.ToString("0000")}";
            }
        }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string StatusName { get; set; }
        public string InvoicePaymentWayName { get; set; }
        public int? InvoicePaymentTypeTimes { get; set; }
        public double? Cost { get; set; }
        public string _Cost { get { return Cost.ToPtBR(); } }
        public double? Tax { get; set; }
        public string _Tax { get { return Tax.ToPtBR(); } }
        public double? GrandTotal { get; set; }
        public string _GrandTotal { get { return GrandTotal.ToPtBR(); } }
        public int FreezedFamilyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return this.CreatedDate.ToDatePtBR(); } }
        public string _CreatedDateYear { get { return this.CreatedDate.Year.ToString(); } }
        public bool Started { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string _ApprovedDate { get { return this.ApprovedDate.ToDatePtBR(); } }
        public int? ExternalCode { get; set; }
    }
}
