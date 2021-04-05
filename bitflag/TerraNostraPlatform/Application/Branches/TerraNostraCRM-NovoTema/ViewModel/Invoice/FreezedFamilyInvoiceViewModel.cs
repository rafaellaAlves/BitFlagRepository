using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class FreezedFamilyInvoiceViewModel
    {
        public int FreezedFamilyId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDateTimePtBR(); } }
        public int CreatedBy { get; set; }
        public string _CreatedBy { get; set; }
        public bool? Accepted { get; set; }
        public int? AcceptedBy { get; set; }
        public string _AcceptedBy { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public string _AcceptedDate { get { return AcceptedDate.ToDateTimePtBR(); } }
        public List<FreezedFamilyInvoiceItemViewModel> FreezedFamilyItemViewModel { get; set; }
        public List<InvoiceItemViewModel> InvoiceItemViewModel { get; set; }
        public List<InvoicePaymentViewModel> InvoicePaymentViewModel { get; set; }

        public FreezedFamilyInvoiceViewModel()
        {
            FreezedFamilyItemViewModel = new List<FreezedFamilyInvoiceItemViewModel>();
            InvoiceItemViewModel = new List<InvoiceItemViewModel>();
            InvoicePaymentViewModel = new List<InvoicePaymentViewModel>();
        }
    }
}
