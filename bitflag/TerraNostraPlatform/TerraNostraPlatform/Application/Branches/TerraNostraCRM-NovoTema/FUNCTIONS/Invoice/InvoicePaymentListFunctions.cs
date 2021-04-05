using DB;
using DTO.Invoice;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FUNCTIONS.Invoice
{
    public class InvoicePaymentListFunctions : BasicListFunctions<InvoicePaymentList, InvoicePaymentListViewModel>
    {
        public InvoicePaymentListFunctions(TerraNostraContext context) : base(context, "InvoicePaymentId")
        {
        }

        public override List<InvoicePaymentListViewModel> GetDataViewModel(IEnumerable<InvoicePaymentList> data)
        {
            return data.Select(x => x.CopyToEntity<InvoicePaymentListViewModel>()).ToList();
        }

        public override InvoicePaymentListViewModel GetDataViewModel(InvoicePaymentList data)
        {
            return data.CopyToEntity<InvoicePaymentListViewModel>();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.InvoicePaymentList;
        }
    }
}
