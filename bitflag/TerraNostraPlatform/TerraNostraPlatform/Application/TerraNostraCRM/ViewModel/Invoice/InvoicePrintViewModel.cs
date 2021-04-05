using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Invoice
{
    public class InvoicePrintViewModel
    {
        
        public DTO.Client.ClientViewModel Client { get; set; }
        public DTO.Invoice.InvoiceViewModel Invoice { get; set; }
        public List<InvoiceFreezedFamilyItemViewModel> InvoiceFreezedFamilyItems { get; set; }
        public List<DTO.Invoice.InvoiceItemViewModel> InvoiceItems { get; set; }
        public List<DTO.Invoice.InvoicePaymentViewModel> InvoicePayments { get; set; }
        public List<DTO.Invoice.InstallmentViewModel> Installments { get; set; }

        public InvoicePrintViewModel()
        {
            this.Client = new Client.ClientViewModel();
            this.Invoice = new InvoiceViewModel();
            this.InvoiceFreezedFamilyItems = new List<InvoiceFreezedFamilyItemViewModel>();
            this.InvoiceItems = new List<InvoiceItemViewModel>();
            this.InvoicePayments = new List<InvoicePaymentViewModel>();
            this.Installments = new List<DTO.Invoice.InstallmentViewModel>();
        }


        public InvoicePrintViewModel(Client.ClientViewModel client, InvoiceViewModel invoice, List<InvoiceFreezedFamilyItemViewModel> invoiceFreezedFamilyItems, List<InvoiceItemViewModel> invoiceItems, List<InvoicePaymentViewModel> invoicePayments, List<DTO.Invoice.InstallmentViewModel> installments)
        {
            this.Client = client;
            this.Invoice = invoice;
            this.InvoiceFreezedFamilyItems = invoiceFreezedFamilyItems;
            this.InvoiceItems = invoiceItems;
            this.InvoicePayments = invoicePayments;
            this.Installments = installments;
        }
    }
}
